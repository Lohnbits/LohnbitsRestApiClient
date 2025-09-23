namespace gv3kServerFibuLohn.Api.Data.Absences
{
    public class UpdateEmployeeAbsenceAdjustmentResult : BaseResult
    {
        public UpdateEmployeeAbsenceAdjustmentResult()
        {
            ;
        }

        public new UpdateEmployeeAbsenceAdjustmentResult Error(eErrorCode errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }
    }
}