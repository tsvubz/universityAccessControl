namespace UniversityAccessControl.Patterns.Singleton;

public class Logger
{
    private static Logger? _instance; 
    private static readonly object _lock = new object();
    
    private readonly List<string> _logEntries;

    private Logger()
    {
        _logEntries = new List<string>();
    }

    public static Logger Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    _instance ??= new Logger();
                }
            }
            return _instance;
        }
    }

    public void Log(string message)
    {
        string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        string logEntry = $"[{timestamp}] {message}";
        
        _logEntries.Add(logEntry);
        Console.WriteLine(logEntry);
    }

    public void DisplayLogs()
    {
        Console.WriteLine("\n=== SYSTEM LOGS ===");
        foreach (var log in _logEntries)
        {
            Console.WriteLine(log);
        }
    }
}