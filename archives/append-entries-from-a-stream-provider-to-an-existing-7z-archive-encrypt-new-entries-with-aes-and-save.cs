// HOW-TO: Append Files to Existing 7z Archive with AES Encryption in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Zip;
using Aspose.Zip.SevenZip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string inputArchivePath = "input.7z";
            string outputArchivePath = "output.7z";
            string dataDir = "Data";
            string password = "MyPassword";

            // Verify input archive exists
            if (!File.Exists(inputArchivePath))
            {
                Console.Error.WriteLine($"File not found: {inputArchivePath}");
                return;
            }

            // Verify source data directory exists
            if (!Directory.Exists(dataDir))
            {
                Console.Error.WriteLine($"Directory not found: {dataDir}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputArchivePath) ?? ".");

            // List to keep entry streams open until archive is saved
            List<FileStream> entryStreams = new List<FileStream>();

            using (SevenZipArchive archive = new SevenZipArchive(inputArchivePath))
            {
                // Add each file from the data directory as an encrypted entry
                foreach (string filePath in Directory.GetFiles(dataDir))
                {
                    string entryName = Path.GetFileName(filePath);
                    FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
                    entryStreams.Add(stream);

                    SevenZipEntrySettings entrySettings = new SevenZipEntrySettings(
                        null,
                        new SevenZipAESEncryptionSettings(password)
                    );

                    archive.CreateEntry(entryName, stream, entrySettings);
                }

                // Save the updated archive to the output path
                archive.Save(outputArchivePath);
            }

            // Dispose all entry streams after saving
            foreach (FileStream stream in entryStreams)
            {
                stream.Dispose();
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
 * 1. When you need to add new documents to a previously created 7z backup while keeping the archive password‑protected.
 * 2. When you want to programmatically merge log files into an existing compressed package and ensure the added files are encrypted with AES.
 * 3. When a deployment script must update a secure 7z bundle with configuration files supplied as streams without recreating the whole archive.
 * 4. When an application stores sensitive reports in a 7z container and later needs to append additional reports while preserving encryption.
 * 5. When a data‑archiving service receives file streams from a client and must append them to an existing encrypted 7z archive for long‑term storage.
 */
