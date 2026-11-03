// HOW-TO: Extract RAR Archive in C# and Cancel After Config.ini (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Threading;
using Aspose.Zip.Rar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\Data\archive.rar";
            string outputDir = @"C:\Data\Extracted";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            CancellationTokenSource cts = new CancellationTokenSource();

            RarArchiveLoadOptions loadOptions = new RarArchiveLoadOptions()
            {
                CancellationToken = cts.Token
            };

            using (FileStream fs = File.OpenRead(inputPath))
            using (RarArchive archive = new RarArchive(fs, loadOptions))
            {
                foreach (RarArchiveEntry entry in archive.Entries)
                {
                    cts.Token.ThrowIfCancellationRequested();

                    string entryOutputPath = Path.Combine(outputDir, entry.Name);
                    Directory.CreateDirectory(Path.GetDirectoryName(entryOutputPath));

                    entry.Extract(entryOutputPath);

                    if (string.Equals(entry.Name, "config.ini", StringComparison.OrdinalIgnoreCase))
                    {
                        cts.Cancel();
                    }
                }
            }
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Extraction cancelled after reaching config.ini.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to extract files from a large RAR archive but stop processing once a specific configuration file (e.g., config.ini) is found to reduce I/O overhead.
 * 2. When implementing a security scan that extracts only up to a particular entry in a RAR archive to verify its presence without exposing the rest of the contents.
 * 3. When building a deployment tool that unpacks a RAR package and aborts further extraction after retrieving the required settings file.
 * 4. When creating a backup restoration script that reads a RAR archive and cancels extraction after locating the manifest file to avoid overwriting existing data.
 * 5. When developing a diagnostic utility that loads a RAR archive with a cancellation token to gracefully stop extraction once a target entry is processed.
 */
