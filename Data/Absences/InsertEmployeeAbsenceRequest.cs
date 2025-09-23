using System;
using System.ComponentModel;

#nullable enable

namespace gv3kServerFibuLohn.Api.Data.Absences
{
    public class InsertEmployeeAbsenceRequest : IMandantRequest, IMitarbeiterRequest, ITransactionId
    {
        public InsertEmployeeAbsenceRequest()
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

            AbsencePeriodBegin = DateTimeOffset.MinValue;
            AbsencePeriodEnd = DateTimeOffset.MinValue;
            AbsenceKeyLohnbits = "";
            AbsenceKeyDatev = "";
            AbsenceKeyTimeTracking = "";
            SubstitutePersonnelNumber = null;
            SubstituteCompanyPersonnelNumber = null;
            SubstituteTimeTrackingPersonnelNumber = null;
            SubstituteEmployeeId = null;
            IsFirstDayAfternoonOnly = false;
            IsLastDayMorningOnly = false;
            PreventRecalc = false;
            Remark = "";
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

        [Description("Beginn des Abwesenheit. Uhrzeit und Zeitzone werden ignoriert. (2025-09-22T15:12:08+02:00 -> 2025-09-22T00:00:00+00:00")]
        public DateTimeOffset AbsencePeriodBegin { set; get; }

        [Description("Ende der Abwesenheit. Uhrzeit und Zeitzone werden ignoriert. (2025-09-22T15:12:08+02:00 -> 2025-09-22T00:00:00+00:00")]
        public DateTimeOffset AbsencePeriodEnd { set; get; }

        [Description("Lohnbits Ausfallschlüssel der Abwesenheit")]
        public string AbsenceKeyLohnbits { set; get; }

        [Description("DATEV (normierte) Ausfallschlüssel der Abwesenheit")]
        public string AbsenceKeyDatev { set; get; }

        [Description("Abweichender Ausfallschlüssel der Abwesenheit für die Zeiterfassung")]
        public string AbsenceKeyTimeTracking { set; get; }

        [Description("Numerische Mitarbeiternummer der Vertretung in DATEV. Diese Nummer muss eindeutig sein.")]
        public int? SubstitutePersonnelNumber { set; get; }

        [Description("Alternative alphanumerische Mitarbeiternummer der Vertretung in DATEV. Nur verwenden wenn das Feld ohnehin verwendet wird.")]
        public string? SubstituteCompanyPersonnelNumber { set; get; }

        [Description("Sollten die Mitarbeiternummern der Vertretung in der Zeiterfassung von den Mitarbeiternummern in DATEV abweichen, soll dieses Feld genutzt werden.")]
        public string? SubstituteTimeTrackingPersonnelNumber { set; get; }

        [Description("Identifikationsnummer der Vertretung des Mitarbeiters.")]
        public int? SubstituteEmployeeId { set; get; }

        [Description("Am ersten Tag nur nachmittags abwesend.")]
        public bool IsFirstDayAfternoonOnly { set; get; }

        [Description("Am letzten Tag nur vormittags abwesend.")]
        public bool IsLastDayMorningOnly { set; get; }

        [Description("Der Datensatz wird nur eingefügt und der Kalender wird aus Performancegründen nicht neu berechnet. Anschließend bitte die Methode RecalcEmployeeAbsence aufrufen.")]
        public bool PreventRecalc { set; get; }

        [Description("Bemerkung zur Abwesenheit")]
        public string Remark { set; get; }
    }
}
