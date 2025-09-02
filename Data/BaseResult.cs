using System.ComponentModel;
using System.Text.Json.Serialization;

#nullable enable

namespace gv3kServerFibuLohn.Api.Data
{
    public class BaseResult
    {
        public BaseResult()
        {
            ErrorCode = eErrorCode.None;
            TransactionId = 0;
        }

        public BaseResult Error(eErrorCode errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }

        [Description("Fehlercode des aufgetretenen Fehlers")]
        public eErrorCode ErrorCode { get; set; }

        [Description("Identifikationsnummer der durchgeführten Transaktion")]
        public int TransactionId { get; set; }

        [Description("Http Status Code abhängig vom Fehlercode")]
        public int StatusCode
        {
            get
            {
                switch (ErrorCode)
                {
                    case eErrorCode.None:
                        return 200;
                    case eErrorCode.InvalidLogin:
                    case eErrorCode.InvalidBeaer:
                        return 401;
                    case eErrorCode.AccessDenied:
                        return 403;
                    case eErrorCode.InternalError:
                        return 500;
                    default:
                        return 400;
                }
            }
        }

        [Description("Beschreibung des aufgetretenen Fehlers")]
        public string ErrorDescription
        {
            get =>
                ErrorCode switch
                {
                    eErrorCode.None => "",
                    eErrorCode.UnknownError => "Unbekannter Fehler",
                    eErrorCode.InvalidLogin => "Ungültiger Login",
                    eErrorCode.InternalError => "Interner Fehler",
                    eErrorCode.InvalidBeaer => "Ungültiger Bearer",
                    eErrorCode.AccessDenied => "Zugriff verweigert",
                    eErrorCode.InvalidParameter => "Ungültiger Parameter",
                    eErrorCode.InvalidCustomer => "Ungültiger Kunde",
                    eErrorCode.InvalidContent => "Ungültiger Inhalt der Variable Content.",
                    eErrorCode.InvalidEmployee => "Mitarbeiter wurde nicht gefunden.",
                    eErrorCode.InvalidDocumentType => "Ungültiger Dokumenttyp",
                    eErrorCode.DocumentUploadError => "Fehler beim Hochladen des Dokuments",
                    eErrorCode.InvalidFirm => "Ungültige Firma / ungültige Firma",
                    eErrorCode.InvalidAction => "Ungültige Aktion",
                    eErrorCode.InvalidEmployeeNumber => "Die Mitarbeiternummer darf nicht vergeben werden.",
                    eErrorCode.InvalidMonthlyDataId => "Es gibt keine geöffnete Monatsdatenerfassung mit dieser GUID.",
                    eErrorCode.DocumentStorageExceeded => "Der Speicherplatz für Dokumente wurde überschritten.",
                    eErrorCode.UnableToOpenMonthlyData => "Die Monatsdatenerfassung konnte nicht geöffnet werden.",
                    eErrorCode.InvalidVariable => "Ungültige Variable.",
                    eErrorCode.InvalidCombinationVariableEmployee => "Ungültige Kombination von Variable und Mitarbeiter.",
                    eErrorCode.InvalidPeriodForMonthlyData => "Ausgewählte Monatsdatenerfassung in diesem Zeitraum nicht zulässig.",
                    eErrorCode.UnableToWriteValue => "Der Wert konnte nicht geschrieben werden.",
                    eErrorCode.ReportNotFound => "Der Bericht wurde nicht gefunden.",
                    eErrorCode.InvalidReportCode => "Ungültiger Report Code",
                    _ => "Unbekannter Fehler"
                };
        }

        /// <summary>
        /// Liste der Fehlercodes
        /// </summary>
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum eErrorCode
        {
            None,
            UnknownError,
            InvalidLogin,
            InternalError,
            InvalidBeaer,
            AccessDenied,
            InvalidParameter,
            InvalidCustomer,
            InvalidContent,
            InvalidEmployee,
            InvalidDocumentType,
            DocumentUploadError,
            InvalidFirm,
            InvalidAction,
            InvalidEmployeeNumber,
            DocumentStorageExceeded,
            UnableToOpenMonthlyData,
            InvalidMonthlyDataId,
            InvalidVariable,
            InvalidCombinationVariableEmployee,
            InvalidPeriodForMonthlyData,
            UnableToWriteValue,
            ReportNotFound,
            InvalidReportCode
        }
    }
}
