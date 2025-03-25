#nullable enable

using System.ComponentModel;

namespace gv3kServerFibuLohn.Api.Data.Documents
{
    public class InsertDocumentPersonnelFileResult : BaseResult
    {
        public InsertDocumentPersonnelFileResult()
        {
            Hash = null;
        }

        public new InsertDocumentPersonnelFileResult Error(eErrorCode errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }

        [Description("Berechneter Hash des hochgeladenen Dokuments")]
        public byte[]? Hash { get; set; }
    }
}