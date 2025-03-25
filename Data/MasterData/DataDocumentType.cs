#nullable enable

using System.ComponentModel;
using System.Text.Json.Serialization;

namespace gv3kServerFibuLohn.Api.Data.MasterData
{
    public class DataDocumentType
    {
        public DataDocumentType()
        {
            LohnbitsDokumenttypLfdNr = 0;
            DocumentTitle = string.Empty;
            IsWriteAccess = false;
        }

        [JsonPropertyName("id")]
        [Description("Identifikationsnummer des Dokumenttpys")]
        public int LohnbitsDokumenttypLfdNr { set; get; }

        [Description("Bezeichnung des Dokumenttypes")]
        public string DocumentTitle { set; get; }

        [Description("Darf dieser Dokumenttyp erstellt / verändert werden\n\n" +
            "__Hinweis__: aufgrund der internen Struktur von Lohnbits gibt es Dokumenttypen, die selbst als Administrator nicht verändert werden dürfen")]
        public bool IsWriteAccess { set; get; }
    }
}
