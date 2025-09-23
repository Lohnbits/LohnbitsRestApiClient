namespace gv3kServerFibuLohn.Api.Data.Absences
{
    public class InsertEmployeeAbsenceAdjustmentResult : BaseResult
    {
        public InsertEmployeeAbsenceAdjustmentResult()
        {
            ;
        }

        public new InsertEmployeeAbsenceAdjustmentResult Error(eErrorCode errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }
    }
}