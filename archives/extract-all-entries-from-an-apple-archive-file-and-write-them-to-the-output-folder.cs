// HOW-TO: Extract All Files From an Apple Archive (AAR) Using C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input Apple Archive file and output folder
            string inputPath = "input.aar";
            string outputPath = "output";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory's parent exists (as per safety rule)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open the Apple Archive
            using (Archive archive = new Archive(inputPath))
            {
                // Iterate through all entries and extract them
                foreach (ArchiveEntry entry in archive.Entries)
                {
                    string destinationFile = Path.Combine(outputPath, entry.Name);

                    // Ensure the directory for the entry exists
                    Directory.CreateDirectory(Path.GetDirectoryName(destinationFile));

                    // Extract the entry
                    using (Stream entryStream = entry.Open())
                    using (FileStream fileStream = File.Create(destinationFile))
                    {
                        entryStream.CopyTo(fileStream);
                    }
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
 * 1. When you need to unpack resources from an iOS .aar package to a local folder for further processing.
 * 2. When a build pipeline must automatically extract bundled assets from an Apple Archive before packaging them into an app.
 * 3. When a desktop utility needs to read and copy all files from an AAR file to allow users to view its contents.
 * 4. When migrating legacy Apple Archive data to a new file system and you require a programmatic way to extract every entry in C#.
 * 5. When performing automated testing that validates the integrity of files inside an .aar by extracting them to a temporary directory.
 */
