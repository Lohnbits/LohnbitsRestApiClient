using System;
using gv3kServerFibuLohn.Api.Data.Absences;
using LohnbitsRestApiClient.Model;
using LohnbitsRestApiClient.Helper;

namespace LohnbitsRestApiClient.Samples;

public class InsertAbsenceExample : BaseExample
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

        // Eingabe des Abwesenheitszeitraums
        Console.WriteLine("Gib das Startdatum der Abwesenheit ein (Format: tt.mm.jj): ");
        var startDate = ReadDate();
        Console.WriteLine("Gib das Enddatum der Abwesenheit ein (Format: tt.mm.jj): ");
        var endDate = ReadDate();

        // Eingabe des Abwesenheitstyps (Schlüssel)
        Console.WriteLine("Gib den Lohnbits Ausfallschlüssel der Abwesenheit ein:");
        var absenceKeyLohnbits = Console.ReadLine()?.Trim() ?? "";

        // Optional: Bemerkung
        Console.WriteLine("Bemerkung zur Abwesenheit (optional):");
        var remark = Console.ReadLine()?.Trim() ?? "";

        var insertRequest = new InsertEmployeeAbsenceRequest
        {
            ClientId = customer.ClientId,
            EmployeeId = employee.EmployeeId,
            AbsencePeriodBegin = new DateTimeOffset(startDate),
            AbsencePeriodEnd = new DateTimeOffset(endDate),
            AbsenceKeyLohnbits = absenceKeyLohnbits,
            Remark = remark
        };

        var result = WebApiBase.RequestPost<InsertEmployeeAbsenceResult>("insertEmployeeAbsence", token, insertRequest);

        Console.WriteLine($"POST ../insertEmployeeAbsence");
        Console.WriteLine($"Request: {{ clientId: {insertRequest.ClientId}, employeeId: {insertRequest.EmployeeId}, absencePeriodBegin: {insertRequest.AbsencePeriodBegin}, absencePeriodEnd: {insertRequest.AbsencePeriodEnd}, absenceKeyLohnbits: {insertRequest.AbsenceKeyLohnbits} }}");
        Console.WriteLine($"Response: {{ errorCode: {result?.ErrorCode} }}");

        Logout(token);
    }

}
