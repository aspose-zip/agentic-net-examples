// HOW-TO: Create Split ZIP Archive of JavaScript and Python Files in C# (Aspose.ZIP for .NET)
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
            // Hardcoded input file paths
            string inputDirectory = "inputScripts";
            string jsFilePath = Path.Combine(inputDirectory, "example.js");
            string pyFilePath = Path.Combine(inputDirectory, "script.py");

            // Validate input files
            if (!File.Exists(jsFilePath))
            {
                Console.Error.WriteLine($"File not found: {jsFilePath}");
                return;
            }
            if (!File.Exists(pyFilePath))
            {
                Console.Error.WriteLine($"File not found: {pyFilePath}");
                return;
            }

            // Create a new ZIP archive and add script files
            using (Archive archive = new Archive())
            {
                archive.CreateEntry("example.js", new FileInfo(jsFilePath));
                archive.CreateEntry("script.py", new FileInfo(pyFilePath));

                // Configure split (multivolume) options: 64 KiB per segment, base name 'scripts'
                SplitArchiveSaveOptions splitOptions = new SplitArchiveSaveOptions("scripts", 64 * 1024);

                // Hardcoded output directory for split segments
                string outputDirectory = "outputScripts";

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputDirectory) ?? outputDirectory);

                // Save the archive as split segments
                archive.SaveSplit(outputDirectory, splitOptions);
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
 * 1. When you need to package multiple script files into a ZIP that can be transferred over size‑limited channels, such as email attachments or legacy storage media.
 * 2. When you want to generate multivolume ZIP archives with a fixed 64 KiB segment size to comply with system or network constraints.
 * 3. When you must automate the creation of split ZIP files for deployment scripts that must be stored on devices with small storage blocks.
 * 4. When you need to programmatically add specific file types (e.g., .js and .py) to an archive and ensure each part is saved with a consistent base name for easy reassembly.
 * 5. When you are building a backup solution that divides large script collections into manageable ZIP segments for incremental copying or cloud upload.
 */
