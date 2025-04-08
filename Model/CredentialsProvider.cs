namespace LohnbitsRestApiClient.Model;

public static class CredentialsProvider
{
    private const string Username = "<Lohnbits-Benutzername hier eintragen>";
    private const string Password = "<Lohnbits-Password hier eintragen>";
    private const string AesKey = "<Lohnbits-AES-Key hier eintragen>";

    public static Credentials GetCredentialsForTotpLogin()
    {
        var user = Environment.GetEnvironmentVariable("lohnbitsDemoUser", EnvironmentVariableTarget.Process);
        var password = Environment.GetEnvironmentVariable("lohnbitsDemoPassword", EnvironmentVariableTarget.Process);

        if (string.IsNullOrEmpty(user))
        {
            user = Username;
        }

        if (string.IsNullOrEmpty(password))
        {
            password = Password;
        }

        return new Credentials
        {
            Username = user,
            Password = password
        };
    }

    public static Credentials GetCredentialsForEncryptedLogin()
    {
        var user = Environment.GetEnvironmentVariable("lohnbitsDemoUser", EnvironmentVariableTarget.User);
        var password = Environment.GetEnvironmentVariable("lohnbitsDemoPassword", EnvironmentVariableTarget.User);
        var aesKey = Environment.GetEnvironmentVariable("lohnbitsDemoAesKey", EnvironmentVariableTarget.User);

        if (string.IsNullOrEmpty(user))
        {
            user = Username;
        }

        if (string.IsNullOrEmpty(password))
        {
            password = Password;
        }

        if (string.IsNullOrEmpty(aesKey))
        {
            aesKey = AesKey;
        }

        return new Credentials
        {
            Username = user,
            Password = password,
            AesKey = aesKey
        };
    }
}

public class Credentials
{
    public required string Username { get; init; }

    public required string Password { get; init; }

    public string? AesKey { get; init; }
}
