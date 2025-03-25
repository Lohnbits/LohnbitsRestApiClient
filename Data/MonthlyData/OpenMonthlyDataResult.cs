using System;
using System.ComponentModel;

#nullable enable

namespace gv3kServerFibuLohn.Api.Data.MonthlyData
{
    public class OpenMonthlyDataResult : BaseResult
    {
        public OpenMonthlyDataResult()
        {
            Id = Guid.Empty;
        }

        public new OpenMonthlyDataResult Error(eErrorCode errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }

        [Description("Identifikationsnummer der Monatsdatenerfassung. Diese Id wird benötigt um auf die neu erstellte Monatsdatenerfassung zuzugreifen.")]
        public Guid Id { get; set; }
    }
}
