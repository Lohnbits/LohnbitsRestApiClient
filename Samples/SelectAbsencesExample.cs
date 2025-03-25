using gv3kServerFibuLohn.Api.Data.Absences;
using gv3kServerFibuLohn.Api.Data.MasterData;
using LohnbitsRestApiClient.Model;

namespace LohnbitsRestApiClient.Samples;

public class SelectAbsencesExample : BaseExample
{
    public static void Execute(LoginMethod loginMethod)
    {
        var bearerToken = GetToken(loginMethod);

        // Abfrage, auf welche Betriebe Zugriff besteht; es wird der erste Betrieb ausgewählt 
        // wichtig: bei vielen Abfragen ist die Suche nach Mandantengruppe noch nicht implementiert
        // die Mandantennummer der Rückgabe darf verwendet werden
        var customersResult = WebApiBase.RequestGet<SelectCustomersResult>("selectCustomers", bearerToken);
        var mandantLfdNr = customersResult?.Customers?.FirstOrDefault()?.ClientId ?? 0;

        Console.WriteLine($"GET ../selectCustomers");
        Console.WriteLine($"Response: {{ errorCode: {customersResult?.ErrorCode}, clientId: {mandantLfdNr} }}");

        var selectAbsenceRequest = new SelectEmployeeAbsenceRequest() { ClientId = mandantLfdNr, RequestPeriodBegin = new DateTime(2025, 1, 1), RequestPeriodEnd = new DateTime(2025, 5, 31) };
        var selectAbsenceResult = WebApiBase.RequestPost<SelectEmployeeAbsenceResult>("selectEmployeeAbsence", bearerToken, selectAbsenceRequest);

        Console.WriteLine($"POST ../selectEmployeeAbsence");
        Console.WriteLine($"Request: {{ clientId: {selectAbsenceRequest.ClientId}, requestPeriodBegin: {selectAbsenceRequest.RequestPeriodBegin}, requestPeriodEnd: {selectAbsenceRequest.RequestPeriodEnd} }}");
        Console.WriteLine($"Response: {{ errorCode: {selectAbsenceResult?.ErrorCode}, absenceCount: {selectAbsenceResult?.Absences.Count} }}");


        // Abmeldung vom REST API Gateway
        WebApiBase.RequestGet<Task>("session/logout", bearerToken);
    }

}
