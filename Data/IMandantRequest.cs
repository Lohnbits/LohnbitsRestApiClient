#nullable enable

using System.ComponentModel;

namespace gv3kServerFibuLohn.Api.Data
{
    public interface IMandantRequest
    {
        /// <summary>
        /// Entweder wird <see cref="ClientNumber"/> oder <see cref="ClientId"/> angegeben, um einen Mitarbeiter einem Mandanten zuzuordnen. 
        /// </summary>
        [Description("Entweder wird `clientNumber` oder `clientId` angegeben, um einen Mitarbeiter einem Mandanten zuzuordnen.")]
        public int? ClientNumber { set; get; }

        /// <summary>
        /// siehe Mandantennummer; der Primärschlüssel für den Mandanten in der Lohnbits-Datenbank
        /// </summary>
        [Description("Identifikationsnummer des Mandanten. Für weitere Informationen siehe `clientNumber`")]
        public int? ClientId { set; get; }

        [Description("Identifikationsnummer der Mandantengruppe.")]
        public int? ClientGroupId { set; get; }
    }
}
