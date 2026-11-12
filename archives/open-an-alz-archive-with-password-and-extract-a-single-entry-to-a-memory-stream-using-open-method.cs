// HOW-TO: Extract a Single File From Password Protected ALZ Archive To Memory Stream In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Hardcoded input archive path
            string inputPath = "sample.alz";

            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Set the password for the ALZ archive
            ArchiveLoadOptions loadOptions = new ArchiveLoadOptions();
            loadOptions.DecryptionPassword = "password123";

            // Open the archive with the specified password
            using (Archive archive = new Archive(inputPath, loadOptions))
            {
                // Name of the entry to extract
                string entryName = "document.txt";

                // Locate the entry
                ArchiveEntry targetEntry = null;
                foreach (ArchiveEntry e in archive.Entries)
                {
                    if (e.Name.Equals(entryName, StringComparison.OrdinalIgnoreCase))
                    {
                        targetEntry = e;
                        break;
                    }
                }

                if (targetEntry == null)
                {
                    Console.Error.WriteLine($"Entry not found: {entryName}");
                    return;
                }

                // Extract the entry to a memory stream using Open
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (Stream entryStream = targetEntry.Open())
                    {
                        entryStream.CopyTo(memoryStream);
                    }

                    // The entry data is now in memoryStream
                    Console.WriteLine($"Extracted '{entryName}' to memory stream, size: {memoryStream.Length} bytes.");
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
 * 1. When you need to read a specific document from a password‑protected ALZ backup without writing it to disk.
 * 2. When you want to process the contents of a compressed file directly in memory for faster performance in a C# application.
 * 3. When you are building a web service that receives an encrypted ALZ archive and must return a particular file to the client on the fly.
 * 4. When you need to validate or scan a single entry inside a secured archive for malware before extracting the rest.
 * 5. When you are developing a mobile or sandboxed app that cannot write temporary files and must extract data from a protected archive into a stream.
 */
