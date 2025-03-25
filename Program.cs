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
        switch (Console.ReadKey().Key)
        {
            case ConsoleKey.D0:
            case ConsoleKey.NumPad0:
                Console.WriteLine("\tErster Schritt");
                FirstStepsExample.Execute(_loginMethod);
                    return true;
            case ConsoleKey.D1:
            case ConsoleKey.NumPad1:
                Console.WriteLine("\tMonatsdatenerfassung");
                MonthlyDataExample.Execute(_loginMethod);
                return true;
            case ConsoleKey.D2:
            case ConsoleKey.NumPad2:
                Console.WriteLine("\tAuswertung generieren");
                ReportExample.Execute(_loginMethod);
                return true;
            case ConsoleKey.D3:
            case ConsoleKey.NumPad3:
                Console.WriteLine("\tAbwesenheiten laden");
                SelectAbsencesExample.Execute(_loginMethod);
                return true;
            case ConsoleKey.D4:
            case ConsoleKey.NumPad4:
                Console.WriteLine("\tDokument hochladen");
                UploadDocumentExample.Execute(_loginMethod);
                return true;
            case ConsoleKey.D5:
            case ConsoleKey.NumPad5:
                Console.WriteLine("\tDokument in Posteingang hochladen");
                UploadDocumentInboxExample.Execute(_loginMethod);
                return true;
            default:
                return true;
        }
    }
}
