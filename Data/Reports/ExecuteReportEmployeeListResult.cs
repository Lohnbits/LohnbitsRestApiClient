using System.Collections.Generic;
using gv3kPortableData.Lohn.Auswertungen.Auswertungen;

#nullable enable

namespace gv3kServerFibuLohn.Api.Data.Reports
{
    public class ExecuteReportEmployeeListResult : BaseResult
    {
        public ExecuteReportEmployeeListResult()
        {
            Zeilen = new List<DataLohnAuswertungFelderMitarbeiterliste>();
        }

        public new ExecuteReportEmployeeListResult Error(eErrorCode errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }

        public List<DataLohnAuswertungFelderMitarbeiterliste> Zeilen { set; get; }
    }
}
