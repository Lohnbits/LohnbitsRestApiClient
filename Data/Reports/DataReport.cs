#nullable enable

using Newtonsoft.Json;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace gv3kServerFibuLohn.Api.Data.Reports
{
    public class DataReport
    {
        public DataReport()
        {
            LohnbitsAuswertungenEinstellungenLfdNr = 0;
            Title = string.Empty;
            ReportType = string.Empty;
            Code = string.Empty;
        }

        [JsonProperty("id")]
        [JsonPropertyName("id")]
        [Description("Identifikationsnummer der Auswertung")]
        public int LohnbitsAuswertungenEinstellungenLfdNr { set; get; }

        [Description("Bezeichnung der Auswertung")]
        public string Title { set; get; }

        [Description("Art der Auswertung")]
        public string ReportType { set; get; }

        [Description("Eindeutiger Code, mit welchem die Liste eindeutig identifiziert werden kann.")]
        public string Code { set; get; }
    }
}
