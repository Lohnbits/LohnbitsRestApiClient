using System.Collections.Generic;
using System.ComponentModel;

namespace gv3kServerFibuLohn.Api.Data.Absences
{
    public class SelectEmployeeAbsenceAdjustmentResult : BaseResult
    {
        public SelectEmployeeAbsenceAdjustmentResult()
        {
            AbsenceAdjustmentss = new List<DataEmployeeAbsenceAdjustment>();
        }

        public new SelectEmployeeAbsenceAdjustmentResult Error(eErrorCode errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }

        [Description("Liste der Anpassungen der Abwesenheiten")]
        public List<DataEmployeeAbsenceAdjustment> AbsenceAdjustmentss { set; get; }
    }
}