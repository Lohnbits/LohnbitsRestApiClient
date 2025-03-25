namespace gv3kServerFibuLohn.Api.Data.MonthlyData
{
    public class CloseMonthlyDataResult : BaseResult
    {
        public CloseMonthlyDataResult()
        {
            ;
        }

        public new CloseMonthlyDataResult Error(eErrorCode errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }
    }
}
