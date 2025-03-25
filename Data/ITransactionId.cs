#nullable enable

using System.ComponentModel;

namespace gv3kServerFibuLohn.Api.Data
{
    public interface ITransactionId
    {
        /// <summary>
        /// der Primärschlüssel des Aufrufprotokolls in der Lohnbits-Datenbank; wird nur für interne Zwecke benötigt
        /// darf nicht vom aufrufenden System vergeben werden
        /// </summary>
        [Description("Identifikationsnummer des Aufrufprotokolls. Wird nur für interne Zwecke benötigt und darf nicht manuell vergeben werden.")]
        public int LohnbitsSyncApiLogLfdNr { set; get; }

        /// <summary>
        /// eine Transkations-ID, die vom aufrufenden System vergeben wird und die in den Log-Tabellen gespeichert wird
        /// </summary>
        [Description("Identifikationsnummer der durchführenden Transaktion.")]
        public string TransactionId { set; get; }
    }
}
