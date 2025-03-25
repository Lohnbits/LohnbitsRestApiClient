#nullable enable

using System.ComponentModel;

namespace gv3kServerFibuLohn.Api.Data
{
    public interface IMandantMitarbeiterRequest
    {
        /// <summary>
        /// Entweder wird die Mandantennummer oder MandantLfdNr angegeben, um einen Mitarbeiter einem Mandanten zuzuordnen. 
        /// Soweit die Werte eindeutig sind, ist es auch möglich, MandantGruppeLfdNr und eine eindeutige Mitarbeiternummer
        /// (Personalnummer, PersonalnummerBetrieblich oder PersonalnummerZeiterfassung) anzugeben.
        /// </summary>
        [Description("Entweder wird `clientNumber` oder `clientId` angegeben, um einen Mitarbeiter einem Mandanten zuzuordnen.Soweit die Werte eindeutig sind, ist es auch möglich, `clientGroupId` und eine eindeutige Mitarbeiternummer (`personnelNumber`, `companyPersonnelNumber` oder `timeTrackingPersonnelNumber`) anzugeben")]
        public int? ClientNumber { set; get; }

        /// <summary>
        /// siehe Mandantennummer; der Primärschlüssel für den Mandanten in der Lohnbits-Datenbank
        /// </summary>
        [Description("Identifikationsnummer des Mandanten. Für weitere Informationen siehe `clientNumber`")]
        public int? ClientId { set; get; }

        /// <summary>
        /// siehe Mandantennummer; der Primärschlüssel für die Firmengruppe in der Lohnbits Datenbank
        /// </summary>
        [Description("Identifikationsnummer der Mandantengruppe. Für weitere Informationen siehe `clientNumber`")]
        public int? ClientGroupId { set; get; }

        /// <summary>
        /// die numerische Mitarbeiternummer in DATEV
        /// </summary>
        [Description("Numerische Mitarbeiternummer in DATEV. Diese Nummer muss eindeutig sein.")]
        public int? PersonnelNumber { set; get; }

        /// <summary>
        /// eine alphanumerische alternative Mitarbeiternummer in DATEV - soll nur genutzt werden, wenn das Feld sowieso 
        /// verwendet wird
        /// </summary>
        [Description("Alternative alphanumerische Mitarbeiternummer in DATEV. Nur verwenden wenn das Feld ohnehin verwendet wird.")]
        public string? CompanyPersonnelNumber { set; get; }

        /// <summary>
        /// falls die Mitarbeiternummern in der Zeiterfassung von den Mitarbeiternummern in DATEV abweichen, soll dieses
        /// Feld genutzt werden
        /// </summary>
        [Description("Sollten die Mitarbeiternummern in der Zeiterfassung von den Mitarbeiternummern in DATEV abweichen, soll dieses Feld genutzt werden.")]
        public string? TimeTrackingPersonnelNumber { set; get; }

        /// <summary>
        /// der Primärschlüssel für den Mitarbeiter in der Lohnbits-Datenbank
        /// </summary>
        [Description("Identifikationsnummer des Mitarbeiters. Die Nummer wird von Lohnbits vergeben.")]
        public int? EmployeeId { set; get; }
    }
}
