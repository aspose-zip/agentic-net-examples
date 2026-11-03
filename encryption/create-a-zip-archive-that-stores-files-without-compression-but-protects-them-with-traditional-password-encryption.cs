// HOW-TO: Create Uncompressed Password Protected ZIP Archive in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Text;
using Aspose.Zip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputFile1 = "C:\\Data\\file1.txt";
            string inputFile2 = "C:\\Data\\file2.txt";
            string outputZip = "C:\\Output\\archive.zip";

            // Verify input files exist
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
            Directory.CreateDirectory(Path.GetDirectoryName(outputZip));

            // Open output stream for the ZIP archive
            using (FileStream zipStream = File.Open(outputZip, FileMode.Create))
            {
                // Define password and create archive with store (no compression) and traditional encryption
                string password = "Secret123";
                using (Archive archive = new Archive(new ArchiveEntrySettings(new StoreCompressionSettings(), new TraditionalEncryptionSettings(password))))
                {
                    // Add files to the archive
                    FileInfo fi1 = new FileInfo(inputFile1);
                    FileInfo fi2 = new FileInfo(inputFile2);
                    archive.CreateEntry("file1.txt", fi1);
                    archive.CreateEntry("file2.txt", fi2);

                    // Save the archive with ASCII encoding
                    archive.Save(zipStream, new ArchiveSaveOptions() { Encoding = Encoding.ASCII });
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
 * 1. When you need to bundle log files into a ZIP without slowing down the process and still keep them secure with a password.
 * 2. When you must distribute configuration files to clients but want to prevent casual viewing while preserving original file sizes.
 * 3. When an automated backup script creates archives that must be quickly written and later opened only by authorized users.
 * 4. When regulatory compliance requires storing documents in an encrypted archive but the data is already compressed, so additional compression is unnecessary.
 * 5. When a .NET application needs to generate a ZIP for legacy systems that only support traditional password encryption and store (no) compression.
 */
