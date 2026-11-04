// HOW-TO: Extract Password‑Protected Multi‑Volume 7z Archive to Directory in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.SevenZip;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded paths
        string inputPath = @"C:\Archives\multi_volume.7z"; // first volume of the multi‑volume archive
        string password = "YourPasswordHere";
        string outputPath = @"C:\Extracted\extracted_7z";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory (and its parent) exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the multi‑volume 7z archive with password
            using (SevenZipArchive archive = new SevenZipArchive(inputPath, password))
            {
                // Extract all entries to the target directory
                archive.ExtractToDirectory(outputPath);
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
 * 1. When you need to programmatically unpack a split 7z backup that is encrypted with a password into a specific folder.
 * 2. When an application must automatically extract large, multi‑part 7z installers that are password‑protected to prepare files for installation.
 * 3. When a server process has to retrieve confidential data stored across several encrypted 7z volumes and place the contents in a working directory.
 * 4. When you want to integrate Aspose.Zip into a C# tool that processes archived logs split into numbered 7z parts secured with a password.
 * 5. When a deployment script must read the first part of a password‑protected multi‑volume archive and extract all files without manual user interaction.
 */
