using gv3kServerFibuLohn.Api.Data.Reports;

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
        var reportsJson = string.Join(",\n    ",
            selectReportsResult.Reports.Select(r => r.AsJsonString().Replace("\n", "\n    ")));

        return $@"{{
  ""reports"": [
    {reportsJson}
  ]
}}";
    }
}