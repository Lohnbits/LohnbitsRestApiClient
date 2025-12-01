using System.Collections.Generic;
using System.ComponentModel;

namespace gv3kServerFibuLohn.Api.Data.MasterData
{
    public class SelectEmployeeWorkingHoursResult : BaseResult
    {
        public SelectEmployeeWorkingHoursResult()
        {
            WorkingHours = new List<DataEmployeeWorkingHours>();
        }

        public new SelectEmployeeWorkingHoursResult Error(eErrorCode errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }

        [Description("Liste der Mitarbeiterarbeitszeiten")]
        public List<DataEmployeeWorkingHours> WorkingHours { set; get; }
    }
}
