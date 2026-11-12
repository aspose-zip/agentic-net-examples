// HOW-TO: Create a Tar.Xz Archive and Add a File Using C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Tar;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string sourceFilePath = "notes.txt";
            string outputPath = "archive.tar.xz";

            if (!File.Exists(sourceFilePath))
            {
                Console.Error.WriteLine($"File not found: {sourceFilePath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (TarArchive archive = new TarArchive())
            {
                archive.CreateEntry("notes.txt", sourceFilePath);
                archive.SaveXzCompressed(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to package a single text file into a compressed tar.xz archive for distribution in a Linux environment using C#.
 * 2. When automating backup scripts that require creating tar.xz archives of configuration files on Windows servers with Aspose.Zip.
 * 3. When integrating a .NET application with a CI/CD pipeline that must generate tar.xz artifacts for deployment to container registries.
 * 4. When providing end‑users a single compressed archive that preserves Unix file permissions and can be extracted with standard tools.
 * 5. When you want to programmatically create a tar.xz archive without relying on external command‑line utilities in a cross‑platform C# project.
 */
