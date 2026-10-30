// HOW-TO: Create a CAB Archive from Multiple Files with Default MSZip Compression in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Cab;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputFile1 = @"C:\Temp\file1.txt";
            string inputFile2 = @"C:\Temp\file2.html";
            string outputCab = @"C:\Temp\output.cab";

            // Validate input files
            if (!File.Exists(inputFile1))
            {
                Console.Error.WriteLine($"File not found: {inputFile1}");
                return;
            }
            if (!File.Exists(inputFile2))
            {
                Console.Error.WriteLine($"File not found: {inputFile2}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputCab));

            // Default MSZip compression settings
            CabEntrySettings defaultSettings = new CabEntrySettings(new CabMsZipCompressionSettings());

            using (CabArchive archive = new CabArchive(defaultSettings))
            {
                // Add files with default compression
                archive.CreateEntry("file1.txt", inputFile1);
                archive.CreateEntry("file2.html", inputFile2);

                // Save the CAB archive
                archive.Save(outputCab);
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
 * 1. When you need to package configuration and HTML files into a single CAB file for a Windows installer, this code creates the archive with default MSZip compression.
 * 2. When distributing several small resources together to reduce the number of files on a network share, you can use this snippet to bundle them into a CAB archive in C#.
 * 3. When an application must generate a CAB file on the fly for legacy Windows components that only accept CAB packages, this example shows how to create and save it programmatically.
 * 4. When you want to compress log and report files into a CAB container before uploading them to a server, the code demonstrates the required steps in .NET.
 * 5. When automating a build process that needs to archive build artifacts into a CAB format for later extraction, this sample provides the C# implementation using Aspose.Zip.
 */
