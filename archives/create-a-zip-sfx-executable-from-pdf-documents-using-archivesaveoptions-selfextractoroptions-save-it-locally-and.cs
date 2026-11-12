// HOW-TO: Create PDF Self‑Extracting EXE With Aspose.Zip In C# (Aspose.ZIP for .NET)
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
            // Hardcoded input and output paths
            string inputDirectory = @"C:\Temp\PdfDocs";
            string outputDirectory = @"C:\Temp\Output";
            string sfxPath = Path.Combine(outputDirectory, "PdfArchive.exe");
            string invocationFilePath = Path.Combine(outputDirectory, "run_sfx.txt");

            // Validate input directory
            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(sfxPath));
            Directory.CreateDirectory(Path.GetDirectoryName(invocationFilePath));

            // Create a new ZIP archive
            using (Archive archive = new Archive())
            {
                // Add all PDF files from the input directory
                string[] pdfFiles = Directory.GetFiles(inputDirectory, "*.pdf");
                foreach (string pdfFilePath in pdfFiles)
                {
                    if (!File.Exists(pdfFilePath))
                    {
                        Console.Error.WriteLine($"File not found: {pdfFilePath}");
                        continue;
                    }

                    // Use the file name as the entry name inside the archive
                    string entryName = Path.GetFileName(pdfFilePath);
                    archive.CreateEntry(entryName, pdfFilePath);
                }

                // Configure self-extractor options
                ArchiveSaveOptions saveOptions = new ArchiveSaveOptions();
                SelfExtractorOptions sfxOptions = new SelfExtractorOptions();
                // Additional self-extractor settings can be configured here if needed
                saveOptions.SelfExtractorOptions = sfxOptions;

                // Save the self-extracting archive
                archive.Save(sfxPath, saveOptions);
            }

            // Write invocation file with runtime switches
            using (StreamWriter writer = new StreamWriter(invocationFilePath, false))
            {
                writer.WriteLine($"\"{sfxPath}\" -autoExtract");
            }

            Console.WriteLine("Self-extracting archive created successfully.");
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
 * 1. When you need to distribute a collection of PDF manuals as a single executable that automatically extracts itself on the user's machine.
 * 2. When you want to embed PDF reports into a self‑extracting installer for offline delivery without requiring separate extraction tools.
 * 3. When you must generate a portable SFX archive in a C# application to simplify deployment of PDF documentation to client computers.
 * 4. When you need to create a self‑extracting PDF bundle and provide a separate command file with the -autoExtract switch for scripted execution.
 * 5. When you are automating the packaging of PDF files into a compressed EXE using Aspose.Zip to reduce manual archiving steps.
 */
