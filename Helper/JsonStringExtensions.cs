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

}