// HOW-TO: Extract XAR Archive Entry to Directory in C# with Aspose.Zip (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Xar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string archivePath = @"C:\Data\sample.xar";
            string outputFolder = @"C:\Output\Extracted";

            if (!File.Exists(archivePath))
            {
                Console.Error.WriteLine($"File not found: {archivePath}");
                return;
            }

            Directory.CreateDirectory(outputFolder);

            using (FileStream fs = File.OpenRead(archivePath))
            using (XarArchive archive = new XarArchive(fs))
            {
                archive.ExtractToDirectory(outputFolder);
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
 * 1. When you need to unpack a specific XAR package received from a macOS installer to a local folder for further processing.
 * 2. When a deployment script must extract configuration files from a XAR archive before copying them to a server.
 * 3. When a backup utility restores selected files from a compressed XAR backup into a designated directory.
 * 4. When an automated test extracts test data stored in a XAR archive to validate file contents during CI builds.
 * 5. When a migration tool reads a XAR archive containing legacy assets and extracts them to a new project structure.
 */
