using System.Collections.Generic;
using System.ComponentModel;

#nullable enable

namespace gv3kServerFibuLohn.Api.Data.TimeRecording
{
    /// <summary>
    /// schreibt die Sollwerte (Basis: DataZeiterfassungApiTagSoll) für beliebig viele Mitarbeitende und Tage eines Mandanten;
    /// der Mandant wird einmal im Kopf angegeben, Mitarbeiter und Tag je Eintrag in TargetWorkdays
    /// </summary>
    public class UpdateTargetWorkdayRequest : IMandantRequest, ITransactionId
    {
        public UpdateTargetWorkdayRequest()
        {
            LohnbitsSyncApiLogLfdNr = 0;

            ClientNumber = null;
            ClientId = null;
            ClientGroupId = null;
            TransactionId = string.Empty;

            TargetWorkdays = new List<UpdateTargetWorkdayEntry>();
        }

        [Description("Identifikationsnummer des Aufrufprotokolls. Wird nur für interne Zwecke benötigt und darf nicht manuell vergeben werden.")]
        public int LohnbitsSyncApiLogLfdNr { set; get; }

        [Description("Entweder wird `clientNumber` oder `clientId` angegeben, um die Mitarbeiter einem Mandanten zuzuordnen.")]
        public int? ClientNumber { set; get; }

        [Description("Identifikationsnummer des Mandanten. Für weitere Informationen siehe `clientNumber`")]
        public int? ClientId { set; get; }

        [Description("Identifikationsnummer der Mandantengruppe. Wird für diesen Aufruf zur Zeit nicht unterstützt.")]
        public int? ClientGroupId { set; get; }

        [Description("Identifikationsnummer der durchführenden Transaktion.")]
        public string TransactionId { set; get; }

        /// <summary>
        /// die zu schreibenden Tagessollwerte; jeder Eintrag benennt Mitarbeiter und Tag selbst
        /// </summary>
        [Description("Liste der zu schreibenden Tagessollwerte. Jeder Eintrag enthält die Mitarbeiternummer und den Tag. " +
            "Ist für Mitarbeiter und Tag bereits ein Sollwert vorhanden, wird er vollständig überschrieben, sonst neu angelegt. " +
            "Kommen Mitarbeiter und Tag mehrfach vor, gilt der letzte Eintrag. Der früheste und der späteste Tag dürfen höchstens 3 Jahre auseinanderliegen. " +
            "Die Einträge werden einzeln verarbeitet; das Ergebnis je Eintrag steht in `targetWorkdays` der Antwort.")]
        public List<UpdateTargetWorkdayEntry> TargetWorkdays { set; get; }
    }
}
