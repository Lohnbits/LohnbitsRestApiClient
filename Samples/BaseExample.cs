using gv3kServerFibuLohn.Api.Data.MasterData;
using gv3kServerFibuLohn.Api.Data.Session;
using LohnbitsRestApiClient.Model;
using static gv3kServerFibuLohn.Api.Data.BaseResult;

namespace LohnbitsRestApiClient.Samples;

public abstract class BaseExample
{
    protected static string GetToken(LoginMethod loginMethod)
    {
        switch (loginMethod)
        {
            case LoginMethod.Totp:
                return GetTokenWithSimpleLogin();
            case LoginMethod.Encrypted:
                return GetTokenWithEncryptedLogin();
            default:
                return string.Empty;
        }
    }

    protected static DataCustomer? SelectCustomer(string token)
    {
        var customers = WebApiBase.RequestGet<SelectCustomersResult>("selectCustomers", token);
        if (customers == null || customers.ErrorCode != eErrorCode.None || customers.Customers.Count == 0)
        {
            Console.WriteLine("Fehler beim Laden der Kunden oder keine Kunden vorhanden.");
            return null;
        }

        while (true)
        {
            Console.WriteLine("Bitte wähle die Firma per Nummer aus (oder 'exit' zum Beenden):");
            for (int i = 0; i < customers.Customers.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {customers.Customers[i].CompanyName}");
            }

            Console.WriteLine();
            var selection = Console.ReadLine();
            if (selection?.Trim().ToLower() == "exit")
                return null;

            if (int.TryParse(selection, out int customerIndex) && customerIndex > 0 && customerIndex <= customers.Customers.Count)
            {
                return customers.Customers[customerIndex - 1];
            }

            Console.WriteLine("Ungültige Auswahl. Bitte erneut versuchen.");
        }
    }

    protected static DataEmployee? SelectEmployee(string token, DataCustomer customer)
    {
        var request = new SelectEmployeesRequest { ClientId = customer.ClientId };
        var employees = WebApiBase.RequestPost<SelectEmployeesResult>("selectEmployees", token, request);
        if (employees == null || employees.ErrorCode != eErrorCode.None || employees.Employees.Count == 0)
        {
            Console.WriteLine("Fehler beim Laden der Mitarbeiter oder keine Mitarbeiter vorhanden.");
            return null;
        }

        while (true)
        {
            Console.WriteLine("Bitte wähle den Mitarbeiter per Nummer aus, drücke Enter zum Überspringen oder gib 'exit' zum Beenden ein:");
            for (int i = 0; i < employees.Employees.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {employees.Employees[i].FirstName} {employees.Employees[i].SurName}");
            }

            var selection = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(selection))
                return new DataEmployee { EmployeeId = -1 };

            if (selection.Trim().ToLower() == "exit")
                return null;

            if (int.TryParse(selection, out int employeeIndex) && employeeIndex > 0 && employeeIndex <= employees.Employees.Count)
            {
                return employees.Employees[employeeIndex - 1];
            }

            Console.WriteLine("Ungültige Auswahl. Bitte erneut versuchen.");
        }
    }

    private static string GetTokenWithSimpleLogin()
    {
        while (true)
        {
            var credentials = CredentialsProvider.GetCredentialsForTotpLogin();

            Console.WriteLine("Bitte TOTP-Code eingeben:");
            var totp = Console.ReadLine() ?? "";

            if (totp.Length != 6)
            {
                continue;
            }

            // Anmeldung bei LOHNBITS mit Benutzername, Passwort und OTP und Erhalt des Bearer Tokens
            var loginRequest = new LoginOtpRequest(credentials.Username, credentials.Password, totp);
            var loginResult = WebApiBase.RequestPost<LoginOtpResult>("loginOtp", loginRequest);
            var token = loginResult?.Token ?? "";

            return token;
        }
    }

    private static string GetTokenWithEncryptedLogin()
    {
        var credentials = CredentialsProvider.GetCredentialsForEncryptedLogin();
        // AES Key initialisieren
        var aesKeyBytes = Convert.FromBase64String(credentials.AesKey!);

        // Anmeldung bei LOHNBITS mit Benutzername, Passwort und Erhalt des verschlüsselten Bearer Tokens
        var loginRequest = new LoginEncryptedRequest(credentials.Username, credentials.Password);
        var loginResult = WebApiBase.RequestPost<LoginEncryptedResult>("loginEncrypted", loginRequest);
        var encryptedBearerToken = loginResult?.EncryptedToken ?? "";
        var token = ModelHelper.DecryptStringAES(encryptedBearerToken, aesKeyBytes);

        return token;
    }
}
