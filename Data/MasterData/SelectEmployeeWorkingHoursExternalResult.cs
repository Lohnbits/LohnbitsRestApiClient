using System.Collections.Generic;
using System.ComponentModel;

namespace gv3kServerFibuLohn.Api.Data.MasterData
{
    public class SelectEmployeeWorkingHoursExternalResult : BaseResult
    {
        public SelectEmployeeWorkingHoursExternalResult()
        {
            WorkingHoursExternal = new List<DataEmployeeWorkingHoursExternal>();
        }

        public new SelectEmployeeWorkingHoursExternalResult Error(eErrorCode errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }

        [Description("Liste der Mitarbeiterarbeitszeiten, die über eine externe API gepflegt werden.")]
        public List<DataEmployeeWorkingHoursExternal> WorkingHoursExternal { set; get; }
    }
}
