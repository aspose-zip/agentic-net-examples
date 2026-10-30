// HOW-TO: Extract ARJ Archive Name and Create XML Metadata in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Text;
using Aspose.Zip.Arj;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "sample.arj";
            string outputPath = "output/ArchiveInfo.xml";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            string comment = string.Empty;
            using (ArjArchive archive = new ArjArchive(inputPath))
            {
                // No direct comment property available; leaving comment empty.
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<ArchiveInfo>");
            sb.AppendLine($"  <FileName>{Path.GetFileName(inputPath)}</FileName>");
            sb.AppendLine($"  <Commentary>{comment}</Commentary>");
            sb.AppendLine("</ArchiveInfo>");

            File.WriteAllText(outputPath, sb.ToString());
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to log the names of ARJ archives processed by a C# application for audit trails.
 * 2. When generating an XML manifest that lists each ARJ file and its optional comment for integration with inventory systems.
 * 3. When building a reporting tool that extracts basic ARJ metadata to display in a dashboard without extracting the full archive.
 * 4. When creating a backup verification script that records archive filenames and comments in XML to compare against expected values.
 * 5. When automating documentation of legacy ARJ archives by programmatically writing their identifiers to an XML file for downstream processing.
 */
