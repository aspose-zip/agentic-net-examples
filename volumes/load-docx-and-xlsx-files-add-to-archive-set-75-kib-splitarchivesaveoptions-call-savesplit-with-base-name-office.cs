// HOW-TO: Create Split ZIP of DOCX and XLSX Files with 75KB Segments in C# (Aspose.ZIP for .NET)
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
            string inputDocxPath = "C:\\Data\\sample.docx";
            string inputXlsxPath = "C:\\Data\\sample.xlsx";

            // Hardcoded output directory
            string outputDirectory = "C:\\Output";

            // Validate input files
            if (!File.Exists(inputDocxPath))
            {
                Console.Error.WriteLine($"File not found: {inputDocxPath}");
                return;
            }
            if (!File.Exists(inputXlsxPath))
            {
                Console.Error.WriteLine($"File not found: {inputXlsxPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Create a new ZIP archive and add the Office files
            using (Archive archive = new Archive())
            {
                archive.CreateEntry("sample.docx", new FileInfo(inputDocxPath));
                archive.CreateEntry("sample.xlsx", new FileInfo(inputXlsxPath));

                // Configure split archive options (75 KiB per segment)
                SplitArchiveSaveOptions saveOptions = new SplitArchiveSaveOptions(75 * 1024);

                // Save the archive as split segments in the output directory
                archive.SaveSplit(outputDirectory, saveOptions);
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
 * 1. When a developer must package multiple Office documents into a ZIP that can be uploaded to a service with a strict file‑size limit, they can split the archive into 75 KB parts.
 * 2. When an application needs to store large DOCX and XLSX files on a filesystem that only allows small file blocks, splitting the ZIP ensures each segment fits the block size.
 * 3. When sending Office files over email or messaging platforms that cap attachment size, creating split ZIP segments lets each piece stay under the limit.
 * 4. When a backup system archives documents but must keep each archive chunk below a threshold for incremental storage or deduplication, the split archive option provides that control.
 * 5. When a developer wants to stream or download Office files in manageable chunks for progressive loading in a web client, generating split ZIP parts simplifies chunked transfer.
 */
