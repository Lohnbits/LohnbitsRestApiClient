using gv3kServerFibuLohn.Api.Data.Documents;
using gv3kServerFibuLohn.Api.Data.MasterData;
using LohnbitsRestApiClient.Model;

namespace LohnbitsRestApiClient.Samples;

public class UploadDocumentInboxExample : BaseExample
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

        // Abfrage der Liste aller Mitarbeiter; es wird der Mitarbeiter mit der Personalnummer 20 ausgewählt 
        var employeeRequest = new SelectEmployeesRequest() { ClientId = mandantLfdNr };
        var employeeResult = WebApiBase.RequestPost<SelectEmployeesResult>("selectEmployees", token, employeeRequest);
        var emppoyeeLfdNr = employeeResult?.Employees?.FirstOrDefault(_ => _.PersonnelNumber == 20)?.EmployeeId ?? 0;

        Console.WriteLine($"POST ../selectEmployees");
        Console.WriteLine($"Request: {{ clientId: {employeeRequest.ClientId} }}");
        Console.WriteLine($"Response: {{ errorCode: {employeeResult?.ErrorCode}, employeeId: {emppoyeeLfdNr} }}");

        // jetzt wird das Dokument hochgeladen
        // für die Parameter siehe swagger
        var doc = new InsertDocumentInboxRequest()
        {
            ClientNumber = 80998,
            PersonnelNumber = 54,
            DocumentDate = new DateTime(2024, 12, 15),
            Content = File.ReadAllBytes(@"test.pdf"),
            Note = "Testdokument"
        };
        var docResult = WebApiBase.RequestPost<InsertDocumentPersonnelFileResult>("insertDocumentInbox", token, doc);

        Console.WriteLine($"POST ../insertDocumentInbox");
        Console.WriteLine($"Request: {{ clientNumber: {doc.ClientNumber}, personnelNumber: {doc.PersonnelNumber}, documentDate: {doc.DocumentDate}, content: {doc.Content}, note: {doc.Note} }}");
        Console.WriteLine($"Response: {{ errorCode: {docResult?.ErrorCode}, employeeId: {docResult?.Hash?.Length} }}");

        // Abmeldung vom REST API Gateway
        WebApiBase.RequestGet<Task>("session/logout", token);
    }
}
