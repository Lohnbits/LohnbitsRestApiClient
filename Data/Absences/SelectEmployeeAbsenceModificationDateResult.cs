using System.Collections.Generic;
using System.ComponentModel;

namespace gv3kServerFibuLohn.Api.Data.Absences
{
    public class SelectEmployeeAbsenceModificationDateResult : BaseResult
    {
        public SelectEmployeeAbsenceModificationDateResult()
        {
            AbsenceModificationDates = new List<DataEmployeeAbsenceModificationDate>();
        }

        public new SelectEmployeeAbsenceModificationDateResult Error(eErrorCode errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }

        [Description("Liste der letzten Änderungen der Mitarbeiterabwesenheiten")]
        public List<DataEmployeeAbsenceModificationDate> AbsenceModificationDates { set; get; }
    }
}
