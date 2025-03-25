using System.ComponentModel;

namespace gv3kServerFibuLohn.Api.Data.MonthlyData
{
    public class ReadMonthlyDataValueResult : BaseResult
    {
        public ReadMonthlyDataValueResult()
        {
            ValueDecimal = 0;
            ValueInteger = 0;
            ValueString = string.Empty;
            ValueBoolean = false;
            Note = string.Empty;
        }

        public new ReadMonthlyDataValueResult Error(eErrorCode errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }

        [Description("Dieser Dezimalwert wurde gespeichert. Nur dann auswerten, wenn die erwartet Variable vom Typ Decimal ist.")]
        public decimal ValueDecimal { get; set; }

        [Description("Dieser Integer wurde gespeichert. Nur dann auswerten, wenn die erwartet Variable vom Typ Integer ist.")]
        public int ValueInteger { get; set; }

        [Description("Dieser String wurde gespeichert. Nur dann auswerten, wenn die erwartet Variable vom Typ String ist.")]
        public string ValueString { get; set; }

        [Description("Dieser Boolean wurde gespeichert. Nur dann auswerten, wenn die erwartet Variable vom Typ Boolean ist.")]
        public bool ValueBoolean { get; set; }

        [Description("Optionale Bemerkung")]
        public string Note { get; set; }
    }
}





