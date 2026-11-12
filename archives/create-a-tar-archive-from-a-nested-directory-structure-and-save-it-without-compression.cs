// HOW-TO: Create Uncompressed TAR Archive from Nested Directory in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Tar;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Define the source directory containing the nested files and folders
            string inputDirectory = "C:\\Data\\NestedFolder";

            // Define the output TAR file path (no compression)
            string outputPath = "C:\\Output\\archive.tar";

            // Verify that the source directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a TAR archive and add all entries from the source directory
            using (TarArchive tarArchive = new TarArchive())
            {
                // Recursively add files and subfolders from the input directory
                tarArchive.CreateEntries(inputDirectory);

                // Save the TAR archive to the specified path without compression
                tarArchive.Save(outputPath);
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
 * 1. When you need to package a project's source files and subfolders into a single TAR file for distribution without compression, such as preparing a source code bundle for Linux users.
 * 2. When you want to create a lightweight backup of a nested directory structure that can be easily extracted on Unix systems, preserving the original folder hierarchy.
 * 3. When deploying configuration files to a server that expects an uncompressed TAR archive, allowing the deployment script to unpack the files quickly.
 * 4. When integrating with a third‑party tool that only accepts TAR archives and you must include all subdirectories while keeping the archive size minimal by avoiding compression.
 * 5. When archiving log files from multiple nested folders for compliance audits, generating a plain TAR file that can be stored or transferred without the overhead of compression.
 */
