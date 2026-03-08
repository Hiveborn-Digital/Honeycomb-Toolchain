class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("No arguments.");
            return;
        }

        string command = args[0];
        string argument = "";
        try {
            argument = args[1];
        } catch {}
        if (command == "build")
        {
            if (argument != "toolchain" && argument != "_BIN")
            {
                Command.RunCommand($"dotnet build {argument}");
                Copy.Folder($"{argument}/Assets",$"{argument}/../_BIN/Content/v/{argument}/Content");
                Copy.File($"{argument}/_package.json",$"{argument}/../_BIN/Content/v/{argument}/_package.json");
            }
        }
        if (command == "clean")
        {
            if (argument != "toolchain" && argument != "_BIN")
                Command.RunCommand($"dotnet clean {argument}");
        }
        if (command == "play")
        {
            Command.RunCommand($"dotnet run --project _CORE/");
        }
        if (command == "buildall")
        {
            string[] packages = Directory.GetDirectories(".");
            foreach (string package in packages)
            {
                if (package != "toolchain" && package != "_BIN")
                {
                    Command.RunCommand($"dotnet build {package}");
                    Copy.Folder($"{package}/Assets",$"{package}/../_BIN/Content/v/{package}/Content");
                    Copy.File($"{package}/_package.json",$"{package}/../_BIN/Content/v/{package}/_package.json");
                }
            }
        }
        if (command == "cleanall")
        {
            string[] packages = Directory.GetDirectories(".");
            foreach (string package in packages)
            {
                if (package != "toolchain" && package != "_BIN")
                    Command.RunCommand($"dotnet clean {package}");
            }
        }
        if (command == "sync")
        {
            if (argument != "toolchain" && argument != "_BIN")
            {
                Copy.Folder($"{argument}/Assets",$"{argument}/../_BIN/Content/v/{argument}/Content");
                Copy.File($"{argument}/_package.json",$"{argument}/../_BIN/Content/v/{argument}/_package.json");
            }
        }
        if (command == "syncall")
        {
            string[] packages = Directory.GetDirectories(".");
            foreach (string package in packages)
            {
                if (package != "toolchain" && package != "_BIN")
                {
                    Copy.Folder($"{package}/Assets",$"{package}/../_BIN/Content/v/{package}/Content");
                    Copy.File($"{package}/_package.json",$"{package}/../_BIN/Content/v/{package}/_package.json");
                }
            }
        }
    }
}