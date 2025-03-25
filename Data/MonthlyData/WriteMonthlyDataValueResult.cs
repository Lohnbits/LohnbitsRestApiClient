namespace gv3kServerFibuLohn.Api.Data.MonthlyData
{
    public class WriteMonthlyDataValueResult : BaseResult
    {
        public WriteMonthlyDataValueResult()
        {
            ;
        }

        public new WriteMonthlyDataValueResult Error(eErrorCode errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }
    }
}
