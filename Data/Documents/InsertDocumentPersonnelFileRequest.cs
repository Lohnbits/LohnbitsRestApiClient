using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

#nullable enable

namespace gv3kServerFibuLohn.Api.Data.Documents
{
    public class InsertDocumentPersonnelFileRequest : IMandantMitarbeiterRequest, ITransactionId
    {
        public InsertDocumentPersonnelFileRequest()
        {
            LohnbitsSyncApiLogLfdNr = 0;

            ClientNumber = null;
            ClientId = null;
            ClientGroupId = null;
            PersonnelNumber = null;
            CompanyPersonnelNumber = null;
            TimeTrackingPersonnelNumber = null;
            EmployeeId = null;
            TransactionId = string.Empty;
            Note = string.Empty;
            Content = null;
            FileFormat = null;
            FileName = null;
            DocumentDate = DateTime.MinValue;
            IsOldVersion = false;
            IsOnlyForPersonnelFile = false;
            IsHighPriority = false;
            DocumentTypeId = 0;
            MonthlyRecordingPeriod = null;
            PeriodAssignment = null;
        }

        [Description("Identifikationsnummer des Aufrufprotokolls. Wird nur für interne Zwecke benötigt und darf nicht manuell vergeben werden.")]
        public int LohnbitsSyncApiLogLfdNr { set; get; }

        [Description("Entweder wird `clientNumber` oder `clientId` angegeben, um einen Mitarbeiter einem Mandanten zuzuordnen.Soweit die Werte eindeutig sind, ist es auch möglich, `clientGroupId` und eine eindeutige Mitarbeiternummer (`personnelNumber`, `companyPersonnelNumber` oder `timeTrackingPersonnelNumber`) anzugeben")]
        public int? ClientNumber { set; get; }

        [Description("Identifikationsnummer des Mandanten. Für weitere Informationen siehe `clientNumber`")]
        public int? ClientId { set; get; }

        [Description("Identifikationsnummer der Mandantengruppe. Für weitere Informationen siehe `clientNumber`")]
        public int? ClientGroupId { set; get; }

        [Description("Numerische Mitarbeiternummer in DATEV. Diese Nummer muss eindeutig sein.")]
        public int? PersonnelNumber { set; get; }

        [Description("Alternative alphanumerische Mitarbeiternummer in DATEV. Nur verwenden wenn das Feld ohnehin verwendet wird.")]
        public string? CompanyPersonnelNumber { set; get; }

        [Description("Sollten die Mitarbeiternummern in der Zeiterfassung von den Mitarbeiternummern in DATEV abweichen, soll dieses Feld genutzt werden.")]
        public string? TimeTrackingPersonnelNumber { set; get; }

        [Description("Identifikationsnummer des Mitarbeiters.")]
        public int? EmployeeId { set; get; }

        [Description("Identifikationsnummer der durchführenden Transaktion.")]
        public string TransactionId { set; get; }

        [Description("Bemerkung")]
        public string Note { set; get; }

        [Description("Optionaler Dateiname des Dokuments")]
        public string? FileName { set; get; }

        [Description("Format der beigefügten Datei. Folgende Formate sind zulässig:\n" +
            "* PDF\n" +
            "* TIFF\n" +
            "* JPG\n" +
            "* PNG\n\n" +
            "Das präferierte Dateiformat ist PDF.")]
        public string? FileFormat { set; get; }

        [Description("Belegdatum des Dokuments")]
        public DateTime DocumentDate { set; get; }

        [Description("Abrechnungszeitraum, für welchen das Dokument berücksichtigt werden soll.")]
        public DateTime? MonthlyRecordingPeriod { set; get; }

        [Description("Diesem Zeitraum soll das Dokument zugordnet werden.\n\n" +
            "__Beispiel__: Ein Arbeitsvertrag, der ab dem 1. Januar 2024 gültig ist, wird am 15. Dezember 2023 unterschrieben. Dann ist DatumDokument der 15. Dezember 2023 und ZeitraumZuordnung der 1. Januar 2024.")]
        public DateTime? PeriodAssignment { set; get; }

        [Description("Identifikationsnummer des Dokumenttyps. Gültige Dokumenttypen können mit `selectDocumentTypes` abgefragt werden")]
        public int DocumentTypeId { set; get; }

        [Description("Beschreibt ob es sich um eine alte Version des Dokuments handelt, welches nur zu Archivierungszwecken hochgeladen wird.")]
        public bool IsOldVersion { set; get; }

        [Description("Beschreibt ob das Dokument nur für die Personalakte bestimmt ist und nicht für die Monatsdaten erfasst werden soll.")]
        public bool IsOnlyForPersonnelFile { set; get; }

        [Description("Beschreibt ob das Dokument außerhalb der normalen Lohnabrechnung schnellstmöglich bearbeitet werden soll.")]
        public bool IsHighPriority { set; get; }

        [Description("Inhalt des Dokuments als Byte-Array")]
        public byte[]? Content { set; get; }
    }
}
