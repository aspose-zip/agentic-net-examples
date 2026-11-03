// HOW-TO: Compress Multiple XML Files into AES128 Encrypted ZIP in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Aspose.Zip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = @"C:\Data\XmlFiles";
            string outputPath = @"C:\Output\EncryptedArchive.zip";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            List<string> xmlFiles = new List<string>
            {
                Path.Combine(inputDirectory, "file1.xml"),
                Path.Combine(inputDirectory, "file2.xml"),
                Path.Combine(inputDirectory, "file3.xml")
            };

            List<FileStream> openedStreams = new List<FileStream>();

            using (Archive archive = new Archive())
            {
                foreach (string filePath in xmlFiles)
                {
                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        continue;
                    }

                    FileStream sourceStream = File.Open(filePath, FileMode.Open, FileAccess.Read);
                    openedStreams.Add(sourceStream);

                    ArchiveEntrySettings entrySettings = new ArchiveEntrySettings(
                        new EnhancedDeflateCompressionSettings(),
                        new AesEcryptionSettings(EncryptionMethod.AES128)
                    );

                    archive.CreateEntry(Path.GetFileName(filePath), sourceStream, entrySettings);
                }

                using (FileStream zipFile = File.Open(outputPath, FileMode.Create))
                {
                    ArchiveSaveOptions saveOptions = new ArchiveSaveOptions
                    {
                        Encoding = Encoding.UTF8
                    };
                    archive.Save(zipFile, saveOptions);
                }
            }

            foreach (FileStream stream in openedStreams)
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
 * 1. When you need to securely bundle configuration XML files for transmission to a remote server.
 * 2. When you want to create a compressed backup of XML data with AES128 protection to meet compliance requirements.
 * 3. When an application must package generated XML reports into a single encrypted archive before emailing them to clients.
 * 4. When a deployment script has to archive multiple XML configuration files with strong encryption to prevent unauthorized access.
 * 5. When you are building a data‑exchange service that compresses and encrypts XML payloads into a ZIP file for safe storage in cloud storage.
 */
