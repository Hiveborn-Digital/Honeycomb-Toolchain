using System.Diagnostics;

class Command()
{
    public static void RunCommand(string command, string arguments = "")
    {
        var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = GetShellCommand(),
                Arguments = GetShellArguments(command),
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            }
        };

        process.Start();

        string line;
        while ((line = process.StandardOutput.ReadLine()) != null)
        {
            Console.WriteLine(line);
        }

        string error = process.StandardError.ReadToEnd();
        if (!string.IsNullOrEmpty(error))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(error);
            Console.ResetColor();
        }

        process.WaitForExit();
        return;
    }

    private static string GetShellCommand()
    {
        return Environment.OSVersion.Platform == PlatformID.Win32NT ? "cmd.exe" : "/bin/bash";
    }

    private static string GetShellArguments(string command)
    {
        return Environment.OSVersion.Platform == PlatformID.Win32NT ? $"/c {command}" : $"-c \"{command}\"";
    }
}