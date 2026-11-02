using System.Collections.Generic;
using System.ComponentModel;

namespace gv3kServerFibuLohn.Api.Data.TimeRecording
{
    public class SelectTargetWorkdayResult : BaseResult
    {
        public SelectTargetWorkdayResult()
        {
            TargetWorkdays = new List<DataTargetWorkday>();
        }

        public new SelectTargetWorkdayResult Error(eErrorCode errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }

        [Description("Liste der Tagessollwerte der Mitarbeiter")]
        public List<DataTargetWorkday> TargetWorkdays { set; get; }
    }
}
