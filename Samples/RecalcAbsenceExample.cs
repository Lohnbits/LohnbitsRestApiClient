using System;
using gv3kServerFibuLohn.Api.Data.Absences;
using LohnbitsRestApiClient.Model;
using LohnbitsRestApiClient.Helper;

namespace LohnbitsRestApiClient.Samples;

public class RecalcAbsenceExample : BaseExample
{
    public static void Execute(LoginMethod loginMethod)
    {
        var token = GetToken(loginMethod);

        var customer = SelectCustomer(token);
        if (customer == null)
        {
            Console.WriteLine("Keine Firma ausgewählt. Beende das Beispiel.");
            return;
        }

        var employee = SelectEmployee(token, customer);
        if (employee == null)
        {
            Console.WriteLine("Mitarbeiterauswahl abgebrochen. Beende das Beispiel.");
            return;
        }

        // Eingabe des Abfragezeitraums
        Console.WriteLine("Gib das Startdatum des Abfragezeitraums ein (Format: tt.mm.jj): ");
        var startDate = ReadDate();
        Console.WriteLine("Gib das Enddatum des Abfragezeitraums ein (Format: tt.mm.jj): ");
        var endDate = ReadDate();

        var recalcRequest = new RecalcEmployeeAbsenceRequest
        {
            ClientId = customer.ClientId,
            EmployeeId = employee.EmployeeId,
            RecalcPeriodBegin = startDate,
            RecalcPeriodEnd = endDate
        };

        var result = WebApiBase.RequestPost<RecalcEmployeeAbsenceResult>("recalcEmployeeAbsence", token, recalcRequest);

        Console.WriteLine($"POST ../recalcEmployeeAbsence");
        Console.WriteLine($"Request: {{ clientId: {recalcRequest.ClientId}, employeeId: {recalcRequest.EmployeeId}, recalcPeriodBegin: {recalcRequest.RecalcPeriodBegin}, recalcPeriodEnd: {recalcRequest.RecalcPeriodEnd} }}");
        Console.WriteLine($"Response: {{ errorCode: {result?.ErrorCode} }}");

        Logout(token);
    }
}
