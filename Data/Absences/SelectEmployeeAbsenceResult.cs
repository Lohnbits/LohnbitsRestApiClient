using System.Collections.Generic;
using System.ComponentModel;

namespace gv3kServerFibuLohn.Api.Data.Absences
{
    public class SelectEmployeeAbsenceResult : BaseResult
    {
        public SelectEmployeeAbsenceResult()
        {
            Absences = new List<DataEmployeeAbsence>();
        }

        public new SelectEmployeeAbsenceResult Error(eErrorCode errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }

        [Description("Liste der Mitarbeiterabwesenheiten")]
        public List<DataEmployeeAbsence> Absences { set; get; }
    }
}