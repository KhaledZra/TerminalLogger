using System.Text.Json;

namespace dailyLoginLog;

public static class JsonHandler
{
    public static List<Log> LoadLogs() =>
        File.Exists("logs.json") ?
            JsonSerializer.Deserialize<List<Log>>(File.ReadAllText("logs.json"))! 
            : new List<Log>();

    public static void SaveLogs(List<Log> logs)
    {
        JsonSerializerOptions options = new JsonSerializerOptions() { WriteIndented = true };
        File.WriteAllText("logs.json", JsonSerializer.Serialize(logs, options));
    }
}