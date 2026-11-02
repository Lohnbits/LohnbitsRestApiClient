using System;
using System.ComponentModel;
using static gv3kServerFibuLohn.Api.Data.BaseResult;

namespace gv3kServerFibuLohn.Api.Data.TimeRecording
{
    /// <summary>
    /// das Ergebnis zu einem Eintrag aus UpdateTargetWorkdayRequest.TargetWorkdays
    /// </summary>
    public class UpdateTargetWorkdayEntryResult
    {
        public UpdateTargetWorkdayEntryResult()
        {
            Index = 0;
            EmployeeId = 0;
            Date = DateTime.MinValue;
            ErrorCode = eErrorCode.None;
        }

        /// <summary>
        /// die Position des Eintrags in UpdateTargetWorkdayRequest.TargetWorkdays (beginnend bei 0)
        /// </summary>
        [Description("Position des Eintrags in `targetWorkdays` des Requests (beginnend bei 0)")]
        public int Index { get; set; }

        /// <summary>
        /// DataZeiterfassungApiTagSoll.FkInternetMandantLohnMitarbeiterLfdNr; 0, wenn der Mitarbeiter nicht gefunden wurde
        /// </summary>
        [Description("Identifikationsnummer des ermittelten Mitarbeiters. `0`, wenn der Mitarbeiter nicht gefunden wurde.")]
        public int EmployeeId { get; set; }

        /// <summary>
        /// der Tag des Eintrags (DataZeiterfassungApiTagSoll.Datum)
        /// </summary>
        [Description("Tag des Eintrags")]
        public DateTime Date { get; set; }

        [Description("Fehlercode des Eintrags. `None`, wenn der Eintrag geschrieben wurde.")]
        public eErrorCode ErrorCode { get; set; }

        [Description("Beschreibung des aufgetretenen Fehlers")]
        public string ErrorDescription => new BaseResult { ErrorCode = ErrorCode }.ErrorDescription;
    }
}
