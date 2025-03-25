#nullable enable

using System.ComponentModel;

namespace gv3kServerFibuLohn.Api.Data.Session
{
    /// <summary>
    /// Die Struktur für einen LoginOtp-Response. Sie enthält das verschlüsselte Bearertoken, das für die weiteren Anfragen verwendet werden kann.
    /// </summary>
    public class LoginEncryptedResult : BaseResult
    {
        public LoginEncryptedResult()
        {
            EncryptedToken = string.Empty;
        }

        [Description("Verschlüsselter Zugangstoken. Der Zugangstokens hat nach der Entschlüsselung das Format eines JWT. Für den Zugriff auf die weiteren Endpunkte zu erhalten, muss der Zugangstoken in den Authorization Request Header nach dem Bearer Schema verwendet werden [[RFC6750]](https://datatracker.ietf.org/doc/html/rfc6750#section-2.1).")]
        public string EncryptedToken { get; set; }
    }
}
