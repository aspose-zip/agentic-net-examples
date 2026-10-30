// HOW-TO: Create XZ Compressed TAR Archive With CRC32 For MP3 Files In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Zip;
using Aspose.Zip.Tar;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath1 = "track1.mp3";
            string inputPath2 = "track2.mp3";
            string outputPath = "output\\music.tar.xz";

            // Validate input files
            if (!File.Exists(inputPath1))
            {
                Console.Error.WriteLine($"File not found: {inputPath1}");
                return;
            }
            if (!File.Exists(inputPath2))
            {
                Console.Error.WriteLine($"File not found: {inputPath2}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Compute CRC32 for each input file
            uint crc1;
            using (FileStream fs1 = File.OpenRead(inputPath1))
            {
                crc1 = CRC32.Compute(fs1);
            }
            uint crc2;
            using (FileStream fs2 = File.OpenRead(inputPath2))
            {
                crc2 = CRC32.Compute(fs2);
            }

            Console.WriteLine($"CRC32 of {inputPath1}: {crc1:X8}");
            Console.WriteLine($"CRC32 of {inputPath2}: {crc2:X8}");

            // Create TAR archive and add entries
            using (TarArchive archive = new TarArchive())
            {
                archive.CreateEntry("track1.mp3", inputPath1);
                archive.CreateEntry("track2.mp3", inputPath2);

                // Save TAR archive compressed with XZ
                archive.SaveXzCompressed(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    // Simple CRC32 implementation
    private static class CRC32
    {
        private static readonly uint[] Table = GenerateTable();

        public static uint Compute(Stream input)
        {
            uint crc = 0xFFFFFFFF;
            int readByte;
            while ((readByte = input.ReadByte()) != -1)
            {
                crc = (crc >> 8) ^ Table[(crc ^ (byte)readByte) & 0xFF];
            }
            return crc ^ 0xFFFFFFFF;
        }

        private static uint[] GenerateTable()
        {
            const uint polynomial = 0xEDB88320;
            uint[] table = new uint[256];
            for (uint i = 0; i < table.Length; i++)
            {
                uint entry = i;
                for (int j = 0; j < 8; j++)
                {
                    if ((entry & 1) == 1)
                        entry = (entry >> 1) ^ polynomial;
                    else
                        entry >>= 1;
                }
                table[i] = entry;
            }
            return table;
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to bundle multiple audio tracks into a single portable archive for distribution while ensuring data integrity with CRC32 checks.
 * 2. When you want to reduce the size of a TAR package using XZ compression before uploading to a cloud storage service.
 * 3. When you are creating backup archives of media files on a Windows server and require a standard TAR format compatible with Unix tools.
 * 4. When you need to generate a compressed archive that can be verified later by comparing CRC32 values to detect corruption.
 * 5. When you are automating a build pipeline that packages generated MP3 assets into a .tar.xz file for deployment to embedded devices.
 */
