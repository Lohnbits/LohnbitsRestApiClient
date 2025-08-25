#nullable enable

using System.ComponentModel;
using System.Text.Json.Serialization;

namespace gv3kServerFibuLohn.Api.Data.Absences
{
    public class DataEmployeeAbsenceBalance
    {
        public DataEmployeeAbsenceBalance()
        {
            ClientId = 0;
            ClientNumber = 0;
            EmployeeId = 0;
            PersonnelNumber = 0;
            CompanyPersonnelNumber = "";
            TimeTrackingPersonnelNumber = "";

            AbsenceDaysRTWToday = 0;
            SickDays = 0;
            SickDaysChildTotal = 0;
            SickDaysWithoutCertificate = 0;
            EducationalLeaveHours = 0;
            EducationalLeaveDays = 0;
            BaseLeaveHours = 0;
            BaseLeaveDays = 0;
            HomeOfficeHours = 0;
            HomeOfficeDays = 0;
            BalanceQuota01 = 0;
            BalanceQuota02 = 0;
            BalanceQuota03 = 0;
            BalanceQuota04 = 0;
            BalanceQuota05 = 0;
            DisabledLeaveHours = 0;
            DisabledLeaveDays = 0;
            SpecialLeaveTakenHours = 0;
            SpecialLeaveTakenDays = 0;
            LeaveRequestedHours = 0;
            LeaveRequestedDays = 0;
            LeaveTakenHours = 0;
            LeaveTakenDays = 0;
            LeavePlannedHours = 0;
            LeavePlannedDays = 0;
            LeaveBalanceHours = 0;
            LeaveBalanceDays = 0;
            LeaveEntitlementYearHours = 0;
            LeaveEntitlementYearDays = 0;
            LeaveEntitlementPreviousYearHours = 0;
            LeaveEntitlementPreviousYearDays = 0;
            LeaveExpiredHours = 0;
            LeaveExpiredDays = 0;
            LeaveProvisionalHours = 0;
            LeaveProvisionalDays = 0;
            AdditionalLeaveHours = 0;
            AdditionalLeaveDays = 0;
            QuotaDescription01 = "";
            QuotaDescription02 = "";
            QuotaDescription03 = "";
            QuotaDescription04 = "";
            QuotaDescription05 = "";
        }

        [Description("Identifikationsnummer des Mandanten")]
        public int ClientId { get; set; }

        [Description("Identifikationsnummer des Mitarbeiters")]
        public int EmployeeId { get; set; }

        [Description("Mandantennummer")]
        public int ClientNumber { get; set; }

        [Description("Numerische Mitarbeiternummer in DATEV.")]
        public int PersonnelNumber { get; set; }

        [Description("Alternative alphanumerische Mitarbeiternummer in DATEV.")]
        public string CompanyPersonnelNumber { get; set; }

        [Description("Identifikationsnummer des Mitarbeiters.")]
        public string TimeTrackingPersonnelNumber { set; get; }

        [Description("Anzahl der Krankheitstage.")]
        public decimal SickDays { set; get; }

        [Description("Anzahl der Krankheitstage ohne Bescheinigung.")]
        public decimal SickDaysWithoutCertificate { set; get; }

        [Description("Anzahl der Krankheitstage, wenn das Kind krank ist.")]
        public decimal SickDaysChildTotal { set; get; }

        [Description("Anzahl der Tage für Bildungsurlaub.")]
        public decimal EducationalLeaveDays { set; get; }

        [Description("Anzahl der Stunden für Bildungsurlaub.")]
        public decimal EducationalLeaveHours { set; get; }

        [Description("Anzahl der Tage im Homeoffice.")]
        public decimal HomeOfficeDays { set; get; }

        [Description("Anzahl der Stunden im Homeoffice.")]
        public decimal HomeOfficeHours { set; get; }

        [Description("Anzahl der genommenen Sonderurlaubstage.")]
        public decimal SpecialLeaveTakenDays { set; get; }

        [Description("Urlaubsanspruch des Jahres in Tagen.")]
        public decimal LeaveEntitlementYearDays { set; get; }

        [Description("Urlaubsanspruch des Vorjahres in Tagen.")]
        public decimal LeaveEntitlementPreviousYearDays { set; get; }

        [Description("Anzahl der genommenen Urlaubstage.")]
        public decimal LeaveTakenDays { set; get; }

        [Description("Anzahl der geplanten Urlaubstage.")]
        public decimal LeavePlannedDays { set; get; }

        [Description("Anzahl der beantragten Urlaubstage.")]
        public decimal LeaveRequestedDays { set; get; }

        [Description("Anzahl der vorläufigen Urlaubstage.")]
        public decimal LeaveProvisionalDays { set; get; }

        [Description("Anzahl der vorläufigen Urlaubsstunden.")]
        public decimal LeaveProvisionalHours { set; get; }

        [Description("Anzahl der verfallenen Urlaubstage.")]
        public decimal LeaveExpiredDays { set; get; }

        [Description("Urlaub für das Folgejahr in Tagen.")]
        public decimal LeaveNextYearDays { set; get; }

        [Description("Urlaubssaldo in Tagen.")]
        public decimal LeaveBalanceDays { set; get; }

        [Description("Anzahl der genommenen Sonderurlaubsstunden.")]
        public decimal SpecialLeaveTakenHours { set; get; }

        [Description("Urlaubsanspruch des Jahres in Stunden.")]
        public decimal LeaveEntitlementYearHours { set; get; }

        [Description("Urlaubsanspruch des Vorjahres in Stunden.")]
        public decimal LeaveEntitlementPreviousYearHours { set; get; }

        [Description("Anzahl der genommenen Urlaubsstunden.")]
        public decimal LeaveTakenHours { set; get; }

        [Description("Anzahl der geplanten Urlaubsstunden.")]
        public decimal LeavePlannedHours { set; get; }

        [Description("Anzahl der beantragten Urlaubsstunden.")]
        public decimal LeaveRequestedHours { set; get; }

        [Description("Anzahl der verfallenen Urlaubsstunden.")]
        public decimal LeaveExpiredHours { set; get; }

        [Description("Urlaub für das Folgejahr in Stunden.")]
        public decimal LeaveNextYearHours { set; get; }

        [Description("Urlaubssaldo in Stunden.")]
        public decimal LeaveBalanceHours { set; get; }

        [Description("Saldo des Kontingents 01.")]
        public decimal BalanceQuota01 { set; get; }

        [Description("Saldo des Kontingents 02.")]
        public decimal BalanceQuota02 { set; get; }

        [Description("Saldo des Kontingents 03.")]
        public decimal BalanceQuota03 { set; get; }

        [Description("Saldo des Kontingents 04.")]
        public decimal BalanceQuota04 { set; get; }

        [Description("Saldo des Kontingents 05.")]
        public decimal BalanceQuota05 { set; get; }

        [Description("Anzahl der Abwesenheitstage heute im Rahmen des Betrieblichen Eingliederungsmanagements (RTW: Return to Work).")]
        public decimal AbsenceDaysRTWToday { set; get; }

        [JsonIgnore]
        public decimal TotalDays => BaseLeaveDays + AdditionalLeaveDays + DisabledLeaveDays;

        [JsonIgnore]
        public decimal TotalHours => BaseLeaveHours + AdditionalLeaveHours + DisabledLeaveHours;

        [Description("Anzahl der Grundurlaubstage.")]
        public decimal BaseLeaveDays { set; get; }

        [Description("Anzahl der Zusatzurlaubstage.")]
        public decimal AdditionalLeaveDays { set; get; }

        [Description("Anzahl der Schwerbehindertenurlaubstage.")]
        public decimal DisabledLeaveDays { set; get; }

        [Description("Anzahl der Grundurlaubsstunden.")]
        public decimal BaseLeaveHours { set; get; }

        [Description("Anzahl der Zusatzurlaubsstunden.")]
        public decimal AdditionalLeaveHours { set; get; }

        [Description("Anzahl der Schwerbehindertenurlaubsstunden.")]
        public decimal DisabledLeaveHours { set; get; }

        [Description("Bezeichnung des Kontingents 01.")]
        public string QuotaDescription01 { set; get; }

        [Description("Bezeichnung des Kontingents 02.")]
        public string QuotaDescription02 { set; get; }

        [Description("Bezeichnung des Kontingents 03.")]
        public string QuotaDescription03 { set; get; }

        [Description("Bezeichnung des Kontingents 04.")]
        public string QuotaDescription04 { set; get; }

        [Description("Bezeichnung des Kontingents 05.")]
        public string QuotaDescription05 { set; get; }
    }
}
