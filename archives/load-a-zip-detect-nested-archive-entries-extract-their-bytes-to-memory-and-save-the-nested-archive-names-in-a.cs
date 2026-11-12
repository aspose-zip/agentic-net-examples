// HOW-TO: Identify and Report Nested Archives Inside a ZIP Using C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using Aspose.Zip;
using Aspose.Zip.ArchiveInfo;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputZipPath = "input.zip";
            string reportPath = "output/nested_report.txt";

            if (!File.Exists(inputZipPath))
            {
                Console.Error.WriteLine($"File not found: {inputZipPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(reportPath));

            List<string> nestedArchiveNames = new List<string>();

            using (Archive archive = new Archive(inputZipPath))
            {
                foreach (ArchiveEntry entry in archive.Entries)
                {
                    if (entry.IsDirectory)
                    {
                        continue;
                    }

                    using (Stream entryStream = entry.Open())
                    {
                        ArchiveInstanceInfo instanceInfo = ArchiveInstanceInfo.GetArchiveInstanceInfo(entryStream);
                        if (instanceInfo != null && instanceInfo.FormatInfo != null && instanceInfo.FormatInfo.Format != ArchiveFormat.Unknown)
                        {
                            if (entryStream.CanSeek)
                            {
                                entryStream.Position = 0;
                            }

                            using (MemoryStream memory = new MemoryStream())
                            {
                                entryStream.CopyTo(memory);
                            }

                            nestedArchiveNames.Add(entry.Name);
                        }
                    }
                }
            }

            using (StreamWriter writer = new StreamWriter(reportPath, false, Encoding.UTF8))
            {
                foreach (string name in nestedArchiveNames)
                {
                    writer.WriteLine(name);
                }
            }

            Console.WriteLine("Nested archive report generated at: " + reportPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to scan a received ZIP file for embedded archives such as ZIP, RAR, or 7z before processing its contents.
 * 2. When you want to generate a list of all inner archive files to audit or log what compressed files are bundled inside a package.
 * 3. When a security tool must detect potentially hidden malicious archives nested within a main archive without extracting them to disk.
 * 4. When an application must read the bytes of each nested archive into memory for further in‑memory analysis or re‑compression.
 * 5. When you need to create a text report of nested archive names for documentation, compliance, or troubleshooting purposes.
 */
