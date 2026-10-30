// HOW-TO: Extract All Files from a XAR Archive to Folder in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Xar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.xar";
            string outputDirectory = "extracted";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            using (FileStream fs = File.OpenRead(inputPath))
            using (XarArchive archive = new XarArchive(fs))
            {
                archive.ExtractToDirectory(outputDirectory);
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
 * 1. When you need to unpack a software package distributed as a XAR file to access its individual resources on a Windows server.
 * 2. When a build pipeline must automatically extract configuration files from a XAR archive before compiling a .NET application.
 * 3. When a backup restoration script has to retrieve specific documents stored inside a compressed XAR backup to a target directory.
 * 4. When a migration tool reads legacy XAR archives and extracts their contents to a new file system layout for further processing.
 * 5. When a user interface allows end‑users to select a XAR bundle and extracts all its files to a chosen folder for inspection or editing.
 */
