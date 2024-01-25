using System;
using System.IO;

public static class Logger
{
    private static string logFilePath = "gameLog.txt";

    public static void Log(string message)
    {
        using (StreamWriter writer = new StreamWriter(logFilePath, true))
        {
            writer.WriteLine($"{DateTime.Now}: {message}");
        }
    }
}
