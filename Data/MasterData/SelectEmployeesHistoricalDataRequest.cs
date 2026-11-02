#nullable enable

using System.ComponentModel;

namespace gv3kServerFibuLohn.Api.Data.MasterData
{
    public class SelectEmployeesHistoricalDataRequest : ITransactionId, IMandantRequest, IMitarbeiterRequest
    {
        public SelectEmployeesHistoricalDataRequest()
        {
            LohnbitsSyncApiLogLfdNr = 0;

            ClientNumber = null;
            ClientId = null;
            ClientGroupId = null;
            OnlyActiveEmployees = null;
            PersonnelNumber = null;
            CompanyPersonnelNumber = null;
            TimeTrackingPersonnelNumber = null;
            EmployeeId = null;
            TransactionId = string.Empty;
        }

        [Description("Identifikationsnummer des Aufrufprotokolls. Wird nur für interne Zwecke benötigt und darf nicht manuell vergeben werden.")]
        public int LohnbitsSyncApiLogLfdNr { set; get; }

        [Description("Entweder wird `clientNumber` oder `clientId` angegeben, um einen Mitarbeiter einem Mandanten zuzuordnen.")]
        public int? ClientNumber { set; get; }

        [Description("Identifikationsnummer des Mandanten. Für weitere Informationen siehe `clientNumber`")]
        public int? ClientId { set; get; }

        [Description("Identifikationsnummer der Mandantengruppe. Alle Mitarbeiter der gesetzten Mandantengruppe werden zurückgegeben.")]
        public int? ClientGroupId { set; get; }

        [Description("Beschreibt, ob nur aktive Mitarbeiter zurückgegeben werden sollen.")]
        public bool? OnlyActiveEmployees { get; set; }

        [Description("Numerische Mitarbeiternummer in DATEV. Diese Nummer muss eindeutig sein.")]
        public int? PersonnelNumber { set; get; }

        [Description("Alternative alphanumerische Mitarbeiternummer in DATEV. Nur verwenden wenn das Feld ohnehin verwendet wird.")]
        public string? CompanyPersonnelNumber { set; get; }

        [Description("Sollten die Mitarbeiternummern in der Zeiterfassung von den Mitarbeiternummern in DATEV abweichen, soll dieses Feld genutzt werden.")]
        public string? TimeTrackingPersonnelNumber { set; get; }

        [Description("Identifikationsnummer des Mitarbeiters.")]
        public int? EmployeeId { set; get; }

        [Description("Identifikationsnummer der durchführenden Transaktion.")]
        public string TransactionId { set; get; }
    }
}
