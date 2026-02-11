using System;
using System.ComponentModel;

#nullable enable

namespace gv3kServerFibuLohn.Api.Data.Absences
{
    public class SelectEmployeeAbsenceRequest : IMandantRequest, IMitarbeiterRequest, ITransactionId
    {
        public SelectEmployeeAbsenceRequest()
        {
            LohnbitsSyncApiLogLfdNr = 0;

            ClientNumber = null;
            ClientId = null;
            ClientGroupId = null;
            PersonnelNumber = null;
            CompanyPersonnelNumber = null;
            TimeTrackingPersonnelNumber = null;
            EmployeeId = null;
            TransactionId = string.Empty;

            RequestPeriodBegin = null;
            RequestPeriodEnd = null;

            ModifiedAfter = null;
            ModifiedBefore = null;
        }

        [Description("Identifikationsnummer des Aufrufprotokolls. Wird nur für interne Zwecke benötigt und darf nicht manuell vergeben werden.")]
        public int LohnbitsSyncApiLogLfdNr { set; get; }

        [Description("Entweder wird `clientNumber` oder `clientId` angegeben, um einen Mitarbeiter einem Mandanten zuzuordnen.Soweit die Werte eindeutig sind, ist es auch möglich, `clientGroupId` und eine eindeutige Mitarbeiternummer (`personnelNumber`, `companyPersonnelNumber` oder `timeTrackingPersonnelNumber`) anzugeben")]
        public int? ClientNumber { set; get; }

        [Description("Identifikationsnummer des Mandanten. Für weitere Informationen siehe `clientNumber`")]
        public int? ClientId { set; get; }

        [Description("Identifikationsnummer der Mandantengruppe. Für weitere Informationen siehe `clientNumber`")]
        public int? ClientGroupId { set; get; }

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

        [Description("Beginn des abgefragten Zeitraums")]
        public DateTime? RequestPeriodBegin { set; get; }

        [Description("Ende des abgefragten Zeitraums")]
        public DateTime? RequestPeriodEnd { set; get; }

        [Description("Filter: Erhalte alle Abwesenheiten welche vor diesem Datum das letzt Mal geändert wurden.\n" +
            "In Kombination mit ´modifiedBefore´ werden alle Abwesenheiten, welche in diesem Zeitraum das letzte Mal geändert wurden, zurückgegeben")]
        public DateTime? ModifiedAfter { get; set; }

        [Description("Filter: Erhalte alle Abwesenheiten welche nach diesem Datum das letzt Mal geändert wurden.\n" +
            "In Kombination mit ´modifiedAfter´ werden alle Abwesenheiten, welche in diesem Zeitraum das letzte Mal geändert wurden, zurückgegeben")]
        public DateTime? ModifiedBefore { get; set; }
    }
}

