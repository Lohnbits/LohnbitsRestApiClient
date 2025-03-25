using System.Collections.Generic;
using gv3kPortableData.Lohn.Auswertungen.Auswertungen;

#nullable enable

namespace gv3kServerFibuLohn.Api.Data.Reports
{
    public class ExecuteReportWageTrendResult : BaseResult
    {
        public ExecuteReportWageTrendResult()
        {
            Zeilen = new List<DataLohnAuswertungFelderMitarbeiterLohnentwicklung>();
        }

        public new ExecuteReportWageTrendResult Error(eErrorCode errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }

        public List<DataLohnAuswertungFelderMitarbeiterLohnentwicklung> Zeilen { set; get; }
    }
}
