using System.ComponentModel;

#nullable enable

namespace gv3kServerFibuLohn.Api.Data
{
    public interface IMitarbeiterRequest
    {
        [Description("Numerische Mitarbeiternummer in DATEV. Diese Nummer muss eindeutig sein.")]
        public int? PersonnelNumber { set; get; }

        [Description("Alternative alphanumerische Mitarbeiternummer in DATEV. Nur verwenden wenn das Feld ohnehin verwendet wird.")]
        public string? CompanyPersonnelNumber { set; get; }

        [Description("Sollten die Mitarbeiternummern in der Zeiterfassung von den Mitarbeiternummern in DATEV abweichen, soll dieses Feld genutzt werden.")]
        public string? TimeTrackingPersonnelNumber { set; get; }

        [Description("Identifikationsnummer des Mitarbeiters. Die Nummer wird von Lohnbits vergeben.")]
        public int? EmployeeId { set; get; }
    }
}
