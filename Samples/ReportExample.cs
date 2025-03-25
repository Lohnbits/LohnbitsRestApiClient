using gv3kServerFibuLohn.Api.Data.MasterData;
using gv3kServerFibuLohn.Api.Data.Reports;
using LohnbitsRestApiClient.Model;

namespace LohnbitsRestApiClient.Samples;

public class ReportExample : BaseExample
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

        var reportRequests = new SelectReportsRequest() { ClientId = mandantLfdNr };
        var reportResult = WebApiBase.RequestPost<SelectReportsResult>("selectReports", token, reportRequests);

        Console.WriteLine($"POST ../selectReports");
        Console.WriteLine($"Request: {{ clientId: {reportRequests.ClientId} }}");
        Console.WriteLine($"Response: {{ errorCode: {reportResult?.ErrorCode}, reportCount: {reportResult?.Reports.Count} }}");

        var reportMitarbeiterlisteRequest = new ExecuteReportEmployeeListRequest() { ClientId = mandantLfdNr, Code = "Geburtstag" };
        var reportMitarbeiterlisteResult = WebApiBase.RequestPost<ExecuteReportEmployeeListResult>("executeReportEmployeeList", token, reportMitarbeiterlisteRequest);

        Console.WriteLine($"POST ../executeReportEmployeeList");
        Console.WriteLine($"Request: {{ clientId: {reportMitarbeiterlisteRequest.ClientId}, code: {reportMitarbeiterlisteRequest.Code} }}");
        Console.WriteLine($"Response: {{ errorCode: {reportMitarbeiterlisteResult?.ErrorCode}, rowCount: {reportMitarbeiterlisteResult?.Zeilen.Count} }}");

        var reportLohnentwicklungRequest = new ExecuteReportEmployeeListRequest() { ClientId = mandantLfdNr, Code = "Lohnentwicklung", ReportPeriodBegin = new DateTime(2025, 1, 1), ReportPeriodEnd = new DateTime(2025, 3, 31) };
        var reportLohnentwicklungResult = WebApiBase.RequestPost<ExecuteReportEmployeeListResult>("executeReportWageTrendList", token, reportLohnentwicklungRequest);

        Console.WriteLine($"POST ../executeReportWageTrendList");
        Console.WriteLine($"Request: {{ clientId: {reportLohnentwicklungRequest.ClientId}, code: {reportLohnentwicklungRequest.Code}, reportPeriodBegin: {reportLohnentwicklungRequest.ReportPeriodBegin}, reportPeriodEnd: {reportLohnentwicklungRequest.ReportPeriodEnd} }}");
        Console.WriteLine($"Response: {{ errorCode: {reportLohnentwicklungResult?.ErrorCode}, rowCount: {reportLohnentwicklungResult?.Zeilen.Count} }}");

        // Abmeldung vom REST API Gateway
        WebApiBase.RequestGet<Task>("session/logout", token);
    }
}
