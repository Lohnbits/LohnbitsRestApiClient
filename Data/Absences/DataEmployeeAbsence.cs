#nullable enable

using System;
using System.ComponentModel;

namespace gv3kServerFibuLohn.Api.Data.Absences
{
    public class DataEmployeeAbsence
    {
        public DataEmployeeAbsence()
        {
            Id = 0;
            ClientId = 0;
            EmployeeId = 0;
            ClientNumber = 0;
            PersonnelNumber = 0;
            CompanyPersonnelNumber = "";
            TimeTrackingPersonnelNumber = "";
            Date = DateTime.MinValue;
            Duration = "";
            ApprovalStatus = "";
            CertificateOfIncapacityForWorkStatus = "";
            AbsenceKeyLohnbits = "";
            AbsenceKeyDatev = "";
            AbsenceKeyTimeTracking = "";
            DailyTargetWorkingHours = 0;
            HoursAbsent = 0;
            DaysAbsent = 0;
            UpdatedAt = DateTime.MinValue;
        }

        [Description("Identifikationsnummer der Abwesenheit für diesen Tag.\n" +
            "_Achtung:_\n" +
            "Sollten am selben Tag für den selben Mitarbeiter unterschiedliche Abwesenheiten für den Vor- und Nachmittag existieren, haben beide Datensätze die gleiche `Id`.")]
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

        [Description("Abwesenheitsdatum")]
        public DateTime Date { set; get; }

        /// <summary>
        /// enthält die Werte Ganztags, Vormittags, Nachmittags
        /// </summary>
        [Description("Abwesenheitsdauer für den Tag in 'date'. Folgende Werte sind möglich:\n" +
            "* Ganztags\n" +
            "* Vormittags\n" +
            "* Nachmittags")]
        public string Duration { set; get;  }

        /// <summary>
        /// enthält die Werte 
        /// - Unbekannt,
        /// - TeilweiseGenehmigt,
        /// - Genehmigt,
        /// - Abgelehnt,
        /// - WartetAufGenehmigung,
        /// - BitteRuecksprache
        /// </summary>
        [Description("Genehmigungsstatus der Abwesenheit. Folgende Werte sind möglich:\n" +
            "* Unbekannt\n" +
            "* TeilweiseGenehmigt\n" +
            "* Genehmigt\n" +
            "* Abgelehnt\n" +
            "* WartetAufGenehmigung\n" +
            "* BitteRuecksprache")]
        public string ApprovalStatus { set; get; }

        /// <summary>
        /// enthält die Werte: 
        /// - Unbekannt,
        /// - EauDeaktivert,
        /// - AuFehlt,
        /// - EauAbgelehnt,
        /// - ArbeitsunfaehigkeitUngueltig,
        /// - AuNichtErforderlich,
        /// - AuWartetAufBestaetigung,
        /// - EauAngefragt,
        /// - AuVorhanden,
        /// - EauVorhanden,
        /// </summary>
        [Description("Status der Arbeitsunfähigkeitsbescheinigung. Folgende Werte sind möglich:\n" +
            "* Unbekannt\n" +
            "* EauDeaktivert\n" +
            "* AuFehlt\n" +
            "* EauAbgelehnt\n" +
            "* ArbeitsunfaehigkeitUngueltig\n" +
            "* AuNichtErforderlich\n" +
            "* AuWartetAufBestaetigung\n" +
            "* EauAngefragt\n" +
            "* AuVorhanden\n" +
            "* EauVorhanden")]
        public string CertificateOfIncapacityForWorkStatus{ set; get; }

        /// <summary>
        /// der Ausfallschlüssel in Lohnbits
        /// </summary>
        [Description("Lohnbits Ausfallschlüssel der Abwesenheit")]
        public string AbsenceKeyLohnbits { set; get; }

        /// <summary>
        /// der (normierte) DATEV Ausfallschluessel
        /// </summary>
        [Description("DATEV (normierte) Ausfallschlüssel der Abwesenheit")]
        public string AbsenceKeyDatev { set; get; }

        /// <summary>
        /// der abweichende Ausfallschlüssel für die Zeiterfassung
        /// </summary>
        [Description("Abweichender Ausfallschlüssel der Abwesenheit für die Zeiterfassung")]
        public string AbsenceKeyTimeTracking { set; get; }

        /// <summary>
        /// die Soll-Arbeitszeit des Mitarbeiters an diesem Tag in Stunden und Industrieminuten
        /// </summary>
        [Description("Soll-Arbeitszeit des Mitarbeiters an diesem Tag in Stunden und Industrieminuten")]
        public decimal DailyTargetWorkingHours { set; get; }

        /// <summary>
        /// die ausgefallene Arbeitszeit des Mitarbeiters an diesem Tag in Stunden und Industrieminuten
        /// </summary>
        [Description("Ausgefallene Arbeitszeit des Mitarbeiters an diesem Tag in Stunden und Industrieminuten")]
        public decimal HoursAbsent { set; get;  }

        /// <summary>
        /// die ausgefallene Arbeitszeit des Mitarbeiters in Arbeitstagen
        /// </summary>
        [Description("Ausgefallene Arbeitszeit des Mitarbeiters in Arbeitstagen")]
        public decimal DaysAbsent { set; get; }

        /// <summary>
        /// Datum und Zeit der letzten Änderung des Datensatzes; wird auch gesetzt, wenn sich in der Vergangenheit Werte geändert
        /// haben, die Auswirkungen auf Summen haben (z.B. Krankheitstage)
        /// </summary>
        [Description("Datum und Zeit der letzten Änderung des Datensatzes in Lohnbits")]
        public DateTime UpdatedAt { set; get; }
    }
}
