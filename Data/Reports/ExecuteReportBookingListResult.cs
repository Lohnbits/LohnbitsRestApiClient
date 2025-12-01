using System.Collections.Generic;
using gv3kPortableData.Lohn.Auswertungen.Auswertungen;

namespace gv3kServerFibuLohn.Api.Data.Reports
{
    public class ExecuteReportBookingListResult : BaseResult
    {
        public ExecuteReportBookingListResult()
        {
            Zeilen = new List<DataLohnAuswertungFelderBuchungsliste>();
        }

        public new ExecuteReportBookingListResult Error(eErrorCode errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }

        public List<DataLohnAuswertungFelderBuchungsliste> Zeilen { set; get; }
    }
}
