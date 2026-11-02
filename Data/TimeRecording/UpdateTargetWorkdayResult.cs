using System.Collections.Generic;
using System.ComponentModel;

namespace gv3kServerFibuLohn.Api.Data.TimeRecording
{
    public class UpdateTargetWorkdayResult : BaseResult
    {
        public UpdateTargetWorkdayResult()
        {
            TargetWorkdays = new List<UpdateTargetWorkdayEntryResult>();
        }

        public new UpdateTargetWorkdayResult Error(eErrorCode errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }

        /// <summary>
        /// je Eintrag aus UpdateTargetWorkdayRequest.TargetWorkdays ein Ergebnis in derselben Reihenfolge
        /// </summary>
        [Description("Ergebnis je Eintrag aus `targetWorkdays` des Requests, in derselben Reihenfolge. " +
            "`errorCode` im Kopf betrifft nur Fehler, die den ganzen Aufruf verhindern (z. B. Login, Mandant).")]
        public List<UpdateTargetWorkdayEntryResult> TargetWorkdays { set; get; }
    }
}
