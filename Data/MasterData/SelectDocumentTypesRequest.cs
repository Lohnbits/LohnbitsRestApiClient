#nullable enable

using System.ComponentModel;
using System.Text.Json.Serialization;

namespace gv3kServerFibuLohn.Api.Data.MasterData
{
    public class SelectDocumentTypesRequest : ITransactionId, IMandantRequest
    {
        public SelectDocumentTypesRequest()
        {
            LohnbitsSyncApiLogLfdNr = 0;

            ClientNumber = null;
            ClientId = null;
            ClientGroupId = null;
            SpecialFunction = null;
            TransactionId = string.Empty;
        }

        [Description("Identifikationsnummer des Aufrufprotokolls. Wird nur für interne Zwecke benötigt und darf nicht manuell vergeben werden.")]
        public int LohnbitsSyncApiLogLfdNr { set; get; }

        [Description("Entweder wird `clientNumber` oder `clientId` angegeben, um einen Mitarbeiter einem Mandanten zuzuordnen.")]
        public int? ClientNumber { set; get; }

        [Description("Identifikationsnummer des Mandanten. Für weitere Informationen siehe `clientNumber`")]
        public int? ClientId { set; get; }

        [Description("Identifikationsnummer der Mandantengruppe. Bei Dokumenttypen ist die Zuordnung über eine Mandantengruppe nicht möglich.")]
        public int? ClientGroupId { set; get; }

        [Description("Beschreibt den Sondersachverhalt, um eine gezielte Dokumentenart zu suchen")]
        public string? SpecialFunction { set; get; }

        [Description("Identifikationsnummer der durchführenden Transaktion.")]
        public string TransactionId { set; get; }
    }
}
