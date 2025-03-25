using gv3kServerFibuLohn.Api.Data.Documents;
using gv3kServerFibuLohn.Api.Data.MasterData;
using LohnbitsRestApiClient.Model;

namespace LohnbitsRestApiClient.Samples;

public class UploadDocumentExample : BaseExample
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

        // Abfrage aller Dokument für den ersten Mandanten; es wird der Dokumenttyp mit dem Titel "Arbeitsvertrag" ausgewählt
        var documentTypesRequest = new SelectDocumentTypesRequest() { ClientNumber = 80998 };
        var documentTypesResult = WebApiBase.RequestPost<SelectDocumentTypesResult>("selectDocumentTypes", token, documentTypesRequest);
        var documentTypeArbeitsvertrag = documentTypesResult?.DocumentTypes?.FirstOrDefault(_ => _.DocumentTitle == "Arbeitsvertrag")?.LohnbitsDokumenttypLfdNr ?? 0;

        Console.WriteLine($"POST ../selectDocumentTypes");
        Console.WriteLine($"Request: {{ clientNumber: {documentTypesRequest.ClientNumber} }}");
        Console.WriteLine($"Response: {{ errorCode: {documentTypesResult?.ErrorCode}, documentTypeId: {documentTypeArbeitsvertrag} }}");

        // jetzt wird das Dokument hochgeladen
        // für die Parameter siehe swagger
        var doc = new InsertDocumentPersonnelFileRequest()
        {
            ClientNumber = 80998,
            PersonnelNumber = 54,
            DocumentDate = new DateTime(2024, 12, 15),
            MonthlyRecordingPeriod = new DateTime(2025, 3, 1),
            DocumentTypeId = documentTypeArbeitsvertrag,
            IsOnlyForPersonnelFile = false,
            IsOldVersion = false,
            IsHighPriority = false,
            Content = File.ReadAllBytes(@"test.pdf"),
            Note = "Testdokument"
        };
        var docResult = WebApiBase.RequestPost<InsertDocumentPersonnelFileResult>("insertDocumentPersonnelFile", token, doc);

        Console.WriteLine($"POST ../insertDocumentPersonnelFile");
        Console.WriteLine($"Request: {{ clientNumber: {doc.ClientNumber}, personnelNumber: {doc.PersonnelNumber}, documentDate: {doc.DocumentDate}, monthlyRecordingPeriod: {doc.MonthlyRecordingPeriod}, documentTypeId: {doc.DocumentTypeId}, isOnlyForPersonnelFile: {doc.IsOnlyForPersonnelFile}, isOldVersion: {doc.IsOldVersion}, isHighPriority: {doc.IsHighPriority}, content: {doc.Content}, note: {doc.Note} }}");
        Console.WriteLine($"Response: {{ errorCode: {docResult?.ErrorCode}, hashLength: {docResult?.Hash?.Length} }}");

        // Abmeldung vom REST API Gateway
        WebApiBase.RequestGet<Task>("session/logout", token);
    }
}
