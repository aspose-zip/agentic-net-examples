// HOW-TO: Create Self-Extracting EXE Archive From Folder Using Aspose.Zip In C# (Aspose.ZIP for .NET)
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
            // Hardcoded input directory containing files to be packaged
            string inputDirectory = @"C:\Data\Input";

            // Hardcoded output path for the self‑extracting executable
            string outputExePath = @"C:\Data\Output\MyArchive.exe";

            // Verify input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputExePath));

            // Create a new ZIP archive
            using (Archive archive = new Archive())
            {
                // Add each file from the input directory to the archive
                DirectoryInfo dirInfo = new DirectoryInfo(inputDirectory);
                foreach (FileInfo fileInfo in dirInfo.GetFiles())
                {
                    string filePath = fileInfo.FullName;

                    // Verify the file exists before adding
                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        continue;
                    }

                    // Add the file to the archive; entry name is the file name
                    archive.CreateEntry(fileInfo.Name, filePath);
                }

                // Configure self‑extracting options
                ArchiveSaveOptions saveOptions = new ArchiveSaveOptions();
                saveOptions.SelfExtractorOptions = new SelfExtractorOptions();
                // Example: set default extraction path (optional)
                // saveOptions.SelfExtractorOptions.ExtractPath = @"C:\Extracted";

                // Save the archive as a self‑extracting executable
                archive.Save(outputExePath, saveOptions);
            }

            Console.WriteLine("Self‑extracting archive created successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to distribute a set of files to end‑users without requiring them to install a separate unzip utility, you can package the files into a self‑extracting executable.
 * 2. When deploying configuration files or resources as part of an installer, the SFX archive lets you bundle them and automatically extract them to a target directory.
 * 3. When sending logs or diagnostic data to support teams, you can compress the files and create a single executable that extracts the contents on the recipient’s machine.
 * 4. When creating a portable tool that must unpack its own plugins at runtime, the self‑extracting archive can be launched to place the plugins in the correct folder.
 * 5. When automating backup of a specific folder and you want a single executable that restores the files without manual extraction steps, this code generates the SFX archive programmatically.
 */
