namespace gv3kServerFibuLohn.Api.Data.Absences
{
    public class DeleteEmployeeAbsenceResult : BaseResult
    {
        public DeleteEmployeeAbsenceResult()
        {
            ;
        }

        public new DeleteEmployeeAbsenceResult Error(eErrorCode errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }
    }
}