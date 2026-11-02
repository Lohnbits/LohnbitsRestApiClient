#nullable enable

using System;
using System.ComponentModel;

namespace gv3kServerFibuLohn.Api.Data.MasterData
{
    public class DataEmployeeStandardRemuneration
    {
        public DataEmployeeStandardRemuneration()
        {
            ValidFrom = DateTime.MinValue;
            SocialInsuranceNumber = "";
            StandardRemunerationNumber = 0;
            StandardRemunerationDescription = "";
            FinancialAccountingGroupNumber = 0;
            PersonGroupKey = 0;
        }

        [Description("Datum, ab dem die Werte dieses Datensatzes gelten.")]
        public DateTime ValidFrom { get; set; }

        [Description("Versicherungsnummer (Sozialversicherungsnummer) des Mitarbeiters.")]
        public string SocialInsuranceNumber { get; set; }

        [Description("Standardentlohnung des Mitarbeiters als Nummer. Folgende Werte sind möglich:\n" +
            "* 0 = Stundenlohn\n" +
            "* 1 = Gehalt\n" +
            "* 2 = Tageslohn\n" +
            "* 3 = Sonstiges")]
        public int StandardRemunerationNumber { get; set; }

        [Description("Bezeichnung der Standardentlohnung passend zu `standardRemunerationNumber`, z.B. 'Stundenlohn' oder 'Gehalt'.")]
        public string StandardRemunerationDescription { get; set; }

        [Description("Nummer der Fibugruppe (Gruppe der Finanzbuchhaltung), der der Mitarbeiter zugeordnet ist.")]
        public int FinancialAccountingGroupNumber { get; set; }

        [Description("Personengruppenschlüssel des Mitarbeiters gemäß ITSG-Tabelle, z.B. 101 für sozialversicherungspflichtig Beschäftigte.")]
        public int PersonGroupKey { get; set; }
    }
}
