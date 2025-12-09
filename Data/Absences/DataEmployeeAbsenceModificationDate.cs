#nullable enable

using System;
using System.ComponentModel;

namespace gv3kServerFibuLohn.Api.Data.Absences
{
    public class DataEmployeeAbsenceModificationDate
    {
        public DataEmployeeAbsenceModificationDate()
        {
            ClientId = 0;
            EmployeeId = 0;
            ClientNumber = 0;
            PersonnelNumber = 0;
            CompanyPersonnelNumber = "";
            TimeTrackingPersonnelNumber = "";
            ModificationDate = DateTime.MinValue;
        }

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

        /// <summary>
        /// Datum und Zeit der letzten Änderung des Datensatzes; wird auch gesetzt, wenn sich in der Vergangenheit Werte geändert
        /// haben, die Auswirkungen auf Summen haben (z.B. Krankheitstage)
        /// </summary>
        [Description("Datum und Zeit der letzten Änderung des Datensatzes in Lohnbits")]
        public DateTime ModificationDate { set; get; }
    }
}

