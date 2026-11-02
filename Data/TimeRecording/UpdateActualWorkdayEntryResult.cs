using System;
using System.ComponentModel;
using static gv3kServerFibuLohn.Api.Data.BaseResult;

namespace gv3kServerFibuLohn.Api.Data.TimeRecording
{
    /// <summary>
    /// das Ergebnis zu einem Eintrag aus UpdateActualWorkdayRequest.ActualWorkdays
    /// </summary>
    public class UpdateActualWorkdayEntryResult
    {
        public UpdateActualWorkdayEntryResult()
        {
            Index = 0;
            EmployeeId = 0;
            Date = DateTime.MinValue;
            ErrorCode = eErrorCode.None;
        }

        /// <summary>
        /// die Position des Eintrags in UpdateActualWorkdayRequest.ActualWorkdays (beginnend bei 0)
        /// </summary>
        [Description("Position des Eintrags in `actualWorkdays` des Requests (beginnend bei 0)")]
        public int Index { get; set; }

        /// <summary>
        /// DataZeiterfassungApiTagIst.FkInternetMandantLohnMitarbeiterLfdNr; 0, wenn der Mitarbeiter nicht gefunden wurde
        /// </summary>
        [Description("Identifikationsnummer des ermittelten Mitarbeiters. `0`, wenn der Mitarbeiter nicht gefunden wurde.")]
        public int EmployeeId { get; set; }

        /// <summary>
        /// der Tag des Eintrags (DataZeiterfassungApiTagIst.Datum)
        /// </summary>
        [Description("Tag des Eintrags")]
        public DateTime Date { get; set; }

        [Description("Fehlercode des Eintrags. `None`, wenn der Eintrag geschrieben wurde.")]
        public eErrorCode ErrorCode { get; set; }

        [Description("Beschreibung des aufgetretenen Fehlers")]
        public string ErrorDescription => new BaseResult { ErrorCode = ErrorCode }.ErrorDescription;
    }
}
