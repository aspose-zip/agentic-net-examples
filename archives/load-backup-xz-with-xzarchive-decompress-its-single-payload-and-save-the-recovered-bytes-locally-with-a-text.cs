// HOW-TO: Extract Single File From XZ Archive And Generate Byte Count Report In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Text;
using Aspose.Zip.Xz;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "backup.xz";
        string outputDataPath = "output/recovered.bin";
        string reportPath = "output/report.txt";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputDataPath));
            Directory.CreateDirectory(Path.GetDirectoryName(reportPath));

            // Open the XZ archive and extract its single payload
            using (XzArchive archive = new XzArchive(inputPath))
            {
                using (FileStream outStream = File.Create(outputDataPath))
                {
                    archive.Extract(outStream);
                }
            }

            // Determine the size of the recovered data
            long byteCount = new FileInfo(outputDataPath).Length;

            // Write a text report with the recovered byte count
            using (StreamWriter writer = new StreamWriter(reportPath, false, Encoding.UTF8))
            {
                writer.WriteLine($"Recovered byte count: {byteCount}");
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
 * 1. When you need to restore a compressed backup file (e.g., backup.xz) and verify the size of the recovered data in a .NET application.
 * 2. When you want to programmatically extract the sole payload from an XZ archive using Aspose.Zip and store it as a binary file for further processing.
 * 3. When you must generate a simple text report that logs the exact number of bytes extracted from a compressed archive for audit or logging purposes.
 * 4. When an automated deployment script must decompress a single‑file XZ package and place both the data and a verification report into a designated output folder.
 * 5. When troubleshooting data loss, you need to decompress an XZ archive, save the raw bytes, and quickly see how many bytes were successfully recovered.
 */
