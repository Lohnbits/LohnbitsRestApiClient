#nullable enable

using System.ComponentModel;

namespace gv3kServerFibuLohn.Api.Data.Session
{
    /// <summary>
    /// Die Struktur für einen LoginOtp-Response. Sie enthält das Bearertoken, das für die weiteren Anfragen verwendet werden kann.
    /// </summary>
    public class LoginOtpResult : BaseResult
    {
        public LoginOtpResult()
        {
            Token = string.Empty;
        }

        [Description("Zugangstoken im JWT-Format. Für den Zugriff auf die weiteren Endpunkte zu erhalten, muss der Zugangstoken in den Authorization Request Header nach dem Bearer Schema verwendet werden [[RFC6750]](https://datatracker.ietf.org/doc/html/rfc6750#section-2.1).")]
        public string Token { get; set; }
    }
}
