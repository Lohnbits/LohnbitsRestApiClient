using System.Collections.Generic;
using System.ComponentModel;

#nullable enable

namespace gv3kServerFibuLohn.Api.Data.EmployeeMasterData
{
    public class SelectEmploymentPeriodsResult : BaseResult
    {
        public SelectEmploymentPeriodsResult()
        {
            EmployeesWorkingHours = [];
        }

        [Description("Liste der Arbeitszeiten der abgefragten Mitarbeiter.")]
        public List<EmployeeWorkingHours> EmployeesWorkingHours { set; get; }
    }
}

