using gv3kServerFibuLohn.Api.Data.Session;
using LohnbitsRestApiClient.Model;

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
