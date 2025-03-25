#nullable enable

using System.ComponentModel;

namespace gv3kServerFibuLohn.Api.Data.Documents
{
    public class InsertDocumentInboxResult : BaseResult
    {
        public InsertDocumentInboxResult()
        {
            Hash = null;
        }

        public new InsertDocumentInboxResult Error(eErrorCode errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }

        [Description("Berechneter Hash des hochgeladenen Dokuments")]
        public byte[]? Hash { get; set; }
    }
}