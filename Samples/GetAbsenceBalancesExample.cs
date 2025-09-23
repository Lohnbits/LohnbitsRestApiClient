using gv3kServerFibuLohn.Api.Data.Absences;
using LohnbitsRestApiClient.Helper;
using LohnbitsRestApiClient.Model;

namespace LohnbitsRestApiClient.Samples;

public class GetAbsenceBalancesExample : BaseExample
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

        var absenceBalancesRequest = new SelectEmployeeAbsenceBalanceRequest
        {
            EmployeeId = employee.EmployeeId,
            ClientId = customer.ClientId,
            RequestPeriodBegin = new DateTime(DateTime.Now.Year, 1, 1),
            RequestPeriodEnd = new DateTime(DateTime.Now.Year, 12, 31)
        };

        var absenceBalances = WebApiBase.RequestPost<SelectEmployeeAbsenceBalanceResult>("selectEmployeeAbsenceBalance", token, absenceBalancesRequest);

        Console.WriteLine($"POST ../selectEmployeeAbsenceBalance");
        Console.WriteLine($"Request: {{ clientId: {absenceBalancesRequest.ClientId}, employeeId: {absenceBalancesRequest.EmployeeId} }}");
        Console.WriteLine($"Response: {{ errorCode: {absenceBalances?.ErrorCode} }}");
        Console.WriteLine(absenceBalances?.AsJsonString(10));

        Logout(token);
    }
}