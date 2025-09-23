namespace gv3kServerFibuLohn.Api.Data.Absences
{
    public class DeleteEmployeeAbsenceAdjustmentResult : BaseResult
    {
        public DeleteEmployeeAbsenceAdjustmentResult()
        {
            ;
        }

        public new DeleteEmployeeAbsenceAdjustmentResult Error(eErrorCode errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }
    }
}