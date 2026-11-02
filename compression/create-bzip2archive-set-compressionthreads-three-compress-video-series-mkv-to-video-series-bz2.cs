// HOW-TO: Compress MKV Video to BZ2 Using Aspose.Zip Bzip2Archive C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Bzip2;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\Data\video_series.mkv";
            string outputPath = @"C:\Data\video_series.bz2";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Bzip2Archive archive = new Bzip2Archive())
            {
                archive.SetSource(inputPath);
                archive.Save(outputPath);
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
 * 1. When you need to reduce the size of a large MKV video file for faster network transfer or storage, you can use Aspose.Zip Bzip2Archive in C# to create a .bz2 archive.
 * 2. When automating a media pipeline that archives daily video recordings, this code compresses each .mkv into a BZIP2 file before uploading to cloud storage.
 * 3. When implementing a backup solution for surveillance footage, developers can use the Bzip2Archive to compress videos while preserving the original format.
 * 4. When building a desktop utility that prepares video files for email attachment, the BZIP2 compression reduces the file size without requiring external tools.
 * 5. When integrating video compression into a C# application that processes large media assets, the Aspose.Zip Bzip2Archive provides a simple API to generate .bz2 archives programmatically.
 */
