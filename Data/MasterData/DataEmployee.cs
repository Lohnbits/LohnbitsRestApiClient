#nullable enable

using System;
using System.ComponentModel;

namespace gv3kServerFibuLohn.Api.Data.MasterData
{
    public class DataEmployee
    {
        public DataEmployee()
        {
            ClientId = 0;
            EmployeeId = 0;
            ClientNumber = 0;
            FirstName = "";
            SurName = "";
            PersonnelNumber = 0;
            CompanyName = "";
            CompanyPersonnelNumber = "";
            TimeTrackingPersonnelNumber = "";
            EntryDate = DateTime.MinValue;
            LeavingDate = DateTime.MinValue;
            EmploymentStatus = "";
            FullName = "";
            FullNameVariant = "";
        }

        [Description("Identifikationsnummer des Mandanten")]
        public int ClientId { get; set; }

        [Description("Identifikationsnummer des Mitarbeiters")]
        public int EmployeeId { get; set; }

        [Description("Mandantennummer")]
        public int ClientNumber { get; set; }

        [Description("Vorname des Mitarbeiters.")]
        public string FirstName { get; set; }

        [Description("Familienname des Mitarbeiters.")]
        public string SurName { get; set; }

        [Description("Numerische Mitarbeiternummer in DATEV.")]
        public int PersonnelNumber { get; set; }

        [Description("Bezeichnung des Betriebs")]
        public string CompanyName { get; set; }

        [Description("Alternative alphanumerische Mitarbeiternummer in DATEV.")]
        public string CompanyPersonnelNumber { get; set; }

        [Description("Identifikationsnummer des Mitarbeiters.")]
        public string TimeTrackingPersonnelNumber { set; get; }

        [Description("Konkatinierter Wert 'Familienname, Vorname (Personalnummer)'")]
        public string FullName { set; get; }

        [Description("Konkatinierter Wert 'Familienname, Vorname'")]
        public string FullNameVariant { set; get; }

        [Description("Eintrittsdatum des Mitarbeiters")]
        public DateTime EntryDate { get; set; }

        [Description("Austrittsdatum des Mitarbeiters")]
        public DateTime LeavingDate { get; set; }

        [Description("Mitarbeiterstatus des Mitarbeiters. Folgende Werte sind möglich:\n" +
            "* AktiverMitarbeiter\n" +
            "* FiktiverMitarbeiterOhneLohnabrechnung\n" +
            "* Ausgeschieden\n" +
            "* RuhenderMitarbeiter\n" +
            "* OnboardingGesperrt\n\n" +
            "RuhenderMitarbeiter wird z.B. bei Elternzeit, Pensionierung, etc. verwendet. OnboardingGesperrt wird verwendet, wenn der Mitarbeiter noch im Onboarding ist und kann bis dahin nur den Personalfragebogen bearbeiten kann")]
        public string EmploymentStatus { get; set; }
    }
}
