using System.Collections.Generic;
using System.ComponentModel;

#nullable enable

namespace gv3kServerFibuLohn.Api.Data.MasterData
{
    public class SelectDocumentTypesResult : BaseResult
    {
        public SelectDocumentTypesResult()
        {
            DocumentTypes = new List<DataDocumentType>();
        }

        public new SelectDocumentTypesResult Error(eErrorCode errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }

        [Description("Liste der gültigen Dokumenttypen")]
        public List<DataDocumentType> DocumentTypes { set; get; }
    }
}
