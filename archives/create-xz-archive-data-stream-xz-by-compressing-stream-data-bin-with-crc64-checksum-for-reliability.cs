// HOW-TO: Create XZ Archive with CRC64 from Binary File in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Xz;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "stream_data.bin";
            string outputPath = "data_stream.xz";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (FileStream inputStream = File.OpenRead(inputPath))
            using (FileStream outputStream = File.Open(outputPath, FileMode.Create))
            using (XzArchive archive = new XzArchive())
            {
                archive.SetSource(inputStream);
                archive.Save(outputStream);
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
 * 1. When you need to compress large binary logs into a space‑efficient XZ file while ensuring data integrity with CRC64 in a C# application.
 * 2. When you want to create portable XZ archives of configuration files for distribution to Linux servers from a .NET service.
 * 3. When you are implementing a backup routine that stores sensor data streams as XZ archives to reduce storage costs and detect corruption on restore.
 * 4. When you need to generate XZ‑compressed packages for software updates in a Windows build pipeline using Aspose.Zip for .NET.
 * 5. When you are archiving temporary files from a desktop utility and require a reliable checksum to verify the archive after transfer.
 */
