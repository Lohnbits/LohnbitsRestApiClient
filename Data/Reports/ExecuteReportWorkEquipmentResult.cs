using System.Collections.Generic;
using gv3kPortableData.Lohn.Auswertungen.Auswertungen;

#nullable enable

namespace gv3kServerFibuLohn.Api.Data.Reports
{
    public class ExecuteReportWorkEquipmentResult : BaseResult
    {
        public ExecuteReportWorkEquipmentResult()
        {
            Zeilen = new List<DataLohnAuswertungFelderArbeitsmittel>();
        }

        public new ExecuteReportWorkEquipmentResult Error(eErrorCode errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }

        public List<DataLohnAuswertungFelderArbeitsmittel> Zeilen { set; get; }
    }
}
