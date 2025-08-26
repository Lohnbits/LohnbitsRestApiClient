using gv3kServerFibuLohn.Api.Data.MasterData;
using LohnbitsRestApiClient.Helper;
using LohnbitsRestApiClient.Model;

namespace LohnbitsRestApiClient.Samples;

public class GetEmployeesWorkingHoursExample : BaseExample
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

        var workingHoursRequest = new SelectEmployeeWorkingHoursRequest
        {
            EmployeeId = employee.EmployeeId,
            ClientId = customer.ClientId,
        };

        var workingHoursResponse = GetWorkingHours(token, workingHoursRequest);
        Console.WriteLine(workingHoursResponse?.AsJsonString(10));
        
        // Abmeldung vom REST API Gateway
        WebApiBase.RequestGet<Task>("logout", token);   
    }

    private static SelectEmployeeWorkingHoursResult? GetWorkingHours(string token, SelectEmployeeWorkingHoursRequest request)
    {
        var workingHours = WebApiBase.RequestPost<SelectEmployeeWorkingHoursResult>("selectEmployeeWorkingHours", token, request);

        Console.WriteLine($"POST ../selectEmployeeWorkingHours");
        Console.WriteLine($"Request: {{ clientId: {request.ClientId}, employeeId: {request.EmployeeId} }}");
        Console.WriteLine($"Response: {{ errorCode: {workingHours?.ErrorCode} }}");
        
        return workingHours;
    }
}