using System;
using System.ComponentModel;

#nullable enable

namespace gv3kServerFibuLohn.Api.Data.MonthlyData
{
    public class OpenMonthlyDataRequest : ITransactionId, IMandantRequest
    {
        public OpenMonthlyDataRequest()
        {
            LohnbitsSyncApiLogLfdNr = 0;

            ClientNumber = null;
            ClientId = null;
            ClientGroupId = null;
            TransactionId = string.Empty;
            PreRecordingTitle = string.Empty;
            Period = DateTime.MinValue;
        }

        [Description("Identifikationsnummer des Aufrufprotokolls. Wird nur für interne Zwecke benötigt und darf nicht manuell vergeben werden.")]
        public int LohnbitsSyncApiLogLfdNr { set; get; }

        [Description("Entweder wird `clientNumber` oder `clientId` angegeben, um einen Mitarbeiter einem Mandanten zuzuordnen.")]
        public int? ClientNumber { set; get; }

        [Description("Identifikationsnummer des Mandanten. Für weitere Informationen siehe `clientNumber`")]
        public int? ClientId { set; get; }

        [Description("Identifikationsnummer der Mandantengruppe. Darf zur Zeit nicht verwendet werden")]
        public int? ClientGroupId { set; get; }

        [Description("Bezeichnungen der Vorerfassung")]
        public string PreRecordingTitle { set; get; }

        [Description("Beschreibt den Zeitraum, für welchen die Monatsdatenerfassung initialisiert werden soll")]
        public DateTime Period { set; get; }

        [Description("Identifikationsnummer der durchführenden Transaktion.")]
        public string TransactionId { set; get; }
    }
}
