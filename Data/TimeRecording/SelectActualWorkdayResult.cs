using System.Collections.Generic;
using System.ComponentModel;

namespace gv3kServerFibuLohn.Api.Data.TimeRecording
{
    public class SelectActualWorkdayResult : BaseResult
    {
        public SelectActualWorkdayResult()
        {
            ActualWorkdays = new List<DataActualWorkday>();
        }

        public new SelectActualWorkdayResult Error(eErrorCode errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }

        [Description("Liste der Tagesistwerte der Mitarbeiter")]
        public List<DataActualWorkday> ActualWorkdays { set; get; }
    }
}
