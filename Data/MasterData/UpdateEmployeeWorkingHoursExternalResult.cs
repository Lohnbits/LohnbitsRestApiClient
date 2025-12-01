namespace gv3kServerFibuLohn.Api.Data.MasterData
{
    public class UpdateEmployeeWorkingHoursExternalResult : BaseResult
    {
        public UpdateEmployeeWorkingHoursExternalResult()
        {
            ;
        }

        public new UpdateEmployeeWorkingHoursExternalResult Error(eErrorCode errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }
    }
}

