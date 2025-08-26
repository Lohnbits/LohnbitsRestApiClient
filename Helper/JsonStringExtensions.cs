using gv3kServerFibuLohn.Api.Data.MasterData;
using gv3kServerFibuLohn.Api.Data.Reports;
using gv3kServerFibuLohn.Api.Data.Absences;

namespace LohnbitsRestApiClient.Helper;

internal static class JsonStringExtensions
{
    public static string AsJsonString(this DataReport report)
    {
        return $@"{{
  ""id"": {report.LohnbitsAuswertungenEinstellungenLfdNr},
  ""title"": ""{report.Title}"",
  ""reportType"": ""{report.ReportType}"",
  ""code"": ""{report.Code}""
}}";
    }

    public static string AsJsonString(this SelectReportsResult selectReportsResult)
    {
        return selectReportsResult.AsJsonString(selectReportsResult.Reports.Count);
    }

    public static string AsJsonString(this SelectReportsResult selectReportsResult, int limit)
    {
        var limitedReports = selectReportsResult.Reports.Take(limit);
        var reportsJson = string.Join(",\n    ",
            limitedReports.Select(r => r.AsJsonString().Replace("\n", "\n    ")));

        var totalCount = selectReportsResult.Reports.Count;
        var isLimited = limit < totalCount;
        var infoText = isLimited ? $"Zeige {limit} von {totalCount} Reports" : $"Zeige alle {totalCount} Reports";

        return $@"{{
  ""info"": ""{infoText}"",
  ""reports"": [
    {reportsJson}
  ]
}}";
    }

    public static string AsJsonString(this DataEmployee employee)
    {
        return $@"{{
  ""personnelNumber"": {employee.PersonnelNumber},
  ""firstName"": ""{employee.FirstName}"",
  ""surName"": ""{employee.SurName}"",
  ""fullName"": ""{employee.FullName}"",
  ""employmentStatus"": ""{employee.EmploymentStatus}"",
  ""companyName"": ""{employee.CompanyName}""
}}";
    }

    public static string AsJsonString(this SelectEmployeesResult selectEmployeesResult)
    {
        return selectEmployeesResult.AsJsonString(selectEmployeesResult.Employees.Count);
    }

    public static string AsJsonString(this SelectEmployeesResult selectEmployeesResult, int limit)
    {
        var limitedEmployees = selectEmployeesResult.Employees.Take(limit);
        var employeesJson = string.Join(",\n    ",
            limitedEmployees.Select(e => e.AsJsonString().Replace("\n", "\n    ")));

        var totalCount = selectEmployeesResult.Employees.Count;
        var isLimited = limit < totalCount;
        var infoText = isLimited ? $"Zeige {limit} von {totalCount} Mitarbeitern" : $"Zeige alle {totalCount} Mitarbeiter";

        return $@"{{
  ""info"": ""{infoText}"",
  ""employees"": [
    {employeesJson}
  ]
}}";
    }

    public static string AsJsonString(this DataEmployeeAbsence absence)
    {
        return $@"{{
  ""id"": {absence.Id},
  ""personnelNumber"": {absence.PersonnelNumber},
  ""date"": ""{absence.Date:yyyy-MM-dd}"",
  ""duration"": ""{absence.Duration}"",
  ""approvalStatus"": ""{absence.ApprovalStatus}"",
  ""absenceKeyLohnbits"": ""{absence.AbsenceKeyLohnbits}"",
  ""hoursAbsent"": {absence.HoursAbsent},
  ""daysAbsent"": {absence.DaysAbsent}
}}";
    }

    public static string AsJsonString(this SelectEmployeeAbsenceResult selectEmployeeAbsenceResult)
    {
        return selectEmployeeAbsenceResult.AsJsonString(selectEmployeeAbsenceResult.Absences.Count);
    }

    public static string AsJsonString(this SelectEmployeeAbsenceResult selectEmployeeAbsenceResult, int limit)
    {
        var limitedAbsences = selectEmployeeAbsenceResult.Absences.Take(limit);
        var absencesJson = string.Join(",\n    ",
            limitedAbsences.Select(a => a.AsJsonString().Replace("\n", "\n    ")));

        var totalCount = selectEmployeeAbsenceResult.Absences.Count;
        var isLimited = limit < totalCount;
        var infoText = isLimited ? $"Zeige {limit} von {totalCount} Abwesenheiten" : $"Zeige alle {totalCount} Abwesenheiten";

        return $@"{{
  ""info"": ""{infoText}"",
  ""absences"": [
    {absencesJson}
  ]
}}";
    }

    public static string AsJsonString(this DataEmployeeAbsenceBalance absenceBalance)
    {
        return $@"{{
  ""clientId"": {absenceBalance.ClientId},
  ""clientNumber"": {absenceBalance.ClientNumber},
  ""employeeId"": {absenceBalance.EmployeeId},
  ""personnelNumber"": {absenceBalance.PersonnelNumber},
  ""sickDays"": {absenceBalance.SickDays},
  ""sickDaysWithoutCertificate"": {absenceBalance.SickDaysWithoutCertificate},
  ""sickDaysChildTotal"": {absenceBalance.SickDaysChildTotal},
  ""leaveEntitlementYearDays"": {absenceBalance.LeaveEntitlementYearDays},
  ""leaveEntitlementYearHours"": {absenceBalance.LeaveEntitlementYearHours},
  ""leaveEntitlementPreviousYearDays"": {absenceBalance.LeaveEntitlementPreviousYearDays},
  ""leaveEntitlementPreviousYearHours"": {absenceBalance.LeaveEntitlementPreviousYearHours},
  ""leaveTakenDays"": {absenceBalance.LeaveTakenDays},
  ""leaveTakenHours"": {absenceBalance.LeaveTakenHours},
  ""leavePlannedDays"": {absenceBalance.LeavePlannedDays},
  ""leavePlannedHours"": {absenceBalance.LeavePlannedHours},
  ""leaveRequestedDays"": {absenceBalance.LeaveRequestedDays},
  ""leaveRequestedHours"": {absenceBalance.LeaveRequestedHours},
  ""leaveProvisionalDays"": {absenceBalance.LeaveProvisionalDays},
  ""leaveProvisionalHours"": {absenceBalance.LeaveProvisionalHours},
  ""leaveExpiredDays"": {absenceBalance.LeaveExpiredDays},
  ""leaveExpiredHours"": {absenceBalance.LeaveExpiredHours},
  ""leaveNextYearDays"": {absenceBalance.LeaveNextYearDays},
  ""leaveNextYearHours"": {absenceBalance.LeaveNextYearHours},
  ""baseLeaveDays"": {absenceBalance.BaseLeaveDays},
  ""baseLeaveHours"": {absenceBalance.BaseLeaveHours},
  ""totalDays"": {absenceBalance.TotalDays},
  ""totalHours"": {absenceBalance.TotalHours}
}}";
    }

    public static string AsJsonString(this SelectEmployeeAbsenceBalanceResult selectEmployeeAbsenceBalanceResult)
    {
        return selectEmployeeAbsenceBalanceResult.AsJsonString(selectEmployeeAbsenceBalanceResult.AbsenceBalances.Count);
    }

    public static string AsJsonString(this SelectEmployeeAbsenceBalanceResult balancesResult, int limit)
    {
        var limitedBalances = balancesResult.AbsenceBalances.Take(limit);
        var balancesJson = string.Join(",\n    ",
            limitedBalances.Select(b => b.AsJsonString().Replace("\n", "\n    ")));

        var totalCount = balancesResult.AbsenceBalances.Count;
        var isLimited = limit < totalCount;
        var infoText = isLimited ? $"Zeige {limit} von {totalCount} Abwesenheitskonten" : $"Zeige alle {totalCount} Abwesenheitskonten";

        return $@"{{
  ""info"": ""{infoText}"",
  ""balances"": [
    {balancesJson}
  ]
}}";
    }

    public static string AsJsonString(this DataEmployeeWorkingHours workingHours)
    {
        return $@"{{
        ""clientId"": {workingHours.ClientId},
  ""clientNumber"": {workingHours.ClientNumber},
  ""personnelNumber"": {workingHours.PersonnelNumber},
  ""validFrom"": {workingHours.ValidFrom},
  ""workingHoursMonday"": {workingHours.WorkingHoursMonday},
  ""workingHoursTuesday"": {workingHours.WorkingHoursTuesday},
  ""workingHoursWednesday"": {workingHours.WorkingHoursWednesday},
  ""workingHoursThursday"": {workingHours.WorkingHoursThursday},
  ""workingHoursFriday"": {workingHours.WorkingHoursFriday},
  ""workingHoursSaturday"": {workingHours.WorkingHoursSaturday},
  ""workingHoursSunday"": {workingHours.WorkingHoursSunday},
  ""workingHoursFullTime"": {workingHours.WorkingHoursFullTime},
  ""workingHoursWeek"": {workingHours.WorkingHoursWeek},
  ""reasonForChangeInWorkingHours"": {workingHours.ReasonForChangeInWorkingHours},
  ""editingInstructions"": {workingHours.EditingInstructions}
}}";
    }

    public static string AsJsonString(this SelectEmployeeWorkingHoursResult selectEmployeeWorkingHoursResult)
    {
        return selectEmployeeWorkingHoursResult.AsJsonString(selectEmployeeWorkingHoursResult.WorkingHours.Count);
    }

    public static string AsJsonString(this SelectEmployeeWorkingHoursResult workingHoursResult, int limit)
    {
        var limitedBalances = workingHoursResult.WorkingHours.Take(limit);
        var balancesJson = string.Join(",\n    ",
            limitedBalances.Select(b => b.AsJsonString().Replace("\n", "\n    ")));

        var totalCount = workingHoursResult.WorkingHours.Count;
        var isLimited = limit < totalCount;
        var infoText = isLimited ? $"Zeige {limit} von {totalCount} Arbeitszeitkonten" : $"Zeige alle {totalCount} Arbeitszeitkonten";

        return $@"{{
  ""info"": ""{infoText}"",
  ""balances"": [
    {balancesJson}
  ]
}}";
    }
}