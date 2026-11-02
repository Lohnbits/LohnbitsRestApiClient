using System.Collections.Generic;
using System.ComponentModel;

namespace gv3kServerFibuLohn.Api.Data.TimeRecording
{
    public class UpdateActualWorkdayResult : BaseResult
    {
        public UpdateActualWorkdayResult()
        {
            ActualWorkdays = new List<UpdateActualWorkdayEntryResult>();
        }

        public new UpdateActualWorkdayResult Error(eErrorCode errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }

        /// <summary>
        /// je Eintrag aus UpdateActualWorkdayRequest.ActualWorkdays ein Ergebnis in derselben Reihenfolge
        /// </summary>
        [Description("Ergebnis je Eintrag aus `actualWorkdays` des Requests, in derselben Reihenfolge. " +
            "`errorCode` im Kopf betrifft nur Fehler, die den ganzen Aufruf verhindern (z. B. Login, Mandant).")]
        public List<UpdateActualWorkdayEntryResult> ActualWorkdays { set; get; }
    }
}
