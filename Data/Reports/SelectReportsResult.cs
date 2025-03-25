using System.Collections.Generic;
using System.ComponentModel;

#nullable enable

namespace gv3kServerFibuLohn.Api.Data.Reports
{
    public class SelectReportsResult : BaseResult
    {
        public SelectReportsResult()
        {
            Reports = new List<DataReport>();
        }

        public new SelectReportsResult Error(eErrorCode errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }

        [Description("Liste der Auswertungen.")]
        public List<DataReport> Reports { set; get; }
    }
}
