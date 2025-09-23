namespace gv3kServerFibuLohn.Api.Data.Absences
{
    public class RecalcEmployeeAbsenceResult : BaseResult
    {
        public RecalcEmployeeAbsenceResult()
        {
            ;
        }

        public new RecalcEmployeeAbsenceResult Error(eErrorCode errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }
    }
}