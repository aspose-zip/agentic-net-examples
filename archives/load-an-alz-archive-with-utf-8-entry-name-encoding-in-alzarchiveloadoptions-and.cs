// HOW-TO: Read and List Entries From an ALZ Archive Using C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "sample.alz";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (Archive archive = new Archive(inputPath))
            {
                Console.WriteLine("Entries in the ALZ archive:");
                foreach (ArchiveEntry entry in archive.Entries)
                {
                    Console.WriteLine(entry.Name);
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
 * 1. When a developer wants to display the list of files contained in an ALZ backup before extracting them in a C# application.
 * 2. When a system needs to verify that an ALZ archive created with UTF‑8 entry names contains the expected documents during a deployment script.
 * 3. When building a file‑management UI that shows archive contents, the code can read the ALZ archive and populate the entry list for user selection.
 * 4. When performing an integrity check, a developer can load the ALZ archive and enumerate its entries to ensure no corruption before processing.
 * 5. When logging audit information, the program can enumerate the ALZ archive entries and write their names to a log file for compliance tracking.
 */
