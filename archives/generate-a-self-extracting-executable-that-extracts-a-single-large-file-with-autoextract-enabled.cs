// HOW-TO: Create Self‑Extracting EXE That Auto‑Extracts Large File In C# (Aspose.ZIP for .NET)
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
            // Hardcoded paths
            string inputFilePath = @"C:\Data\largefile.bin";
            string outputExePath = @"C:\Output\SelfExtractingArchive.exe";

            // Verify input file exists
            if (!File.Exists(inputFilePath))
            {
                Console.Error.WriteLine($"File not found: {inputFilePath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputExePath));

            // Create a new ZIP archive
            using (Archive archive = new Archive())
            {
                // Add the large file as an entry
                archive.CreateEntry("largefile.bin", inputFilePath);

                // Configure self‑extracting options
                ArchiveSaveOptions saveOptions = new ArchiveSaveOptions();
                saveOptions.SelfExtractorOptions = new SelfExtractorOptions();

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
 * 1. When you need to distribute a single large binary to users without requiring them to install a zip utility, you can package it as a self‑extracting executable that automatically extracts the file on run.
 * 2. When deploying software updates that consist of one big data file, you can create a self‑extracting archive so the update can be applied with a double‑click, simplifying the installation process.
 * 3. When sending a large log or backup file to a client over email or a download link, wrapping it in a self‑extracting EXE ensures the recipient can retrieve the file without dealing with compression tools.
 * 4. When automating a build pipeline that generates a large resource file, you can generate a self‑extracting executable to embed the file in a single portable artifact for later extraction on target machines.
 * 5. When providing a downloadable dataset that must be extracted immediately after download, a self‑extracting archive with auto‑extract removes the extra step of manually opening a zip archive.
 */
