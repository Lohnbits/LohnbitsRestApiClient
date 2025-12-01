#nullable enable

using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace gv3kServerFibuLohn.Api.Data.MasterData
{
    public class DataEmployeeWorkingHoursExternal
    {
        public DataEmployeeWorkingHoursExternal()
        {
            ZeiterfassungSchichtBuchungApiLfdNr = 0;
            ClientId = 0;
            EmployeeId = 0;
            ClientNumber = 0;
            PersonnelNumber = 0;
            CompanyPersonnelNumber = "";
            TimeTrackingPersonnelNumber = "";

            Datum = DateTime.MinValue;
            WorkingHours = 0;
            ShiftStart = "";
            ShiftEnd = "";
            BreakStart1 = "";
            BreakEnd1 = "";
            BreakStart2 = "";
            BreakEnd2 = "";
            BreakStart3 = "";
            BreakEnd3 = "";
            Remark = "";
        }

        [JsonProperty("id")]
        [Description("Identifikationsnummer der Datensatzes")]
        public int ZeiterfassungSchichtBuchungApiLfdNr { get; set; }

        [Description("Identifikationsnummer des Mandanten. Für weitere Informationen siehe `clientNumber`")]
        public int ClientId { get; set; }

        [Description("Identifikationsnummer des Mitarbeiters. Die Nummer wird von Lohnbits vergeben.")]
        public int EmployeeId { get; set; }

        [Description("Entweder wird `clientNumber` oder `clientId` angegeben, um einen Mitarbeiter einem Mandanten zuzuordnen.Soweit die Werte eindeutig sind, ist es auch möglich, `clientGroupId` und eine eindeutige Mitarbeiternummer (`personnelNumber`, `companyPersonnelNumber` oder `timeTrackingPersonnelNumber`) anzugeben")]
        public int ClientNumber { get; set; }

        [Description("Numerische Mitarbeiternummer in DATEV. Diese Nummer muss eindeutig sein.")]
        public int PersonnelNumber { get; set; }

        [Description("Alternative alphanumerische Mitarbeiternummer in DATEV. Nur verwenden wenn das Feld ohnehin verwendet wird.")]
        public string CompanyPersonnelNumber { get; set; }

        [Description("Sollten die Mitarbeiternummern in der Zeiterfassung von den Mitarbeiternummern in DATEV abweichen, soll dieses Feld genutzt werden.")]
        public string TimeTrackingPersonnelNumber { set; get; }

        [JsonProperty("Date")]
        [Description("Datum für das die Daten gelten.")]
        public DateTime Datum { get; set; }

        [Description("Die Arbeitszeit in Stunden und Industrieminuten.")]
        public decimal WorkingHours { get; set; }

        [Description("Der Schichtbeginn im Format hh:mm.")]
        public string ShiftStart { get; set; }

        [Description("Das Schichtende im Format hh:mm.")]
        public string ShiftEnd { get; set; }

        [Description("Der Beginn der ersten Pause im Format hh:mm.")]
        public string BreakStart1 { get; set; }

        [Description("Das Ende der ersten Pause im Format hh:mm.")]
        public string BreakEnd1 { get; set; }

        [Description("Der Beginn der zweiten Pause im Format hh:mm.")]
        public string BreakStart2 { get; set; }

        [Description("Das Ende der zweiten Pause im Format hh:mm.")]
        public string BreakEnd2 { get; set; }

        [Description("Der Beginn der dritten Pause im Format hh:mm.")]
        public string BreakStart3 { get; set; }

        [Description("Das Ende der dritten Pause im Format hh:mm.")]
        public string BreakEnd3 { get; set; }

        [Description("Der Prozentsatz für Kurzarbeit.")]
        public decimal PercentageShortTimeWork { get; set; }

        [Description("Eine Bemerkung.")]
        public string Remark { get; set; }
    }
}
