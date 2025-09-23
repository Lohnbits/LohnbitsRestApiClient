using System;
using gv3kServerFibuLohn.Api.Data.Absences;
using LohnbitsRestApiClient.Model;
using LohnbitsRestApiClient.Helper;

namespace LohnbitsRestApiClient.Samples;

public class SelectAbsenceAdjustmentExample : BaseExample
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

        var request = new SelectEmployeeAbsenceAdjustmentRequest
        {
            ClientId = customer.ClientId,
            EmployeeId = employee.EmployeeId,
            RequestPeriodBegin = startDate,
            RequestPeriodEnd = endDate
        };



        var result = WebApiBase.RequestPost<SelectEmployeeAbsenceAdjustmentResult>("selectEmployeeAbsenceAdjustment", token, request);

        Console.WriteLine($"POST ../selectEmployeeAbsenceAdjustment");
        Console.WriteLine($"Request: {{ clientId: {request.ClientId}, employeeId: {request.EmployeeId} }}");
        Console.WriteLine($"Response: {{ errorCode: {result?.ErrorCode} }}");
        AbsenceAdjustmentFormatter.PrintResult(result);

        Logout(token);
    }

}
