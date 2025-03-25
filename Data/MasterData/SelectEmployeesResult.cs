using System.Collections.Generic;
using System.ComponentModel;

#nullable enable

namespace gv3kServerFibuLohn.Api.Data.MasterData
{
    public class SelectEmployeesResult : BaseResult
    {
        public SelectEmployeesResult()
        {
            Employees = new List<DataEmployee>();
        }

        public new SelectEmployeesResult Error(eErrorCode errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }

        [Description("List der zurückgelieferten Mitarbeiter")]
        public List<DataEmployee> Employees { set; get; }
    }
}