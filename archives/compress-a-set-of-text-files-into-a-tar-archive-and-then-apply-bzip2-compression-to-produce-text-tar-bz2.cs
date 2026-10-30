// HOW-TO: Create BZIP2 Compressed TAR Archive from Multiple Text Files in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Zip;
using Aspose.Zip.Tar;
using Aspose.Zip.Bzip2;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Base directory containing the text files
            string dataDir = @"C:\Data\";

            // List of text files to include in the archive
            string[] files = new string[]
            {
                "file1.txt",
                "file2.txt",
                "file3.txt"
            };

            // Verify that each input file exists
            foreach (string fileName in files)
            {
                string inputPath = Path.Combine(dataDir, fileName);
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Path for the intermediate TAR archive
            string tarPath = Path.Combine(dataDir, "text.tar");
            Directory.CreateDirectory(Path.GetDirectoryName(tarPath));

            // Create TAR archive and add files
            using (TarArchive tar = new TarArchive())
            {
                foreach (string fileName in files)
                {
                    string sourcePath = Path.Combine(dataDir, fileName);
                    tar.CreateEntry(fileName, sourcePath);
                }
                tar.Save(tarPath);
            }

            // Path for the final BZIP2-compressed archive
            string bz2Path = Path.Combine(dataDir, "text.tar.bz2");
            Directory.CreateDirectory(Path.GetDirectoryName(bz2Path));

            // Compress the TAR archive using BZIP2
            using (Bzip2Archive bz2 = new Bzip2Archive())
            {
                bz2.SetSource(tarPath);
                bz2.Save(bz2Path);
            }

            Console.WriteLine("Compression completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to bundle several log or report files into a single archive for efficient storage or transfer, you can create a TAR archive and then compress it with BZIP2 using C#.
 * 2. When deploying configuration files to a Linux server, you may want to package them as a .tar.bz2 file to preserve file permissions and achieve high compression before uploading via SCP.
 * 3. When backing up daily generated text reports, you can automate the creation of a compressed TAR archive to reduce disk usage and simplify archiving processes in a .NET application.
 * 4. When sending multiple source code snippets or documentation files through email, compressing them into a .tar.bz2 file ensures they stay together and remain smaller for attachment limits.
 * 5. When integrating with third‑party tools that only accept BZIP2‑compressed TAR archives, you can generate the required .tar.bz2 file programmatically in C#.
 */
