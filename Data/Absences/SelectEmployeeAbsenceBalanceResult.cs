using System.Collections.Generic;
using System.ComponentModel;

namespace gv3kServerFibuLohn.Api.Data.Absences
{
    public class SelectEmployeeAbsenceBalanceResult : BaseResult
    {
        public SelectEmployeeAbsenceBalanceResult()
        {
            AbsenceBalances = new List<DataEmployeeAbsenceBalance>();
        }

        public new SelectEmployeeAbsenceBalanceResult Error(eErrorCode errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }

        [Description("Liste der Abwesenheitssalden")]
        public List<DataEmployeeAbsenceBalance> AbsenceBalances { set; get; }
    }
}
