using System;
using System.ComponentModel;

#nullable enable

namespace gv3kServerFibuLohn.Api.Data.TimeRecording
{
    public class SelectTargetWorkdayRequest : IMandantRequest, IMitarbeiterRequest, ITransactionId
    {
        public SelectTargetWorkdayRequest()
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
        }

        [Description("Identifikationsnummer des Aufrufprotokolls. Wird nur für interne Zwecke benötigt und darf nicht manuell vergeben werden.")]
        public int LohnbitsSyncApiLogLfdNr { set; get; }

        [Description("Entweder wird `clientNumber` oder `clientId` angegeben, um einen Mitarbeiter einem Mandanten zuzuordnen.")]
        public int? ClientNumber { set; get; }

        [Description("Identifikationsnummer des Mandanten. Für weitere Informationen siehe `clientNumber`")]
        public int? ClientId { set; get; }

        [Description("Identifikationsnummer der Mandantengruppe. Wird für diesen Aufruf zur Zeit nicht unterstützt.")]
        public int? ClientGroupId { set; get; }

        [Description("Numerische Mitarbeiternummer in DATEV. Diese Nummer muss eindeutig sein.")]
        public int? PersonnelNumber { set; get; }

        [Description("Alternative alphanumerische Mitarbeiternummer in DATEV. Nur verwenden wenn das Feld ohnehin verwendet wird.")]
        public string? CompanyPersonnelNumber { set; get; }

        [Description("Sollten die Mitarbeiternummern in der Zeiterfassung von den Mitarbeiternummern in DATEV abweichen, soll dieses Feld genutzt werden.")]
        public string? TimeTrackingPersonnelNumber { set; get; }

        [Description("Identifikationsnummer des Mitarbeiters. Ist keine Mitarbeiternummer angegeben, werden die Tagessollwerte aller Mitarbeiter des Mandanten zurückgegeben.")]
        public int? EmployeeId { set; get; }

        [Description("Identifikationsnummer der durchführenden Transaktion.")]
        public string TransactionId { set; get; }

        /// <summary>
        /// erster Tag des abgefragten Zeitraums (bezogen auf DataZeiterfassungApiTagSoll.Datum)
        /// </summary>
        [Description("Beginn des abgefragten Zeitraums")]
        public DateTime? RequestPeriodBegin { set; get; }

        /// <summary>
        /// letzter Tag des abgefragten Zeitraums (bezogen auf DataZeiterfassungApiTagSoll.Datum)
        /// </summary>
        [Description("Ende des abgefragten Zeitraums")]
        public DateTime? RequestPeriodEnd { set; get; }
    }
}
