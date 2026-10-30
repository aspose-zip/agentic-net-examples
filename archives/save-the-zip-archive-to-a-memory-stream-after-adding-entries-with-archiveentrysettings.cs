// HOW-TO: Create ZIP Archive in Memory Stream and Save to File in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input files
            string dataDir = "Data\\";
            string inputFile1 = dataDir + "file1.txt";
            string inputFile2 = dataDir + "file2.txt";

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

            // Create a new ZIP archive
            using (Archive archive = new Archive())
            {
                archive.CreateEntry("file1.txt", inputFile1);
                archive.CreateEntry("file2.txt", inputFile2);

                // Save the archive to a memory stream
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    archive.Save(memoryStream);

                    // Write the memory stream to a file
                    string outputPath = "Output\\result.zip";
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                    File.WriteAllBytes(outputPath, memoryStream.ToArray());
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
 * 1. When you need to bundle multiple text files into a ZIP archive on the fly without writing intermediate files to disk, you can create the archive in a memory stream and then save it as a single .zip file.
 * 2. When generating downloadable reports in a web application, you can compress the report files into a ZIP using a memory stream to avoid temporary storage and then send the byte array to the client.
 * 3. When implementing a background service that archives log files nightly, using a memory stream lets you build the ZIP in memory before writing it to a network share or cloud storage.
 * 4. When creating a ZIP file for email attachment in a desktop app, you can assemble the archive in memory to ensure the attachment size is known before attaching it to the message.
 * 5. When testing compression logic in unit tests, storing the ZIP in a memory stream allows you to verify the archive contents without creating physical files on the test machine.
 */
