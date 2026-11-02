using System.Collections.Generic;
using System.ComponentModel;

#nullable enable

namespace gv3kServerFibuLohn.Api.Data.MasterData
{
    public class SelectEmployeesHistoricalDataResult : BaseResult
    {
        public SelectEmployeesHistoricalDataResult()
        {
            Employees = new List<DataEmployeeHistoricalData>();
        }

        public new SelectEmployeesHistoricalDataResult Error(eErrorCode errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }

        [Description("List der zurückgelieferten Mitarbeiter inklusive ihrer historischen Daten")]
        public List<DataEmployeeHistoricalData> Employees { set; get; }
    }
}
