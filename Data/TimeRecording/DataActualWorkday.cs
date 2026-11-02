#nullable enable

using System;
using System.ComponentModel;

namespace gv3kServerFibuLohn.Api.Data.TimeRecording
{
    /// <summary>
    /// die Istwerte eines Mitarbeitenden für einen Tag; API-Abbild von DataZeiterfassungApiTagIst
    ///
    /// Alle Dauern werden in Stunden als decimal geführt (Industriestunden: 8,5 = 8 Stunden 30 Minuten).
    /// Die Uhrzeitfelder tragen das tatsächliche Kalenderdatum, da Schichten über Mitternacht gehen können.
    /// Account01Value bis Account20Value entsprechen eArtKonto.Konto01 bis eArtKonto.Konto20; Einheit und
    /// Bezeichnung der Konten legt das Zeiterfassungsmodell fest (DataZeiterfassungApiModel).
    /// </summary>
    public class DataActualWorkday
    {
        public DataActualWorkday()
        {
            Id = 0;
            ClientId = 0;
            EmployeeId = 0;
            ClientNumber = 0;
            PersonnelNumber = 0;
            CompanyPersonnelNumber = "";
            TimeTrackingPersonnelNumber = "";
            Date = DateTime.MinValue;
            ActualWorkingHours = 0;
            ActualBreakHours = 0;
            PayrollExportHours = 0;
            PayrollExportDays = 0;
            FirstClockIn = DateTime.MinValue;
            LastClockOut = DateTime.MinValue;
            OvertimeAccountBalance = 0;
            Account01Value = 0;
            Account02Value = 0;
            Account03Value = 0;
            Account04Value = 0;
            Account05Value = 0;
            Account06Value = 0;
            Account07Value = 0;
            Account08Value = 0;
            Account09Value = 0;
            Account10Value = 0;
            Account11Value = 0;
            Account12Value = 0;
            Account13Value = 0;
            Account14Value = 0;
            Account15Value = 0;
            Account16Value = 0;
            Account17Value = 0;
            Account18Value = 0;
            Account19Value = 0;
            Account20Value = 0;
            Remark = "";
        }

        /// <summary>
        /// DataZeiterfassungApiTagIst.ZeiterfassungApiTagIstLfdNr
        /// </summary>
        [Description("Identifikationsnummer des Tagesistwerts")]
        public int Id { get; set; }

        /// <summary>
        /// DataZeiterfassungApiTagIst.FkMandantLfdNr
        /// </summary>
        [Description("Identifikationsnummer des Mandanten")]
        public int ClientId { get; set; }

        /// <summary>
        /// DataZeiterfassungApiTagIst.FkInternetMandantLohnMitarbeiterLfdNr
        /// </summary>
        [Description("Identifikationsnummer des Mitarbeiters")]
        public int EmployeeId { get; set; }

        [Description("Mandantennummer")]
        public int ClientNumber { get; set; }

        [Description("Numerische Mitarbeiternummer in DATEV.")]
        public int PersonnelNumber { get; set; }

        [Description("Alternative alphanumerische Mitarbeiternummer in DATEV.")]
        public string CompanyPersonnelNumber { get; set; }

        [Description("Mitarbeiternummer in der Zeiterfassung.")]
        public string TimeTrackingPersonnelNumber { set; get; }

        /// <summary>
        /// der Tag, dem die Istwerte zugeordnet sind (DataZeiterfassungApiTagIst.Datum)
        /// </summary>
        [Description("Tag, dem die Istwerte zugeordnet sind")]
        public DateTime Date { set; get; }

        /// <summary>
        /// DataZeiterfassungApiTagIst.ArbeitszeitIst
        /// </summary>
        [Description("Ist-Arbeitszeit des Mitarbeiters an diesem Tag in Stunden und Industrieminuten.")]
        public decimal ActualWorkingHours { set; get; }

        /// <summary>
        /// DataZeiterfassungApiTagIst.PauseIst
        /// </summary>
        [Description("Ist-Pause des Mitarbeiters an diesem Tag in Stunden und Industrieminuten.")]
        public decimal ActualBreakHours { set; get; }

        /// <summary>
        /// die Anzahl der Stunden für die Kalendererfassung DATEV (DataZeiterfassungApiTagIst.LohnExportStunden)
        /// </summary>
        [Description("Anzahl der Stunden für die Kalendererfassung in DATEV, in Stunden und Industrieminuten.")]
        public decimal PayrollExportHours { set; get; }

        /// <summary>
        /// die Anzahl der Tage für die Kalendererfassung DATEV (DataZeiterfassungApiTagIst.LohnExportTage)
        /// </summary>
        [Description("Anzahl der Tage für die Kalendererfassung in DATEV.")]
        public decimal PayrollExportDays { set; get; }

        /// <summary>
        /// DataZeiterfassungApiTagIst.ErstesKommen
        /// </summary>
        [Description("Erstes Kommen an diesem Tag (Datum und Uhrzeit). `0001-01-01T00:00:00` = kein Kommen.")]
        public DateTime FirstClockIn { set; get; }

        /// <summary>
        /// DataZeiterfassungApiTagIst.LetztesGehen
        /// </summary>
        [Description("Letztes Gehen an diesem Tag (Datum und Uhrzeit). Bei Schichten über Mitternacht kann das Datum auf den Folgetag fallen. `0001-01-01T00:00:00` = kein Gehen.")]
        public DateTime LastClockOut { set; get; }

        /// <summary>
        /// DataZeiterfassungApiTagIst.SaldoUeberstundenkonto
        /// </summary>
        [Description("Saldo des Überstundenkontos am Ende dieses Tages in Stunden und Industrieminuten.")]
        public decimal OvertimeAccountBalance { set; get; }

        /// <summary>
        /// DataZeiterfassungApiTagIst.WertKonto01 (eArtKonto.Konto01)
        /// </summary>
        [Description("Wert des Kontos 1 an diesem Tag. " + AccountHinweis)]
        public decimal Account01Value { set; get; }

        /// <summary>
        /// DataZeiterfassungApiTagIst.WertKonto02 (eArtKonto.Konto02)
        /// </summary>
        [Description("Wert des Kontos 2 an diesem Tag. " + AccountHinweis)]
        public decimal Account02Value { set; get; }

        /// <summary>
        /// DataZeiterfassungApiTagIst.WertKonto03 (eArtKonto.Konto03)
        /// </summary>
        [Description("Wert des Kontos 3 an diesem Tag. " + AccountHinweis)]
        public decimal Account03Value { set; get; }

        /// <summary>
        /// DataZeiterfassungApiTagIst.WertKonto04 (eArtKonto.Konto04)
        /// </summary>
        [Description("Wert des Kontos 4 an diesem Tag. " + AccountHinweis)]
        public decimal Account04Value { set; get; }

        /// <summary>
        /// DataZeiterfassungApiTagIst.WertKonto05 (eArtKonto.Konto05)
        /// </summary>
        [Description("Wert des Kontos 5 an diesem Tag. " + AccountHinweis)]
        public decimal Account05Value { set; get; }

        /// <summary>
        /// DataZeiterfassungApiTagIst.WertKonto06 (eArtKonto.Konto06)
        /// </summary>
        [Description("Wert des Kontos 6 an diesem Tag. " + AccountHinweis)]
        public decimal Account06Value { set; get; }

        /// <summary>
        /// DataZeiterfassungApiTagIst.WertKonto07 (eArtKonto.Konto07)
        /// </summary>
        [Description("Wert des Kontos 7 an diesem Tag. " + AccountHinweis)]
        public decimal Account07Value { set; get; }

        /// <summary>
        /// DataZeiterfassungApiTagIst.WertKonto08 (eArtKonto.Konto08)
        /// </summary>
        [Description("Wert des Kontos 8 an diesem Tag. " + AccountHinweis)]
        public decimal Account08Value { set; get; }

        /// <summary>
        /// DataZeiterfassungApiTagIst.WertKonto09 (eArtKonto.Konto09)
        /// </summary>
        [Description("Wert des Kontos 9 an diesem Tag. " + AccountHinweis)]
        public decimal Account09Value { set; get; }

        /// <summary>
        /// DataZeiterfassungApiTagIst.WertKonto10 (eArtKonto.Konto10)
        /// </summary>
        [Description("Wert des Kontos 10 an diesem Tag. " + AccountHinweis)]
        public decimal Account10Value { set; get; }

        /// <summary>
        /// DataZeiterfassungApiTagIst.WertKonto11 (eArtKonto.Konto11)
        /// </summary>
        [Description("Wert des Kontos 11 an diesem Tag. " + AccountHinweis)]
        public decimal Account11Value { set; get; }

        /// <summary>
        /// DataZeiterfassungApiTagIst.WertKonto12 (eArtKonto.Konto12)
        /// </summary>
        [Description("Wert des Kontos 12 an diesem Tag. " + AccountHinweis)]
        public decimal Account12Value { set; get; }

        /// <summary>
        /// DataZeiterfassungApiTagIst.WertKonto13 (eArtKonto.Konto13)
        /// </summary>
        [Description("Wert des Kontos 13 an diesem Tag. " + AccountHinweis)]
        public decimal Account13Value { set; get; }

        /// <summary>
        /// DataZeiterfassungApiTagIst.WertKonto14 (eArtKonto.Konto14)
        /// </summary>
        [Description("Wert des Kontos 14 an diesem Tag. " + AccountHinweis)]
        public decimal Account14Value { set; get; }

        /// <summary>
        /// DataZeiterfassungApiTagIst.WertKonto15 (eArtKonto.Konto15)
        /// </summary>
        [Description("Wert des Kontos 15 an diesem Tag. " + AccountHinweis)]
        public decimal Account15Value { set; get; }

        /// <summary>
        /// DataZeiterfassungApiTagIst.WertKonto16 (eArtKonto.Konto16)
        /// </summary>
        [Description("Wert des Kontos 16 an diesem Tag. " + AccountHinweis)]
        public decimal Account16Value { set; get; }

        /// <summary>
        /// DataZeiterfassungApiTagIst.WertKonto17 (eArtKonto.Konto17)
        /// </summary>
        [Description("Wert des Kontos 17 an diesem Tag. " + AccountHinweis)]
        public decimal Account17Value { set; get; }

        /// <summary>
        /// DataZeiterfassungApiTagIst.WertKonto18 (eArtKonto.Konto18)
        /// </summary>
        [Description("Wert des Kontos 18 an diesem Tag. " + AccountHinweis)]
        public decimal Account18Value { set; get; }

        /// <summary>
        /// DataZeiterfassungApiTagIst.WertKonto19 (eArtKonto.Konto19)
        /// </summary>
        [Description("Wert des Kontos 19 an diesem Tag. " + AccountHinweis)]
        public decimal Account19Value { set; get; }

        /// <summary>
        /// DataZeiterfassungApiTagIst.WertKonto20 (eArtKonto.Konto20)
        /// </summary>
        [Description("Wert des Kontos 20 an diesem Tag. " + AccountHinweis)]
        public decimal Account20Value { set; get; }

        /// <summary>
        /// DataZeiterfassungApiTagIst.Bemerkung
        /// </summary>
        [Description("Bemerkung zu diesem Tag")]
        public string Remark { set; get; }

        /// <summary>
        /// Hinweis für die OpenAPI-Spezifikation: Account01Value bis Account20Value entsprechen eArtKonto.Konto01 bis Konto20
        /// des Zeiterfassungsmodells (DataZeiterfassungApiModel)
        /// </summary>
        public const string AccountHinweis = "Einheit und Bezeichnung des Kontos sind im Zeiterfassungsmodell des Mandanten festgelegt.";
    }
}
