// HOW-TO: Read ARJ Archive Metadata and Export to JSON in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Text;
using Aspose.Zip.ArchiveInfo;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = "sample.arj";
            string outputPath = "metadata.json";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            ArchiveInstanceInfo instanceInfo = ArchiveInstanceInfo.GetArchiveInstanceInfo(inputPath);

            string format = instanceInfo.FormatInfo.Format.ToString();
            string formatClass = instanceInfo.FormatInfo.Class.FullName;

            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.AppendLine("{");
            jsonBuilder.AppendLine($"  \"Format\": \"{format}\",");
            jsonBuilder.AppendLine($"  \"Class\": \"{formatClass}\"");
            jsonBuilder.AppendLine("}");

            File.WriteAllText(outputPath, jsonBuilder.ToString());

            Console.WriteLine($"Metadata saved to {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to log the format and class information of an ARJ file for audit or troubleshooting purposes.
 * 2. When building a migration tool that reads ARJ archives and stores their metadata in a JSON file for later analysis.
 * 3. When creating a reporting system that extracts archive details to feed into a dashboard displaying supported compression types.
 * 4. When validating that an uploaded ARJ archive matches expected format specifications before processing it further.
 * 5. When automating documentation generation that includes archive metadata alongside other project assets.
 */
