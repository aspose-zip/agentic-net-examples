// HOW-TO: Create Self‑Extracting Zip Executable Using Aspose.Zip With Auto‑Extract Switches In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFile1 = @"C:\Data\file1.txt";
            string inputFile2 = @"C:\Data\file2.txt";

            if (!File.Exists(inputFile1))
            {
                Console.Error.WriteLine($"File not found: {inputFile1}");
                return;
            }
            if (!File.Exists(inputFile2))
            {
                Console.Error.WriteLine($"File not found: {inputFile2}");
                return;
            }

            string sfxOutputPath = @"C:\Output\MyArchive.exe";
            Directory.CreateDirectory(Path.GetDirectoryName(sfxOutputPath));

            using (Archive archive = new Archive())
            {
                archive.CreateEntry("file1.txt", inputFile1);
                archive.CreateEntry("file2.txt", inputFile2);

                ArchiveSaveOptions saveOptions = new ArchiveSaveOptions();
                SelfExtractorOptions sfxOptions = new SelfExtractorOptions();
                saveOptions.SelfExtractorOptions = sfxOptions;

                archive.Save(sfxOutputPath, saveOptions);
            }

            string invocationFilePath = @"C:\Output\run_sfx.txt";
            Directory.CreateDirectory(Path.GetDirectoryName(invocationFilePath));
            string invocationContent = $"{sfxOutputPath}";
            File.WriteAllText(invocationFilePath, invocationContent);

            Console.WriteLine("Self‑extracting archive created successfully.");
            Console.WriteLine($"Invocation file written to: {invocationFilePath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to distribute a set of files to end users who can run a single .exe that automatically extracts its contents without requiring a separate unzip tool.
 * 2. When you want to embed custom runtime switches such as -autoExtract and -autoClose in a separate invocation file to control the self‑extracting archive’s behavior at execution time.
 * 3. When you must generate a portable installer for configuration files or scripts that can be launched from a batch process or shortcut without manual interaction.
 * 4. When you are automating a build pipeline that packages compiled assets into a self‑extracting executable for easy deployment on Windows machines.
 * 5. When you need to create a self‑extracting archive programmatically in C# using Aspose.Zip to avoid third‑party command‑line tools and keep the process within your application code.
 */
