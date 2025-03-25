#nullable enable

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace gv3kServerFibuLohn.Api.Data.Session
{
    /// <summary>
    /// Die Struktur für einen Login-Request mit Benutzername + Passwort; der Bearer wird verschlüsselt zurückgegeben
    /// </summary>
    public class LoginEncryptedRequest
    {
        /// <summary>
        /// Standardkonstruktor, dem Benutzernamen und Passwort übergeben werden
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public LoginEncryptedRequest(string username, string password)
        {
            Username = username;
            Password = password;
        }

        [Required]
        [Description("Benutzername mit dem die Anmeldung durchgeführt werden soll.")]
        public string Username { set; get; }

        [Required]
        [Description("Passwort für den angegebenen Benutzernamen.")]
        public string Password { set; get; }
    }
}
