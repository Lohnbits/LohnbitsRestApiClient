using System;
using System.ComponentModel;

#nullable enable

namespace gv3kServerFibuLohn.Api.Data.Reports
{
    public class SelectReportEmployeeListRequest : ITransactionId, IMandantRequest
    {
        public SelectReportEmployeeListRequest()
        {
            LohnbitsSyncApiLogLfdNr = 0;

            ClientNumber = null;
            ClientId = null;
            ClientGroupId = null;
            TransactionId = string.Empty;
            DataReportId = null;
            ReportPeriodBegin = null;
            ReportPeriodEnd = null;
            IsExcelExport = null;
        }

        [Description("Identifikationsnummer des Aufrufprotokolls. Wird nur für interne Zwecke benötigt und darf nicht manuell vergeben werden.")]
        public int LohnbitsSyncApiLogLfdNr { set; get; }

        [Description("Entweder wird `clientNumber` oder `clientId` angegeben, um einen Mitarbeiter einem Mandanten zuzuordnen.")]
        public int? ClientNumber { set; get; }

        [Description("Identifikationsnummer des Mandanten. Für weitere Informationen siehe `clientNumber`")]
        public int? ClientId { set; get; }

        [Description("Identifikationsnummer der Mandantengruppe. Alle Mitarbeiter der gesetzten Mandantengruppe werden zurückgegeben.")]
        public int? ClientGroupId { set; get; }

        [Description("Identifikationsnummer der durchführenden Transaktion.")]
        public string TransactionId { set; get; }

        [Description("Identifikationsnummer der Auswertung. Diese Auswertung soll ausgeführt werden.")]
        public int? DataReportId { set; get; }

        [Description("Für Sonderfälle: Beginn des Auswertungszeitraums")]
        public DateTime? ReportPeriodBegin { set; get; }

        [Description("Für Sonderfälle: Ende des Auswertungszeitraums")]
        public DateTime? ReportPeriodEnd { set; get; }

        [Description("Beschreibt ob ein Excel-Export erstellt werden soll.")]
        public bool? IsExcelExport { set; get; }
    }
}
