// HOW-TO: Extract ALZ Archive With Checksum Verification And Cancellation In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Threading;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\Data\sample.alz";
            string outputPath = @"C:\Data\Extracted";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            CancellationTokenSource cts = new CancellationTokenSource();

            ArchiveLoadOptions loadOptions = new ArchiveLoadOptions();
            loadOptions.SkipChecksumVerification = false;
            loadOptions.CancellationToken = cts.Token;

            using (Archive archive = new Archive(inputPath, loadOptions))
            {
                try
                {
                    archive.ExtractToDirectory(outputPath);
                    Console.WriteLine("Extraction completed successfully.");
                }
                catch (OperationCanceledException)
                {
                    Console.Error.WriteLine("Extraction was canceled.");
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"Checksum verification failed: {ex.Message}");
                }
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
 * 1. When you need to extract a large ALZ backup file in a .NET application while ensuring data integrity by verifying checksums and allowing the operation to be cancelled if it takes too long.
 * 2. When building an automated deployment script that processes compressed ALZ packages and must stop the extraction gracefully on user request or timeout without ignoring checksum errors.
 * 3. When integrating Aspose.Zip into a Windows service that monitors incoming ALZ archives, validates their integrity, and extracts their contents to a specific folder, handling any corrupted files separately.
 * 4. When creating a desktop utility that lets users unpack ALZ archives and you want to provide clear error messages for checksum failures distinct from cancellation events.
 * 5. When developing a batch processing tool that reads multiple ALZ archives, uses a CancellationToken to abort extraction on demand, and logs checksum verification problems for later analysis.
 */
