#nullable enable

using System;
using System.ComponentModel;

namespace gv3kServerFibuLohn.Api.Data.Reports
{
    public class ExecuteReportCompanyPensionSchemeRequest : ITransactionId, IMandantRequest
    {
        public ExecuteReportCompanyPensionSchemeRequest()
        {
            LohnbitsSyncApiLogLfdNr = 0;

            ClientNumber = null;
            ClientId = null;
            ClientGroupId = null;
            TransactionId = string.Empty;

            Code = "";
            ReportPeriodBegin = DateTime.MinValue;
            ReportPeriodEnd = DateTime.MinValue;
        }

        [Description("Identifikationsnummer des Aufrufprotokolls. Wird nur für interne Zwecke benötigt und darf nicht manuell vergeben werden.")]
        public int LohnbitsSyncApiLogLfdNr { set; get; }

        [Description("Die Mandantennummer des Unternehmens.")]
        public int? ClientNumber { set; get; }

        [Description("Identifikationsnummer des Mandanten / des Unernehmens.")]
        public int? ClientId { set; get; }

        [Description("Identifikationsnummer der Mandantengruppe.")]
        public int? ClientGroupId { set; get; }

        [Description("Identifikationsnummer der durchführenden Transaktion.")]
        public string TransactionId { set; get; }

        [Description("Eindeutiger Code der Auswertung, welche ausgeführt werden soll. Die Identifizierung erfolgt nicht über eine Identifikationsnummer, sondern den Code")]
        public string Code { set; get; }

        [Description("Beginn des Auswertungszeitraums")]
        public DateTime ReportPeriodBegin { set; get; }

        [Description("Ende des Auswertungszeitraums")]
        public DateTime ReportPeriodEnd { set; get; }
    }
}


