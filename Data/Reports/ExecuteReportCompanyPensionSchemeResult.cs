using System.Collections.Generic;
using gv3kPortableData.Lohn.Auswertungen.Auswertungen;

#nullable enable

namespace gv3kServerFibuLohn.Api.Data.Reports
{
    public class ExecuteReportCompanyPensionSchemeResult : BaseResult
    {
        public ExecuteReportCompanyPensionSchemeResult()
        {
            Zeilen = new List<DataLohnAuswertungFelderBetrieblicheAltersvorsorge>();
        }

        public new ExecuteReportCompanyPensionSchemeResult Error(eErrorCode errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }

        public List<DataLohnAuswertungFelderBetrieblicheAltersvorsorge> Zeilen { set; get; }
    }
}

