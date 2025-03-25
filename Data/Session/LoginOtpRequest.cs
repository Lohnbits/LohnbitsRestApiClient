#nullable enable

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace gv3kServerFibuLohn.Api.Data.Session
{
    /// <summary>
    /// Die Struktur für einen Login-Request mit Benutzername, Passwort und OTP.
    /// </summary>
    public class LoginOtpRequest
    {
        /// <summary>
        /// Standardkonstruktor, dem Benutzername, Passwort und OTP übergeben werden.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="otp"></param>
        public LoginOtpRequest(string username, string password, string otp)
        {
            Username = username;
            Password = password;
            Otp = otp;
        }

        [Required]
        [Description("Benutzername mit dem die Anmeldung durchgeführt werden soll.")]
        public string Username { set; get; }

        [Required]
        [Description("Passwort für den angegebenen Benutzernamen.")]
        public string Password { set; get; }

        [Required]
        [Description("Einmalkennwort für die 2-Faktor-Authentifizierung.")]
        public string Otp { set; get;}
    }
}

