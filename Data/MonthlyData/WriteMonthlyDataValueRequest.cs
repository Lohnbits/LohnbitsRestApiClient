using System;
using System.ComponentModel;

#nullable enable

namespace gv3kServerFibuLohn.Api.Data.MonthlyData
{
    public class WriteMonthlyDataValueRequest : ITransactionId, IMitarbeiterRequest
    {
        public WriteMonthlyDataValueRequest()
        {
            LohnbitsSyncApiLogLfdNr = 0;
            Id = Guid.Empty;
            TransactionId = string.Empty;

            PersonnelNumber = null;
            CompanyPersonnelNumber = null;
            TimeTrackingPersonnelNumber = null;
            EmployeeId = null;

            VariableName = string.Empty;
            ValueDecimal = null;
            ValueInt = null;
            ValueString = null;
            ValueBool = null;
            Bemerkung = null;
        }

        [Description("Identifikationsnummer des Aufrufprotokolls. Wird nur für interne Zwecke benötigt und darf nicht manuell vergeben werden.")]
        public int LohnbitsSyncApiLogLfdNr { set; get; }

        [Description("Identifikationsnummer der Monatsdatenerfassen, welche verwendet werden soll.")]
        public Guid Id { set; get; }

        [Description("Identifikationsnummer der durchführenden Transaktion.")]
        public string TransactionId { set; get; }

        [Description("Numerische Mitarbeiternummer in DATEV. Diese Nummer muss eindeutig sein.")]
        public int? PersonnelNumber { set; get; }

        [Description("Alternative alphanumerische Mitarbeiternummer in DATEV. Nur verwenden wenn das Feld ohnehin verwendet wird.")]
        public string? CompanyPersonnelNumber { set; get; }

        [Description("Sollten die Mitarbeiternummern in der Zeiterfassung von den Mitarbeiternummern in DATEV abweichen, soll dieses Feld genutzt werden.")]
        public string? TimeTrackingPersonnelNumber { set; get; }

        [Description("Identifikationsnummer des Mitarbeiters. Die Nummer wird von Lohnbits vergeben.")]
        public int? EmployeeId { set; get; }

        [Description("Name der Variable, welche gelesen werden soll.")]
        public string VariableName { set; get; }

        [Description("Verwende diese Eigenschaft wenn ein Dezimalwert gerschrieben werden soll")]
        public decimal? ValueDecimal { set; get; }

        [Description("Verwende diese Eigenschaft wenn ein Integer gerschrieben werden soll")]
        public int? ValueInt { set; get; }

        [Description("Verwende diese Eigenschaft wenn ein Boolean gerschrieben werden soll")]
        public bool? ValueBool { set; get; }

        [Description("Verwende diese Eigenschaft wenn ein String gerschrieben werden soll")]
        public string? ValueString { set; get; }

        [Description("Optionale Bemerkung")]
        public string? Bemerkung { set; get; }
    }
}
