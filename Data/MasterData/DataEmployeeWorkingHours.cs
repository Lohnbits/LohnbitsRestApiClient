#nullable enable

using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace gv3kServerFibuLohn.Api.Data.MasterData
{
    public class DataEmployeeWorkingHours
    {
        public DataEmployeeWorkingHours()
        {
            InternetMandantLohnMitarbeiterArbeitszeitLfdNr = 0;
            ClientId = 0;
            EmployeeId = 0;
            ClientNumber = 0;
            PersonnelNumber = 0;
            CompanyPersonnelNumber = "";
            TimeTrackingPersonnelNumber = "";
            ValidFrom = DateTime.MinValue;
            WorkingHoursMonday = 0;
            WorkingHoursTuesday = 0;
            WorkingHoursWednesday = 0;
            WorkingHoursThursday = 0;
            WorkingHoursFriday = 0;
            WorkingHoursSaturday = 0;
            WorkingHoursSunday = 0;
            WorkingHoursFullTime = 0;
            WorkingHoursWeek = 0;
            ReasonForChangeInWorkingHours = "";
            EditingInstructions = "";
        }

        [JsonPropertyName("id")]
        [Description("Identifikationsnummer der Datensatzes")]
        public int InternetMandantLohnMitarbeiterArbeitszeitLfdNr { get; set; }

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

        [Description("Datum ab wann die Arbeitszeiten gelten. Es wird der Monatsanfang abgegeben.")]
        public DateTime ValidFrom { get; set; }

        [Description("Die Arbeitszeit an Montagen in Stunden und Industrieminuten.")]
        public decimal WorkingHoursMonday { get; set; }

        [Description("Die Arbeitszeit an Dienstagen in Stunden und Industrieminuten.")]
        public decimal WorkingHoursTuesday { get; set; }

        [Description("Die Arbeitszeit an Mittwochen in Stunden und Industrieminuten.")]
        public decimal WorkingHoursWednesday { get; set; }

        [Description("Die Arbeitszeit an Donnerstagen in Stunden und Industrieminuten.")]
        public decimal WorkingHoursThursday { get; set; }

        [Description("Die Arbeitszeit and Freitagen in Stunden und Industrieminuten.")]
        public decimal WorkingHoursFriday { get; set; }

        [Description("Die Arbeitszeit and Samstagen in Stunden und Industrieminuten.")]
        public decimal WorkingHoursSaturday { get; set; }

        [Description("Die Arbeitszeit and Sonntagen in Stunden und Industrieminuten.")]
        public decimal WorkingHoursSunday { get; set; }

        [Description("Die Arbeitszeit eines Vollzeitmitarbeiters in Stunden und Industrieminuten.")]
        public decimal WorkingHoursFullTime { get; set; }

        [Description("Die wöchentliche Arbeitszeit in Stunden und Industrieminuten.")]
        public decimal WorkingHoursWeek { get; set; }

        [Description("Die Begründung für den Arbeitzeitwechsel - hierbei handelt es sich um von der ITSG fest vorgegebene Werte")]
        public string ReasonForChangeInWorkingHours { set; get; }

        [Description("Der Bearbeitungshinweis.")]
        public string EditingInstructions { set; get; }
    }
}
