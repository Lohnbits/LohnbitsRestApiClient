using System;
using System.Collections.Generic;
using System.ComponentModel;
using eHolidayCompanyVacationType = gv3kServerFibuLohn.Api.Data.TimeRecording.DataTargetWorkday.eHolidayCompanyVacationType;

#nullable enable

namespace gv3kServerFibuLohn.Api.Data.TimeRecording
{
    /// <summary>
    /// ein Eintrag in UpdateTargetWorkdayRequest.TargetWorkdays: die Sollwerte eines Mitarbeitenden für einen Tag
    /// (Basis: DataZeiterfassungApiTagSoll); ist für den Tag bereits ein Sollwert vorhanden, wird er vollständig
    /// überschrieben, sonst neu angelegt
    ///
    /// WICHTIG: Ob TargetWorkingHours und HolidayCompanyVacationType ausgewertet werden, hängt von der Konfiguration
    /// der Integrationen ab (DataLohnbitsIntegrationGrundeinstellungen.QuelleArbeitszeit bzw. QuelleFeiertageBetriebsurlaub
    /// == eDatenquelle.LohnbitsApi, jeweils ab dem Gültig-ab-Datum); gespeichert werden die Werte in jedem Fall.
    ///
    /// Alle Dauern werden in Stunden als decimal geführt (Industriestunden: 8,5 = 8 Stunden 30 Minuten).
    /// Die Uhrzeitfelder tragen das tatsächliche Kalenderdatum, da Schichten über Mitternacht gehen können.
    /// </summary>
    public class UpdateTargetWorkdayEntry : IMitarbeiterRequest
    {
        public UpdateTargetWorkdayEntry()
        {
            PersonnelNumber = null;
            CompanyPersonnelNumber = null;
            TimeTrackingPersonnelNumber = null;
            EmployeeId = null;

            Date = DateTime.MinValue;
            TargetWorkingHours = 0;
            HolidayCompanyVacationType = eHolidayCompanyVacationType.None;
            HolidayCompanyVacationNameOverride = "";
            RemainingTimeDisplayCorrection = 0;
            WorkingTimeFrameBegin = DateTime.MinValue;
            WorkingTimeFrameEnd = DateTime.MinValue;
            FixedBreak1Begin = DateTime.MinValue;
            FixedBreak1End = DateTime.MinValue;
            FixedBreak2Begin = DateTime.MinValue;
            FixedBreak2End = DateTime.MinValue;
            FixedBreak3Begin = DateTime.MinValue;
            FixedBreak3End = DateTime.MinValue;
            RelativeBreak1AfterHours = 0;
            RelativeBreak1DurationHours = 0;
            RelativeBreak2AfterHours = 0;
            RelativeBreak2DurationHours = 0;
            RelativeBreak3AfterHours = 0;
            RelativeBreak3DurationHours = 0;
            SelectableCostCenters = new List<string>();
        }

        [Description("Numerische Mitarbeiternummer in DATEV. Diese Nummer muss eindeutig sein.")]
        public int? PersonnelNumber { set; get; }

        [Description("Alternative alphanumerische Mitarbeiternummer in DATEV. Nur verwenden wenn das Feld ohnehin verwendet wird.")]
        public string? CompanyPersonnelNumber { set; get; }

        [Description("Sollten die Mitarbeiternummern in der Zeiterfassung von den Mitarbeiternummern in DATEV abweichen, soll dieses Feld genutzt werden.")]
        public string? TimeTrackingPersonnelNumber { set; get; }

        [Description("Identifikationsnummer des Mitarbeiters.")]
        public int? EmployeeId { set; get; }

        /// <summary>
        /// der Tag, dem die Sollwerte zugeordnet sind (DataZeiterfassungApiTagSoll.Datum)
        /// </summary>
        [Description("Tag, dem die Sollwerte zugeordnet sind. Die Uhrzeit wird ignoriert.")]
        public DateTime Date { set; get; }

        /// <summary>
        /// die Soll-Arbeitszeit in Stunden (DataZeiterfassungApiTagSoll.ArbeitszeitSoll)
        /// </summary>
        [Description("Soll-Arbeitszeit des Mitarbeiters an diesem Tag in Stunden und Industrieminuten. " + DataTargetWorkday.TargetWorkingHoursHinweis)]
        public decimal TargetWorkingHours { set; get; }

        /// <summary>
        /// Feiertag bzw. Betriebsurlaub ganztags oder halbtags (DataZeiterfassungApiTagSoll.ArtFeiertagBetriebsurlaub)
        /// </summary>
        [Description("Art des Feiertags bzw. Betriebsurlaubs an diesem Tag: `None` = kein Feiertag/Betriebsurlaub, `FullDay` = ganztags, `Morning` = nur vormittags, `Afternoon` = nur nachmittags. " + DataTargetWorkday.HolidayCompanyVacationHinweis)]
        public eHolidayCompanyVacationType HolidayCompanyVacationType { set; get; }

        /// <summary>
        /// abweichende Bezeichnung des Feiertags bzw. Betriebsurlaubs (DataZeiterfassungApiTagSoll.BezeichnungFeiertagBetriebsurlaubAbweichend)
        /// </summary>
        [Description("Abweichende Bezeichnung des Feiertags bzw. Betriebsurlaubs. Leer = Standardbezeichnung. " + DataTargetWorkday.HolidayCompanyVacationHinweis)]
        public string? HolidayCompanyVacationNameOverride { set; get; }

        /// <summary>
        /// wird in Stunden auf die verbleibende Arbeitszeit addiert (DataZeiterfassungApiTagSoll.RestzeitanzeigeKorrektur)
        /// </summary>
        [Description("Korrektur der Restzeitanzeige am Terminal in Stunden und Industrieminuten. Der Wert wird auf die verbleibende Arbeitszeit addiert (positiv verlängert, negativ verkürzt).")]
        public decimal RemainingTimeDisplayCorrection { set; get; }

        /// <summary>
        /// vor dieser Zeit zählt die Zeit nicht; DateTime.MinValue = keine Rahmenarbeitszeit (DataZeiterfassungApiTagSoll.RahmenarbeitszeitVon)
        /// </summary>
        [Description("Beginn der Rahmenarbeitszeit (Datum und Uhrzeit). Davor geleistete Zeit zählt nicht. `0001-01-01T00:00:00` = keine Rahmenarbeitszeit, die ganze Anwesenheit zählt.")]
        public DateTime WorkingTimeFrameBegin { set; get; }

        /// <summary>
        /// nach dieser Zeit zählt die Zeit nicht (DataZeiterfassungApiTagSoll.RahmenarbeitszeitBis)
        /// </summary>
        [Description("Ende der Rahmenarbeitszeit (Datum und Uhrzeit). Danach geleistete Zeit zählt nicht.")]
        public DateTime WorkingTimeFrameEnd { set; get; }

        /// <summary>
        /// Beginn der 1. Betriebspause zu fester Uhrzeit; DateTime.MinValue = Eintrag ignorieren (DataZeiterfassungApiTagSoll.BetriebspauseAbsolut1Von)
        /// </summary>
        [Description("Beginn der 1. Betriebspause zu fester Uhrzeit (Datum und Uhrzeit). `0001-01-01T00:00:00` = diese Betriebspause gibt es nicht.")]
        public DateTime FixedBreak1Begin { set; get; }

        /// <summary>
        /// Ende der 1. Betriebspause zu fester Uhrzeit (DataZeiterfassungApiTagSoll.BetriebspauseAbsolut1Bis)
        /// </summary>
        [Description("Ende der 1. Betriebspause zu fester Uhrzeit (Datum und Uhrzeit)")]
        public DateTime FixedBreak1End { set; get; }

        /// <summary>
        /// Beginn der 2. Betriebspause zu fester Uhrzeit; DateTime.MinValue = Eintrag ignorieren (DataZeiterfassungApiTagSoll.BetriebspauseAbsolut2Von)
        /// </summary>
        [Description("Beginn der 2. Betriebspause zu fester Uhrzeit (Datum und Uhrzeit). `0001-01-01T00:00:00` = diese Betriebspause gibt es nicht.")]
        public DateTime FixedBreak2Begin { set; get; }

        /// <summary>
        /// Ende der 2. Betriebspause zu fester Uhrzeit (DataZeiterfassungApiTagSoll.BetriebspauseAbsolut2Bis)
        /// </summary>
        [Description("Ende der 2. Betriebspause zu fester Uhrzeit (Datum und Uhrzeit)")]
        public DateTime FixedBreak2End { set; get; }

        /// <summary>
        /// Beginn der 3. Betriebspause zu fester Uhrzeit; DateTime.MinValue = Eintrag ignorieren (DataZeiterfassungApiTagSoll.BetriebspauseAbsolut3Von)
        /// </summary>
        [Description("Beginn der 3. Betriebspause zu fester Uhrzeit (Datum und Uhrzeit). `0001-01-01T00:00:00` = diese Betriebspause gibt es nicht.")]
        public DateTime FixedBreak3Begin { set; get; }

        /// <summary>
        /// Ende der 3. Betriebspause zu fester Uhrzeit (DataZeiterfassungApiTagSoll.BetriebspauseAbsolut3Bis)
        /// </summary>
        [Description("Ende der 3. Betriebspause zu fester Uhrzeit (Datum und Uhrzeit)")]
        public DateTime FixedBreak3End { set; get; }

        /// <summary>
        /// die 1. Betriebspause beginnt nach so vielen Stunden Arbeitszeit (DataZeiterfassungApiTagSoll.BetriebspauseRelativ1NachStunden)
        /// </summary>
        [Description("Die 1. Betriebspause beginnt nach so vielen Stunden Arbeitszeit, gerechnet ab dem ersten Kommen ohne Pausen.")]
        public decimal RelativeBreak1AfterHours { set; get; }

        /// <summary>
        /// die Dauer der 1. Betriebspause in Stunden; 0 = Eintrag ignorieren (DataZeiterfassungApiTagSoll.BetriebspauseRelativ1DauerStunden)
        /// </summary>
        [Description("Dauer der 1. Betriebspause nach Arbeitszeit in Stunden und Industrieminuten. `0` = diese Betriebspause gibt es nicht.")]
        public decimal RelativeBreak1DurationHours { set; get; }

        /// <summary>
        /// die 2. Betriebspause beginnt nach so vielen Stunden Arbeitszeit (DataZeiterfassungApiTagSoll.BetriebspauseRelativ2NachStunden)
        /// </summary>
        [Description("Die 2. Betriebspause beginnt nach so vielen Stunden Arbeitszeit, gerechnet ab dem ersten Kommen ohne Pausen.")]
        public decimal RelativeBreak2AfterHours { set; get; }

        /// <summary>
        /// die Dauer der 2. Betriebspause in Stunden; 0 = Eintrag ignorieren (DataZeiterfassungApiTagSoll.BetriebspauseRelativ2DauerStunden)
        /// </summary>
        [Description("Dauer der 2. Betriebspause nach Arbeitszeit in Stunden und Industrieminuten. `0` = diese Betriebspause gibt es nicht.")]
        public decimal RelativeBreak2DurationHours { set; get; }

        /// <summary>
        /// die 3. Betriebspause beginnt nach so vielen Stunden Arbeitszeit (DataZeiterfassungApiTagSoll.BetriebspauseRelativ3NachStunden)
        /// </summary>
        [Description("Die 3. Betriebspause beginnt nach so vielen Stunden Arbeitszeit, gerechnet ab dem ersten Kommen ohne Pausen.")]
        public decimal RelativeBreak3AfterHours { set; get; }

        /// <summary>
        /// die Dauer der 3. Betriebspause in Stunden; 0 = Eintrag ignorieren (DataZeiterfassungApiTagSoll.BetriebspauseRelativ3DauerStunden)
        /// </summary>
        [Description("Dauer der 3. Betriebspause nach Arbeitszeit in Stunden und Industrieminuten. `0` = diese Betriebspause gibt es nicht.")]
        public decimal RelativeBreak3DurationHours { set; get; }

        /// <summary>
        /// falls der Mitarbeitende nur bestimmte Kostenstellen auswählen darf, stehen sie hier (DataZeiterfassungApiTagSoll.ListeAuswahlKostenstellen)
        /// </summary>
        [Description("Kostenstellen, die der Mitarbeiter an diesem Tag auswählen darf. Eine leere Liste bedeutet keine Einschränkung.")]
        public List<string> SelectableCostCenters { set; get; }
    }
}
