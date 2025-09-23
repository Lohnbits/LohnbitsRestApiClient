namespace gv3kServerFibuLohn.Api.Data.Absences
{
    public class InsertEmployeeAbsenceResult : BaseResult
    {
        public InsertEmployeeAbsenceResult()
        {
            ;
        }

        public new InsertEmployeeAbsenceResult Error(eErrorCode errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }
    }
}