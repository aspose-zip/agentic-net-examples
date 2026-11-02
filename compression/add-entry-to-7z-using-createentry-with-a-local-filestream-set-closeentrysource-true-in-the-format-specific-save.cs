// HOW-TO: Add File to 7z Archive From Stream in C# Using Aspose.Zip (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.SevenZip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFilePath = "data.txt";
            string outputArchivePath = "streamed_entries.7z";

            if (!File.Exists(inputFilePath))
            {
                Console.Error.WriteLine($"File not found: {inputFilePath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputArchivePath));

            using (FileStream sourceStream = File.Open(inputFilePath, FileMode.Open, FileAccess.Read))
            using (FileStream archiveStream = File.Open(outputArchivePath, FileMode.Create))
            using (SevenZipArchive archive = new SevenZipArchive())
            {
                archive.CreateEntry("data.txt", sourceStream);
                archive.Save(archiveStream);
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
 * 1. When you need to compress a large log file on the fly without loading it entirely into memory, you can stream it into a 7z archive using Aspose.Zip in C#.
 * 2. When building a backup utility that stores individual files directly into a 7z container as they are generated, this code lets you add each file via a FileStream.
 * 3. When creating a downloadable package that includes dynamically created reports, you can stream each report into a 7z archive to reduce disk I/O and improve performance.
 * 4. When integrating file archiving into a web service that receives file uploads, you can immediately write the uploaded stream into a 7z archive without temporary files.
 * 5. When automating deployment scripts that need to bundle configuration files into a compressed 7z bundle, this approach allows you to add files from streams and close the source automatically.
 */
