using System;
using gv3kServerFibuLohn.Api.Data.Absences;
using LohnbitsRestApiClient.Model;
using LohnbitsRestApiClient.Helper;

namespace LohnbitsRestApiClient.Samples;

public class DeleteAbsenceExample : BaseExample
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

        // Eingabe des Abwesenheitsdatums
        Console.WriteLine("Gib das Datum der zu löschenden Abwesenheit ein (Format: tt.mm.jj): ");
        var date = ReadDate();

        // Optional: Dauer (Ganztags, Vormittags, Nachmittags)
        Console.WriteLine("Dauer der Abwesenheit (optional: Ganztags, Vormittags, Nachmittags):");
        var duration = Console.ReadLine()?.Trim();
        if (string.IsNullOrWhiteSpace(duration)) duration = null;

        var deleteRequest = new DeleteEmployeeAbsenceRequest
        {
            ClientId = customer.ClientId,
            EmployeeId = employee.EmployeeId,
            Date = new DateTimeOffset(date),
            Duration = duration
        };

        var result = WebApiBase.RequestPost<DeleteEmployeeAbsenceResult>("deleteEmployeeAbsence", token, deleteRequest);

        Console.WriteLine($"POST ../deleteEmployeeAbsence");
        Console.WriteLine($"Request: {{ clientId: {deleteRequest.ClientId}, employeeId: {deleteRequest.EmployeeId}, date: {deleteRequest.Date}, duration: {deleteRequest.Duration} }}");
        Console.WriteLine($"Response: {{ errorCode: {result?.ErrorCode} }}");

        Logout(token);
    }

}
