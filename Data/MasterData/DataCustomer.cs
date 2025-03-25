#nullable enable

using System.ComponentModel;

namespace gv3kServerFibuLohn.Api.Data.MasterData
{
    public class DataCustomer
    {
        public DataCustomer()
        {
            ClientId = 0;
            ClientGroupId = 0;
            ClientNumber = 0;
            CompanyName = "";
        }

        [Description("Identifikationsnummer des Mandanten")]
        public int ClientId { set; get; }

        [Description("Identifikationsnummer der Mandantengruppe.")]
        public int ClientGroupId { set; get; }

        [Description("Mandantennummer")]
        public int ClientNumber { set; get; }

        [Description("Bezeichnung des Betriebs")]
        public string CompanyName { set; get; }
    }
}
