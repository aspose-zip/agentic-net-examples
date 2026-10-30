// HOW-TO: Create CAB Archive from Folder Including Root Directory in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Cab;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input directory and output CAB file paths
            string inputDirectory = @"C:\SourceFolder";
            string outputPath = @"C:\Archives\output.cab";

            // Verify the input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a CAB archive, include the root directory, and save it
            using (CabArchive archive = new CabArchive())
            {
                archive.CreateEntries(inputDirectory, true);
                archive.Save(outputPath);
            }

            Console.WriteLine($"CAB archive created at: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to package a set of application files into a single CAB file for Windows deployment, this code creates the archive while preserving the original folder structure.
 * 2. When distributing driver binaries or system resources, you can use this snippet to compress the source directory into a CAB file that can be installed by Windows Setup.
 * 3. When automating backup of configuration files, the code lets you generate a CAB archive that includes the root folder, making restoration straightforward.
 * 4. When creating an installer that requires a CAB package for embedded resources, this example shows how to programmatically build the archive in C#.
 * 5. When you want to send a complete directory over a network as a single compressed file, the code produces a CAB archive that retains the directory hierarchy for the receiver.
 */
