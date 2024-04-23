using dailyLoginLog;

public class Log
{
    public Log(string? text)
    {
        Text = text;
        DateStamp = DateTime.Now;
    }
    
    
    public string? Text { get; set; }
    public DateTime DateStamp { get; set; }
    
    public override string ToString()
    {
        return $"Date: {DateStamp}\nLog Entry: {Text}";
    }
    
    // Log Actions
    public static void NewLog()
    {
        Console.Clear();
        Console.WriteLine("New log");
        Console.WriteLine("Start typing and press enter when you are done to save it.");
        Console.Write("Entry: ");
        Log newLog = new Log(Console.ReadLine());
        List<Log> logs = JsonHandler.LoadLogs();
        logs.Add(newLog);
        JsonHandler.SaveLogs(logs);
        Console.WriteLine("Log saved, date: " + newLog.DateStamp);
        Console.Write("Press any key to continue");
        Console.ReadKey(true);
    }

    public static void OldLogs()
    {
        List<Log> logs = JsonHandler.LoadLogs();
        Console.Clear();
        if (logs.Count != 0)
        {
            for (int i = 0; i < logs.Count; i++)
            {
                Console.WriteLine("Log entry " + (i + 1));
                Console.WriteLine(logs[i]);
                Console.WriteLine("--------------------");
            }
        }
        else
        {
            Console.WriteLine("No logs found.");
        }
        Console.Write("Press any key to continue");
        Console.ReadKey(true);
    }
}