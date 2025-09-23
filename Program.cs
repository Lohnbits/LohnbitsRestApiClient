using LohnbitsRestApiClient.Model;
using LohnbitsRestApiClient.Samples;
using System.Text;

namespace LohnbitsRestApiClient;

public class Program
{
    private static LoginMethod _loginMethod;

    static void Main(string[] args)
    {
        do
        {
            Console.Clear();
            ListLoginMethod();
        }
        while (!EvaluateLoginMethod());

        do
        {
            Console.WriteLine(Environment.NewLine);
            ListExamples();
        }
        while (EvaluateExample());
    }

    private static void ListLoginMethod()
    {
        var builder = new StringBuilder();
        builder.Append("Welches Anmeldungsmethode möchtest du verwenden?");
        builder.AppendLine(" Um eine Method auszuwählen, gib die Nummer der unten aufgelisteten Methoden ein.");
        builder.AppendLine("0\t2-Faktor-Authentifizierung");
        builder.AppendLine("1\tAnmeldung + AES-Verschlüsselung");

        Console.WriteLine(builder.ToString());
    }

    private static void ListExamples()
    {
        var builder = new StringBuilder();
        builder.Append("Welches Beispiel möchtest du ausführen?");
        builder.AppendLine(" Um ein Beispiel auszuführen, gib die Nummer der unten aufgelisteten Beispiele ein.");
        builder.AppendLine("0\tErster Schritt");
        builder.AppendLine("1\tMonatsdatenerfassung");
        builder.AppendLine("2\tAuswertung generieren");
        builder.AppendLine("3\tAbwesenheiten laden");
        builder.AppendLine("4\tDokument hochladen");
        builder.AppendLine("5\tDokument in Posteingang hochladen");
        builder.AppendLine("6\tAbwesenheitssalden laden");
        builder.AppendLine("7\tArbeitszeiten laden");
        builder.AppendLine("8\tAbwesenheit eintragen");
        builder.AppendLine("9\tAbwesenheit löschen");
        builder.AppendLine("10\tAbwesenheiten neu berechnen");
        builder.AppendLine("11\tAbwesenheitsanpassungen anzeigen");

        Console.WriteLine(builder.ToString());
    }

    private static bool EvaluateLoginMethod()
    {
        switch (Console.ReadKey().Key)
        {
            case ConsoleKey.D0:
            case ConsoleKey.NumPad0:
                Console.Write("\t2-Faktor-Authentifizierung");
                _loginMethod = LoginMethod.Totp;
                return true;
            case ConsoleKey.D1:
            case ConsoleKey.NumPad1:
                Console.Write("\tAnmeldung + AES-Verschlüsselung");
                _loginMethod = LoginMethod.Encrypted;
                return true;
            default:
                return false;
        }
    }

    private static bool EvaluateExample()
    {
        Console.Write("Bitte Nummer des Beispiels eingeben und Enter drücken: ");
        var input = Console.ReadLine()?.Trim();
        if (!int.TryParse(input, out int exampleNumber))
        {
            Console.WriteLine("Ungültige Eingabe. Bitte eine Zahl eingeben.");
            return true;
        }

        ExampleType exampleType = (ExampleType)exampleNumber;
        switch (exampleType)
        {
            case ExampleType.FirstSteps:
                Console.WriteLine("\tErster Schritt");
                FirstStepsExample.Execute(_loginMethod);
                break;
            case ExampleType.MonthlyData:
                Console.WriteLine("\tMonatsdatenerfassung");
                MonthlyDataExample.Execute(_loginMethod);
                break;
            case ExampleType.Report:
                Console.WriteLine("\tAuswertung generieren");
                ReportExample.Execute(_loginMethod);
                break;
            case ExampleType.SelectAbsences:
                Console.WriteLine("\tAbwesenheiten laden");
                SelectAbsencesExample.Execute(_loginMethod);
                break;
            case ExampleType.UploadDocument:
                Console.WriteLine("\tDokument hochladen");
                UploadDocumentExample.Execute(_loginMethod);
                break;
            case ExampleType.UploadDocumentInbox:
                Console.WriteLine("\tDokument in Posteingang hochladen");
                UploadDocumentInboxExample.Execute(_loginMethod);
                break;
            case ExampleType.GetAbsenceBalances:
                Console.WriteLine("\tAbwesenheitssalden laden");
                GetAbsenceBalancesExample.Execute(_loginMethod);
                break;
            case ExampleType.GetEmployeesWorkingHours:
                Console.WriteLine("\tArbeitszeiten laden");
                GetEmployeesWorkingHoursExample.Execute(_loginMethod);
                break;
            case ExampleType.InsertAbsence:
                Console.WriteLine("\tAbwesenheit eintragen");
                InsertAbsenceExample.Execute(_loginMethod);
                break;
            case ExampleType.DeleteAbsence:
                Console.WriteLine("\tAbwesenheit löschen");
                DeleteAbsenceExample.Execute(_loginMethod);
                break;
            case ExampleType.RecalcAbsence:
                Console.WriteLine("\tAbwesenheiten neu berechnen");
                RecalcAbsenceExample.Execute(_loginMethod);
                break;
            case ExampleType.SelectAbsenceAdjustment:
                Console.WriteLine("\tAbwesenheitsanpassungen anzeigen");
                SelectAbsenceAdjustmentExample.Execute(_loginMethod);
                break;
            default:
                Console.WriteLine("Beispielnummer nicht bekannt. Bitte gültige Nummer wählen.");
                break;
        }
        
        return true;
    }
}
