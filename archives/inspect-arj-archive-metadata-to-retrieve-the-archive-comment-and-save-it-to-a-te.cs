// HOW-TO: Read ARJ Archive Comment and Save to Text File in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Arj;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = "sample.arj";
            string outputPath = "archive_comment.txt";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (IArchive archive = ArchiveFactory.GetArchive(inputPath))
            {
                string comment = string.Empty;

                ArjArchive arjArchive = archive as ArjArchive;
                if (arjArchive != null)
                {
                    // Attempt to retrieve comment via reflection if the property exists
                    var commentProperty = typeof(ArjArchive).GetProperty("Comment");
                    if (commentProperty != null)
                    {
                        object value = commentProperty.GetValue(arjArchive);
                        comment = value as string ?? string.Empty;
                    }
                }

                File.WriteAllText(outputPath, comment);
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
 * 1. When you need to extract the descriptive comment embedded in an ARJ archive for documentation or logging purposes.
 * 2. When you want to verify or display the archive's metadata before extracting its contents in a .NET application.
 * 3. When you are building a migration tool that reads ARJ comments to preserve metadata in a new archive format.
 * 4. When you need to audit archived files by saving their comments to a separate report file for compliance.
 * 5. When you are debugging compression pipelines and want to compare the original ARJ comment with processed data.
 */
