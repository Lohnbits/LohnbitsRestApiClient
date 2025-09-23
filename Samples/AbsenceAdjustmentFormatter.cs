using gv3kServerFibuLohn.Api.Data.Absences;

namespace LohnbitsRestApiClient.Samples;

public static class AbsenceAdjustmentFormatter
{
    public static void PrintResult(SelectEmployeeAbsenceAdjustmentResult result)
    {
        if (result == null || result.AbsenceAdjustmentss == null || result.AbsenceAdjustmentss.Count == 0)
        {
            Console.WriteLine("Keine Abwesenheitsanpassungen gefunden.");
            return;
        }

        if (result.AbsenceAdjustmentss.Count > 10)
        {
            Console.WriteLine("(Anzeige begrenzt auf die ersten 10 Anpassungen)");
        }
        int count = 0;
        foreach (var adj in result.AbsenceAdjustmentss)
        {
            if (count++ >= 10) break;
            Console.WriteLine($"Id: {adj.Id}, MitarbeiterId: {adj.EmployeeId}, Personalnummer: {adj.PersonnelNumber}, Datum: {adj.Date:yyyy-MM-dd}, Art: {adj.ArtBuchung}, Stunden: {adj.FehlzeitStunden}, Tage: {adj.FehlzeitTage}");
        }
    }
}
