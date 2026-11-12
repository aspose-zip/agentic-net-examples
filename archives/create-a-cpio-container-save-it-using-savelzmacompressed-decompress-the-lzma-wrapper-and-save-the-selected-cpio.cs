// HOW-TO: Create LZMA Compressed CPIO Archive and Extract Entry Header in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Cpio;
using Aspose.Zip.LZMA;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define paths
            string dataDir = "Data";
            string sourceFilePath = Path.Combine(dataDir, "sample.txt");
            string cpioLzmaPath = Path.Combine(dataDir, "archive.cpio.lzma");
            string extractedHeaderPath = Path.Combine(dataDir, "entryHeader.bin");
            string tempCpioPath = Path.Combine(dataDir, "temp.cpio");

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(cpioLzmaPath));
            Directory.CreateDirectory(Path.GetDirectoryName(extractedHeaderPath));
            Directory.CreateDirectory(Path.GetDirectoryName(tempCpioPath));

            // Validate input file
            if (!File.Exists(sourceFilePath))
            {
                Console.Error.WriteLine($"File not found: {sourceFilePath}");
                return;
            }

            // Create CPIO archive and add entry
            using (CpioArchive cpio = new CpioArchive())
            {
                cpio.CreateEntry("sample.txt", sourceFilePath);
                // Save the archive compressed with LZMA
                cpio.SaveLZMACompressed(cpioLzmaPath);
            }

            // Decompress LZMA wrapper to obtain the CPIO archive
            using (LzmaArchive lzma = new LzmaArchive(cpioLzmaPath))
            {
                using (FileStream outStream = File.Create(tempCpioPath))
                {
                    lzma.Extract(outStream);
                }
            }

            // Open the extracted CPIO archive and retrieve header bytes of the first entry
            using (CpioArchive extractedCpio = new CpioArchive(tempCpioPath))
            {
                if (extractedCpio.Entries.Count > 0)
                {
                    CpioEntry entry = extractedCpio.Entries[0];
                    using (MemoryStream ms = new MemoryStream())
                    {
                        entry.Extract(ms);
                        byte[] headerBytes = ms.ToArray();
                        File.WriteAllBytes(extractedHeaderPath, headerBytes);
                    }
                }
                else
                {
                    Console.Error.WriteLine("No entries found in the CPIO archive.");
                    return;
                }
            }

            // Clean up temporary CPIO file
            if (File.Exists(tempCpioPath))
            {
                File.Delete(tempCpioPath);
            }

            Console.WriteLine("CPIO entry header saved successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to package a file into a CPIO archive and compress it with LZMA for efficient storage or transmission in a .NET application.
 * 2. When you must decompress an LZMA‑wrapped CPIO file to access its contents without using external tools.
 * 3. When you want to read the raw header bytes of a specific CPIO entry to verify metadata or implement custom parsing logic.
 * 4. When you are building a backup solution that stores files in CPIO format and requires LZMA compression to reduce backup size.
 * 5. When you need to programmatically extract and save low‑level archive information, such as entry headers, for forensic analysis or debugging.
 */
