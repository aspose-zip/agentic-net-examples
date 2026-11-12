// HOW-TO: Compress TIFF Image to BZIP2 Archive with Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Bzip2;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Data\image_series.tif";
            string outputPath = @"C:\Data\series.bz2";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create Bzip2 archive and compress the file
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
 * 1. When you need to reduce the size of large TIFF medical images before sending them over a network, you can compress them into a BZIP2 file using Aspose.Zip in C#.
 * 2. When building a data‑archiving pipeline that stores high‑resolution satellite photos, you can create BZIP2 archives of each TIFF file to save disk space.
 * 3. When implementing a backup solution for design assets, you can compress TIFF drawings into .bz2 files to keep the archive format consistent and easily extractable later.
 * 4. When automating a workflow that prepares image series for long‑term storage, you can use Aspose.Zip to generate BZIP2 archives directly from C# without external tools.
 * 5. When integrating file compression into a .NET application that processes scanned documents, you can programmatically create BZIP2 archives of the TIFF files for efficient storage and retrieval.
 */
