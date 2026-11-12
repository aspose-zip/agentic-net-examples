// HOW-TO: Abort ZIP Extraction on Specific File Using Cancellation Token in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Threading;
using Aspose.Zip;
using Aspose.Zip.ArchiveInfo;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Data\archive.zip";
            string outputPath = @"C:\Data\Extracted";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory's parent exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Cancellation token source to abort extraction
            CancellationTokenSource cts = new CancellationTokenSource();

            // Load the archive with cancellation support
            ArchiveLoadOptions loadOptions = new ArchiveLoadOptions()
            {
                CancellationToken = cts.Token
            };

            using (Archive archive = new Archive(inputPath, loadOptions))
            {
                foreach (ArchiveEntry entry in archive.Entries)
                {
                    // Stop processing if cancellation was requested
                    if (cts.Token.IsCancellationRequested)
                    {
                        break;
                    }

                    // Abort when the specified entry is encountered
                    if (string.Equals(entry.Name, "secret.docx", StringComparison.OrdinalIgnoreCase))
                    {
                        cts.Cancel();
                        Console.WriteLine("Extraction aborted upon encountering secret.docx");
                        break;
                    }

                    // Determine destination file path
                    string destinationFile = Path.Combine(outputPath, entry.Name);

                    // Ensure the destination directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(destinationFile));

                    // Extract the entry to the destination file
                    using (FileStream fileStream = new FileStream(destinationFile, FileMode.Create, FileAccess.Write))
                    {
                        entry.Extract(fileStream);
                    }
                }
            }

            // Report partial extraction status
            if (cts.IsCancellationRequested)
            {
                Console.WriteLine("Partial extraction completed. Some files may be missing due to cancellation.");
            }
            else
            {
                Console.WriteLine("Extraction completed successfully.");
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
 * 1. When you need to extract a large ZIP archive but stop as soon as a confidential file like secret.docx is encountered, while keeping the files already extracted.
 * 2. When you want to add programmatic cancellation to a .NET ZIP extraction process to avoid processing unwanted or potentially harmful entries.
 * 3. When you must enforce security policies that prohibit certain file types by aborting extraction automatically upon detecting those files.
 * 4. When you are building a batch extraction tool that should report partial results if the operation is interrupted by a specific file condition.
 * 5. When you require loading a ZIP archive with custom options and gracefully handling early termination without corrupting the output directory.
 */
