using System;
using System.ComponentModel;

#nullable enable

namespace gv3kServerFibuLohn.Api.Data.Absences
{
    public class DeleteEmployeeAbsenceRequest : IMandantRequest, IMitarbeiterRequest, ITransactionId
    {
        public DeleteEmployeeAbsenceRequest()
        {
            LohnbitsSyncApiLogLfdNr = 0;

            ClientNumber = null;
            ClientId = null;
            ClientGroupId = null;
            PersonnelNumber = null;
            CompanyPersonnelNumber = null;
            TimeTrackingPersonnelNumber = null;
            EmployeeId = null;
            Date = DateTimeOffset.MinValue;
            Duration = null;

            TransactionId = string.Empty;
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

        [Description("Abwesenheitsdatum")]
        public DateTimeOffset Date { set; get; }

        /// <summary>
        /// enthält optional die Werte Ganztags, Vormittags, Nachmittags
        /// wenn gefüllt, muss der Wert zur Abwesenheit passen - das halbtägige Löschen einer ganztägigen Abwesenheit
        /// ist nicht möglich
        /// </summary>
        [Description("Abwesenheitsdauer für den Tag in 'date'. Folgende Werte sind möglich:\n" +
            "* Ganztags\n" +
            "* Vormittags\n" +
            "* Nachmittags")]
        public string? Duration { set; get; }

        [Description("Identifikationsnummer der durchführenden Transaktion.")]
        public string TransactionId { set; get; }
    }
}
