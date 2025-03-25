using LohnbitsRestApiClient.Model;

namespace LohnbitsRestApiClient.Samples;

public class FirstStepsExample : BaseExample
{
    public static void Execute(LoginMethod loginMethod)
    {
        var token = GetToken(loginMethod);

        Console.WriteLine($"Folgenden JWT erhalten:\n{token}");

        // Abmeldung vom REST API Gateway
        WebApiBase.RequestGet<Task>("logout", token);
    }
}
