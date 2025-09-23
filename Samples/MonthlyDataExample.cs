using gv3kServerFibuLohn.Api.Data.MasterData;
using gv3kServerFibuLohn.Api.Data.MonthlyData;
using LohnbitsRestApiClient.Model;

namespace LohnbitsRestApiClient.Samples;

public class MonthlyDataExample : BaseExample
{
    public static void Execute(LoginMethod loginMethod)
    {
        var token = GetToken(loginMethod);

        // Abfrage, auf welche Betriebe Zugriff besteht; es wird der erste Betrieb ausgewählt 
        // wichtig: bei vielen Abfragen ist die Suche nach Mandantengruppe noch nicht implementiert
        // die Mandantennummer der Rückgabe darf verwendet werden
        var customersResult = WebApiBase.RequestGet<SelectCustomersResult>("selectCustomers", token);
        var mandantLfdNr = customersResult?.Customers?.FirstOrDefault()?.ClientId ?? 0;

        Console.WriteLine($"GET ../selectCustomers");
        Console.WriteLine($"Response: {{ errorCode: {customersResult?.ErrorCode}, clientId: {mandantLfdNr} }}");

        // öffnet die aktuelle Monatsdatenerfassung
        var openMonthlyDataRequest = new OpenMonthlyDataRequest() { ClientId = mandantLfdNr, Period = DateTime.Now.Date, PreRecordingTitle = "Monatsdaten" };
        var openMonthlyDataResult = WebApiBase.RequestPost<OpenMonthlyDataResult>("openMonthlyData", token, openMonthlyDataRequest);
        var id = openMonthlyDataResult?.Id ?? Guid.Empty;

        Console.WriteLine($"POST ../openMonthlyData");
        Console.WriteLine($"Request: {{ clientId: {openMonthlyDataRequest.ClientId}, period: {openMonthlyDataRequest.Period}, preRecordingTitle: {openMonthlyDataRequest.PreRecordingTitle} }}");
        Console.WriteLine($"Response: {{ errorCode: {openMonthlyDataResult?.ErrorCode}, id: {id} }}");

        // schreibt für Mitarbeiternummer 54 den Wert 19.0 in die Variable "Überstunden"
        var writeMonthlyDataValueRequest = new WriteMonthlyDataValueRequest() { Id = id, VariableName = "Überstunden", PersonnelNumber = 54, ValueDecimal = 19.0M };
        var writeMonthlyDataValueResult = WebApiBase.RequestPost<WriteMonthlyDataValueResult>("writeMonthlyDataValue", token, writeMonthlyDataValueRequest);

        Console.WriteLine($"POST ../writeMonthlyDataValue");
        Console.WriteLine($"Request: {{ id: {writeMonthlyDataValueRequest.Id}, variableName: {writeMonthlyDataValueRequest.VariableName}, personnelNumber: {writeMonthlyDataValueRequest.PersonnelNumber}, valueDecimal: {writeMonthlyDataValueRequest.ValueDecimal} }}");
        Console.WriteLine($"Response: {{ errorCode: {writeMonthlyDataValueResult?.ErrorCode} }}");

        // liest für Mitarbeiternummer 54 den Wert der Variable "Überstunden"
        var readMonthlyDataValueRequest = new ReadMonthlyDataValueRequest() { Id = id, VariableName = "Überstunden", PersonnelNumber = 54 };
        var readMonthlyDataValueResult = WebApiBase.RequestPost<ReadMonthlyDataValueResult>("readMonthlyDataValue", token, readMonthlyDataValueRequest);

        Console.WriteLine($"POST ../readMonthlyDataValue");
        Console.WriteLine($"Request: {{ id: {readMonthlyDataValueRequest.Id}, variableName: {readMonthlyDataValueRequest.VariableName}, personnelNumber: {readMonthlyDataValueRequest.PersonnelNumber} }}");
        Console.WriteLine($"Response: {{ errorCode: {readMonthlyDataValueResult?.ErrorCode}, valueDecimal: {readMonthlyDataValueResult?.ValueDecimal} }}");

        // schließt die Monatsdatenerfassung
        var closeMonthlyDataRequest = new CloseMonthlyDataRequest() { Id = id };
        var closeMonthlyDataResult = WebApiBase.RequestPut<CloseMonthlyDataResult>("closeMonthlyData", token, closeMonthlyDataRequest);

        Console.WriteLine($"PUT ../closeMonthlyData");
        Console.WriteLine($"Request: {{ id: {closeMonthlyDataRequest.Id} }}");
        Console.WriteLine($"Response: {{ errorCode: {closeMonthlyDataResult?.ErrorCode} }}");

        Logout(token);
    }
}
