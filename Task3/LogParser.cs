using System.Text;

namespace Task3;

public static class LogParser
{
    private const string PROBLEMS_FILE_NAME = "problems.txt";
    
    public static string? ParseLog(string log)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(log))
                throw new ArgumentNullException(nameof(log), "log is empty");

            var sb = !log.Contains('|')
                ? new StringBuilder(ParseFormat1(log))
                : new StringBuilder(ParseFormat2(log));

            return sb.ToString();
        }
        catch (Exception)
        {
            File.AppendAllText(PROBLEMS_FILE_NAME, log + Environment.NewLine);
            return null;
        }
    }

    private static string ParseFormat1(string log)
    {
        var parts = log.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        if (parts.Length < 4)
            throw new FormatException("Invalid format for Format 1.");
        
        var datePart = parts[0];
        var timePart = parts[1];
        
        var date = DateTime.ParseExact(datePart, "dd.MM.yyyy", null);
        var formattedDate = date.ToString("dd-MM-yyyy");
        
        var logLevel = MapLogLevel(parts[2]);
        
        var message = string.Join(" ", parts.Skip(3));
        
        const string callerMethod = "DEFAULT";

        return $"{formattedDate}\t{timePart}\t{logLevel}\t{callerMethod}\t{message}";
    }
    
    private static string ParseFormat2(string log)
    {
        var parts = log.Split('|', StringSplitOptions.RemoveEmptyEntries);

        if (parts.Length < 4)
            throw new FormatException("Invalid format for Format 2.");

        var dateTimeParts = parts[0].Split(' ');
        var datePart = dateTimeParts[0];
        var timePart = dateTimeParts[1];
        
        var date = DateTime.ParseExact(datePart, "yyyy-MM-dd", null);
        var formattedDate = date.ToString("dd-MM-yyyy");
        
        var logLevel = MapLogLevel(parts[1].Trim());
        
        var callerMethod = parts[3].Trim();
        
        var message = parts.Length > 4 ? parts[4].Trim() : string.Empty;

        return $"{formattedDate}\t{timePart}\t{logLevel}\t{callerMethod}\t{message}";
    }
    
    private static string MapLogLevel(string logLevel)
    {
        return logLevel.ToUpper() switch
        {
            "INFORMATION" => "INFO",
            "INFO" => "INFO",
            "WARNING" => "WARN",
            "WARN" => "WARN",
            "ERROR" => "ERROR",
            "DEBUG" => "DEBUG",
            _ => throw new ArgumentException($"Unknown log level: {logLevel}", nameof(logLevel))
        };
    }
}