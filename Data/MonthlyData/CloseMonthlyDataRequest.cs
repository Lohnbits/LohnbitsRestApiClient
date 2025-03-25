using System;
using System.ComponentModel;

#nullable enable

namespace gv3kServerFibuLohn.Api.Data.MonthlyData
{
    public class CloseMonthlyDataRequest : ITransactionId
    {
        public CloseMonthlyDataRequest()
        {
            LohnbitsSyncApiLogLfdNr = 0;
            Id = Guid.Empty;
            TransactionId = string.Empty;
        }

        [Description("Identifikationsnummer des Aufrufprotokolls. Wird nur für interne Zwecke benötigt und darf nicht manuell vergeben werden.")]
        public int LohnbitsSyncApiLogLfdNr { set; get; }

        [Description("Identifikationsnummer der Monatsdatenerfassung. Diese Monatsdatenerfassung soll geschlossen werden.")]
        public Guid Id { set; get; }

        [Description("Identifikationsnummer der durchführenden Transaktion.")]
        public string TransactionId { set; get; }
    }
}
