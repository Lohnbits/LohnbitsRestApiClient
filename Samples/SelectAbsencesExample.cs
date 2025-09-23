using gv3kServerFibuLohn.Api.Data.Absences;
using gv3kServerFibuLohn.Api.Data.MasterData;
using LohnbitsRestApiClient.Helper;
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

        var employeeRequest = new SelectEmployeesRequest { ClientId = mandantLfdNr };
        var employeeResult = WebApiBase.RequestPost<SelectEmployeesResult>("selectEmployees", bearerToken, employeeRequest);

        Console.WriteLine($"POST ../selectEmployees");
        Console.WriteLine($"Request: {{ clientId: {employeeRequest.ClientId} }}");
        Console.WriteLine($"Response: {{ errorCode: {employeeResult?.ErrorCode}, count: {employeeResult?.Employees.Count} }}");


        var personnelNumber = SelectPersonnelNumber(employeeResult);
        if (personnelNumber == -1)
        {
            Console.WriteLine("Kein Mitarbeiter gefunden.");
            return;
        }

        var (startDate, endDate) = SelectDateRange();

        var selectAbsenceRequest = new SelectEmployeeAbsenceRequest { ClientId = mandantLfdNr, PersonnelNumber = personnelNumber, RequestPeriodBegin = startDate, RequestPeriodEnd = endDate };
        var selectAbsenceResult = WebApiBase.RequestPost<SelectEmployeeAbsenceResult>("selectEmployeeAbsence", bearerToken, selectAbsenceRequest);

        Console.WriteLine($"POST ../selectEmployeeAbsence");
        Console.WriteLine($"Request: {{ clientId: {selectAbsenceRequest.ClientId}, requestPeriodBegin: {selectAbsenceRequest.RequestPeriodBegin}, requestPeriodEnd: {selectAbsenceRequest.RequestPeriodEnd} }}");
        Console.WriteLine($"Response: {{ errorCode: {selectAbsenceResult?.ErrorCode} }}");
        Console.WriteLine($"{selectAbsenceResult?.AsJsonString(10)}");


        Logout(bearerToken);
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

    private static int SelectPersonnelNumber(SelectEmployeesResult? selectEmployeesResult)
    {
        if (selectEmployeesResult == null || selectEmployeesResult.Employees.Count == 0)
        {
            Console.WriteLine("Keine Mitarbeiter verfügbar.");
            return -1;
        }

        Console.WriteLine("Verfügbare Mitarbeiter:");
        Console.WriteLine(selectEmployeesResult.AsJsonString(10));

        while (true)
        {
            Console.Write("Gib die Personalnummer des gewünschten Mitarbeiters ein (Tippe 'exit' zum Beenden): ");
            var input = Console.ReadLine()?.Trim();

            if (string.Equals(input, "exit", StringComparison.OrdinalIgnoreCase))
            {
                return -1;
            }

            if (!int.TryParse(input, out var personnelNumber))
            {
                Console.WriteLine("Ungültige Eingabe. Bitte gib eine gültige Personalnummer ein.");
                continue;
            }

            var selectedEmployee = selectEmployeesResult.Employees
                .FirstOrDefault(e => e.PersonnelNumber == personnelNumber);

            if (selectedEmployee == null)
            {
                Console.WriteLine($"Mitarbeiter mit Personalnummer {personnelNumber} nicht gefunden.");
                continue;
            }

            Console.WriteLine($"Mitarbeiter ausgewählt: {selectedEmployee.FullName}");
            return personnelNumber;
        }
    }

}
