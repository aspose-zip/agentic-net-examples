// HOW-TO: Extract All Files From a Password‑Protected ALZ Archive in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\Data\sample.zip";
            string outputDirectory = @"C:\Data\Extracted";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            using (FileStream zipStream = File.Open(inputPath, FileMode.Open, FileAccess.Read))
            {
                using (Archive archive = new Archive(zipStream))
                {
                    archive.ExtractToDirectory(outputDirectory);
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
 * 1. When you need to programmatically unpack a secured ALZ backup received from a partner system.
 * 2. When an automated deployment script must read confidential configuration files stored in a password‑protected ALZ package.
 * 3. When a desktop application offers users the ability to open encrypted ALZ archives and extract their contents to a chosen folder.
 * 4. When a server process has to process log files that are delivered daily as password‑protected ALZ archives.
 * 5. When migrating data from legacy ALZ archives to a new storage location while preserving security by using the archive password.
 */
