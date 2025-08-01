using gv3kServerFibuLohn.Api.Data.Absences;
using gv3kServerFibuLohn.Api.Data.MasterData;
using LohnbitsRestApiClient.Model;

namespace LohnbitsRestApiClient.Samples;

public class SelectAbsencesExample : BaseExample
{
    public static void Execute(LoginMethod loginMethod)
    {
        var bearerToken = GetToken(loginMethod);

        // Abfrage, auf welche Betriebe Zugriff besteht; es wird der erste Betrieb ausgewählt 
        // wichtig: bei vielen Abfragen ist die Suche nach Mandantengruppe noch nicht implementiert
        // die Mandantennummer der Rückgabe darf verwendet werden
        var customersResult = WebApiBase.RequestGet<SelectCustomersResult>("selectCustomers", bearerToken);
        var mandantLfdNr = customersResult?.Customers?.FirstOrDefault()?.ClientId ?? 0;

        Console.WriteLine($"GET ../selectCustomers");
        Console.WriteLine($"Response: {{ errorCode: {customersResult?.ErrorCode}, clientId: {mandantLfdNr} }}");

        var (startDate, endDate) = SelectDateRange();
        var selectAbsenceRequest = new SelectEmployeeAbsenceRequest { ClientId = mandantLfdNr, PersonnelNumber = 54, RequestPeriodBegin = startDate, RequestPeriodEnd = endDate };
        var selectAbsenceResult = WebApiBase.RequestPost<SelectEmployeeAbsenceResult>("selectEmployeeAbsence", bearerToken, selectAbsenceRequest);

        Console.WriteLine($"POST ../selectEmployeeAbsence");
        Console.WriteLine($"Request: {{ clientId: {selectAbsenceRequest.ClientId}, requestPeriodBegin: {selectAbsenceRequest.RequestPeriodBegin}, requestPeriodEnd: {selectAbsenceRequest.RequestPeriodEnd} }}");
        Console.WriteLine($"Response: {{ errorCode: {selectAbsenceResult?.ErrorCode}, absenceCount: {selectAbsenceResult?.Absences.Count} }}");


        // Abmeldung vom REST API Gateway
        WebApiBase.RequestGet<Task>("session/logout", bearerToken);
    }

    
    private static (DateTime start, DateTime end) SelectDateRange()
    {
        Console.WriteLine("Gib den Datumsbereich für Abwesenheitsanfragen ein (Format: tt.mm.jj)");
    
        DateTime startDate, endDate;
    
        // Get start date
        while (true)
        {
            Console.Write("Startdatum (tt.mm.jj): ");
            var input = Console.ReadLine()?.Trim();
        
            if (string.Equals(input, "exit", StringComparison.OrdinalIgnoreCase))
            {
                Environment.Exit(0);
            }
        
            if (DateTime.TryParseExact(input, "dd.MM.yy", null, System.Globalization.DateTimeStyles.None, out startDate))
            {
                break;
            }
        
            Console.WriteLine("Ungültiges Datumsformat. Bitte verwende das Format tt.mm.jj (z.B. 15.03.25)");
        }
    
        // Get end date
        while (true)
        {
            Console.Write("Enddatum (tt.mm.jj): ");
            var input = Console.ReadLine()?.Trim();
        
            if (string.Equals(input, "exit", StringComparison.OrdinalIgnoreCase))
            {
                Environment.Exit(0);
            }
        
            if (DateTime.TryParseExact(input, "dd.MM.yy", null, System.Globalization.DateTimeStyles.None, out endDate))
            {
                if (endDate >= startDate)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Das Enddatum muss gleich oder nach dem Startdatum liegen. Bitte gib ein gültiges Enddatum ein.");
                }
            }
            else
            {
                Console.WriteLine("Ungültiges Datumsformat. Bitte verwende das Format tt.mm.jj (z.B. 24.06.25)");
            }
        }
    
        return (startDate, endDate);
    }

}
