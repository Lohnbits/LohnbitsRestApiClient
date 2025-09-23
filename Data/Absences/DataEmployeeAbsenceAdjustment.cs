#nullable enable

using System;
using System.ComponentModel;

namespace gv3kServerFibuLohn.Api.Data.Absences
{
    public class DataEmployeeAbsenceAdjustment
    {
        public DataEmployeeAbsenceAdjustment()
        {
            Id = 0;
            ClientId = 0;
            EmployeeId = 0;
            ClientNumber = 0;
            PersonnelNumber = 0;
            CompanyPersonnelNumber = "";
            TimeTrackingPersonnelNumber = "";
            Date = DateTime.MinValue;
            ArtBuchung = "";
            FehlzeitStunden = 0;
            FehlzeitTage = 0;
        }

        [Description("Eindeutige Identifikationsnummer der Abwesenheitsanpassung.")]
        public int Id { get; set; }

        [Description("Identifikationsnummer des Mandanten")]
        public int ClientId { get; set; }

        [Description("Identifikationsnummer des Mitarbeiters")]
        public int EmployeeId { get; set; }

        [Description("Mandantennummer")]
        public int ClientNumber { get; set; }

        [Description("Numerische Mitarbeiternummer in DATEV.")]
        public int PersonnelNumber { get; set; }

        [Description("Alternative alphanumerische Mitarbeiternummer in DATEV.")]
        public string CompanyPersonnelNumber { get; set; }

        [Description("Identifikationsnummer des Mitarbeiters.")]
        public string TimeTrackingPersonnelNumber { set; get; }

        [Description("Buchungsdatum")]
        public DateTime Date { set; get; }

        [Description("Es gibt folgende Buchungsarten:\n" +
                     "- Kalkulatorisch\n" +
                     "- KorrekturGrundurlaubsanspruch\n" +
                     "- KorrekturZusatzurlaubsanspruch\n" +
                     "- KorrekturSchwerbehindertenurlaubsanspruch")]
        public string ArtBuchung { set; get; }

        [Description("Fehlzeit in Stunden")]
        public decimal FehlzeitStunden { set; get; }

        [Description("Fehlzeit in Tagen")]
        public decimal FehlzeitTage { set; get; }
    }
}
