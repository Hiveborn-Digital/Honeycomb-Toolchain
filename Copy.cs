public class Copy
{
    public static void Folder(string sourceDir, string destDir)
    {
        if (!Directory.Exists(sourceDir))
        {
            return;
        }
        Directory.CreateDirectory(destDir);

        foreach (string file in Directory.GetFiles(sourceDir))
        {
            string destFile = Path.Combine(destDir, Path.GetFileName(file));
            System.IO.File.Copy(file, destFile, overwrite: true);
        }

        foreach (string dir in Directory.GetDirectories(sourceDir))
        {
            string destSubDir = Path.Combine(destDir, Path.GetFileName(dir));
            Folder(dir, destSubDir);
        }
    }
    public static void File(string sourceFile, string destFile)
    {
        if (!System.IO.File.Exists(sourceFile))
        {
            return;
        }
        System.IO.File.Copy(sourceFile, destFile, overwrite: true);
    }
}