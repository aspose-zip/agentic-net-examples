// HOW-TO: Add Files to ZIP with NTFS Attributes Preserved in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Text;
using Aspose.Zip;
using Aspose.Zip.Saving;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath1 = @"C:\Data\file1.txt";
            string inputPath2 = @"C:\Data\file2.txt";
            string outputPath = @"C:\Output\archive.zip";

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

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (FileStream zipFile = File.Open(outputPath, FileMode.Create))
            using (Archive archive = new Archive())
            {
                FileInfo fileInfo1 = new FileInfo(inputPath1);
                archive.CreateEntry("file1.txt", fileInfo1);

                FileInfo fileInfo2 = new FileInfo(inputPath2);
                archive.CreateEntry("file2.txt", fileInfo2);

                ArchiveSaveOptions saveOptions = new ArchiveSaveOptions();
                saveOptions.Encoding = Encoding.ASCII;
                archive.Save(zipFile, saveOptions);
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
 * 1. When you need to create a ZIP archive that retains original NTFS file permissions and timestamps for reliable backups.
 * 2. When deploying a .NET application and must package configuration files while preserving their hidden and system attributes.
 * 3. When sending files over email or a network and want the recipient to receive the same file attributes after extraction.
 * 4. When archiving logs or audit records and need to keep creation and modification dates intact for compliance auditing.
 * 5. When integrating Aspose.Zip into an automated build pipeline to bundle build artifacts without losing NTFS metadata.
 */
