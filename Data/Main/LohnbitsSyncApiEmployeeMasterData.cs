using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace gv3kServerFibuLohn.Api.Data.Main
{
    public class LohnbitsSyncApiEmployeeMasterData
    {
        public LohnbitsSyncApiEmployeeMasterData()
        {
            Clear();
        }

        public void Clear()
        {
            LohnbitsSyncApiMitarbeiterStammLfdNr = 0;
            ClientId = 0;
            EmployeeId = 0;
            PersonnelNumber = 0;
            Surname = string.Empty;
            FirstName = string.Empty;
            Street = string.Empty;
            HouseNumber = string.Empty;
            Postcode = string.Empty;
            City = string.Empty;
            Country = string.Empty;
            MartialStatus = string.Empty;
            Citizenship = string.Empty;
            EmploymentStatus = string.Empty;
            JobTitle = string.Empty;
            Nationality = string.Empty;
            EmployeeGroup = string.Empty;
            Department = string.Empty;
            CostCentre = string.Empty;
            Iban = string.Empty;
            Gender = string.Empty;
        }

        public void CopyFrom(ILohnbitsSyncApiEmpoyeeMasterData source)
        {
            // Mitarbeiternummer fehlt bewusst
            if (source == null) return;
            if (source.Surname != null) Surname = source.Surname;
            if (source.FirstName != null) FirstName = source.FirstName;
            if (source.Street != null) Street = source.Street;
            if (source.HouseNumber != null) HouseNumber = source.HouseNumber;
            if (source.Postcode != null) Postcode = source.Postcode;
            if (source.City != null) City = source.City;
            if (source.Country != null) Country = source.Country;
            if (source.MaritalStatus != null) MartialStatus = source.MaritalStatus;
            if (source.Citizenship != null) Citizenship = source.Citizenship;
            if (source.EmploymentStatus != null) EmploymentStatus = source.EmploymentStatus;
            if (source.JobTitle != null) JobTitle = source.JobTitle;
            if (source.Nationality != null) Nationality = source.Nationality;
            if (source.EmployeeGroup != null) EmployeeGroup = source.EmployeeGroup;
            if (source.Department != null) Department = source.Department;
            if (source.CostCentre != null) CostCentre = source.CostCentre;
            if (source.Iban != null) Iban = source.Iban;
            if (source.Gender != null) Gender = source.Gender;
        }

        [JsonPropertyName("id")]
        public int LohnbitsSyncApiMitarbeiterStammLfdNr { set; get; }

        [Description("Identifikationsnummer des Mandanten.")]
        public int ClientId { set; get; }

        [Description("Identifikationsnummer des Mitarbeiters. Die Nummer wird von Lohnbits vergeben.")]
        public int EmployeeId { set; get; }

        [Description("Numerische Mitarbeiternummer in DATEV.")]
        public int PersonnelNumber { set; get; }

        [Description("Mitarbeiterstatus des Mitarbeiters. Folgende Werte sind möglich:\n" +
            "* AktiverMitarbeiter\n" +
            "* FiktiverMitarbeiterOhneLohnabrechnung\n" +
            "* Ausgeschieden\n" +
            "* RuhenderMitarbeiter\n" +
            "* OnboardingGesperrt\n\n" +
            "RuhenderMitarbeiter wird z.B. bei Elternzeit, Pensionierung, etc. verwendet. OnboardingGesperrt wird verwendet, wenn der Mitarbeiter noch im Onboarding ist und kann bis dahin nur den Personalfragebogen bearbeiten kann")]
        public string EmploymentStatus { set; get; }

        [Description("Familienname des Mitarbeiters.")]
        public string Surname { set; get; }

        [Description("Vorname des Mitarbeiters.")]
        public string FirstName { set; get; }

        [Description("Straße des aktuellen Wohnortes ohne Hausnummer.")]
        public string Street { set; get; }

        [Description("Hausnummer des aktuellen Wohnortes.")]
        public string HouseNumber { set; get; }

        [Description("Postleitzahl des aktuellen Wohnortes.")]
        public string Postcode { set; get; }

        [Description("Ortsname der aktuellen Wohnortes.")]
        public string City { set; get; }

        [Description("Land des aktuellen Wohnortes. Bitte die Kodierung ISO 3166-1 Alpha-3 verwenden.")]
        public string Country { set; get; }

        [Description("Familienstand des Mitarbeiters. Folgende Werte sind möglich:\n" +
            "* 0 LE ledig\n" +
            "* 1 VH verheiratet\n" +
            "* 2 GS geschieden\n" +
            "* 3 VW verwitwet\n" +
            "* 4 GT dauernd getrennt lebend\n" +
            "* 5 PE Lebenspartnerschaft eingetragen\n" +
            "* 6 PA Lebenspartnerschaft aufgehoben\n")]
        public string MartialStatus { set; get; }

        [Description("Staatsangehörigkeit des Mitarbeiters. Bitte die Kodierung ISO 3166-1 Alpha-3 verwenden.")]
        public string Citizenship { set; get; }

        [Description("Beruf des Mitarbeiters.")]
        public string JobTitle { set; get; }

        [Description("Nationalität des Mitarbeiters. Bitte die Kodierung ISO 3166-1 Alpha-3 verwenden.")]
        public string Nationality { set; get; }

        [Description("Mitarbeitergruppe die der Mitarbeiter angehört. Das Feld wird in Datev gepflegt. Wenn nicht vorhanden, wird ein Bearbeitungshinweis für die Lohnbuchhaltung generiert.")]
        public string EmployeeGroup { set; get; }

        [Description("Abteilung die der Mitarbeiter angehört. Das Feld wird in Datev gepflegt. Wenn nicht vorhanden, wird ein Bearbeitungshinweis für die Lohnbuchhaltung generiert.")]
        public string Department { set; get; }

        [Description("Kostenstelle. Das Feld wird in Datev gepflegt. Wenn nicht vorhanden, wird ein Bearbeitungshinweis für die Lohnbuchhaltung generiert.")]
        public string CostCentre { set; get; }

        [Description("IBAN des Mitarbeiters.")]
        public string Iban { set; get; }

        [Description("Das Geschlecht des Mitarbeiters. Folgende Werte sind möglich:\n" +
            "* 0 w weiblich\n" +
            "* 1 m männlich\n" +
            "* 2 d divers\n" +
            "* 3 x unbestimmt")]
        public string Gender { set; get; }
    }
}
