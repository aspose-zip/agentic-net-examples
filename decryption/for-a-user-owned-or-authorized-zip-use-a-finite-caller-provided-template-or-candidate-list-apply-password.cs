// HOW-TO: Extract Password Protected ZIP and Create Manifest File in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Text;
using Aspose.Zip;
using Aspose.Zip.ArchiveInfo;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ZIP path and output directory.
            string inputZipPath = "input.zip";
            string outputDirectoryPath = "output";
            string manifestFilePath = Path.Combine(outputDirectoryPath, "manifest.txt");

            // Verify that the input ZIP file exists.
            if (!File.Exists(inputZipPath))
            {
                Console.Error.WriteLine($"File not found: {inputZipPath}");
                return;
            }

            // Ensure the output directory exists.
            Directory.CreateDirectory(outputDirectoryPath);

            // Password for the protected ZIP archive.
            string archivePassword = "password123";

            // Load the encrypted archive with the provided password.
            ArchiveLoadOptions loadOptions = new ArchiveLoadOptions();
            loadOptions.DecryptionPassword = archivePassword;

            using (Archive archive = new Archive(inputZipPath, loadOptions))
            {
                // Extract all entries to the output directory.
                archive.ExtractToDirectory(outputDirectoryPath);
            }

            // Generate a manifest file listing all extracted files (relative paths).
            string[] extractedFiles = Directory.GetFiles(outputDirectoryPath, "*", SearchOption.AllDirectories);
            using (StreamWriter writer = new StreamWriter(manifestFilePath, false, Encoding.UTF8))
            {
                foreach (string filePath in extractedFiles)
                {
                    // Skip the manifest file itself if it already exists.
                    if (string.Equals(filePath, manifestFilePath, StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }

                    string relativePath = Path.GetRelativePath(outputDirectoryPath, filePath);
                    writer.WriteLine(relativePath);
                }
            }

            Console.WriteLine("Extraction completed. Manifest created at: " + manifestFilePath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to programmatically unlock an encrypted ZIP archive in a C# application and extract its contents to a known folder.
 * 2. When you must generate a text manifest of all files extracted from a password‑protected archive for audit or logging purposes.
 * 3. When a deployment script has to process user‑owned ZIP packages, decrypt them with a supplied password, and store only non‑sensitive metadata locally.
 * 4. When integrating with a document management system that receives encrypted ZIP uploads and requires automatic extraction and inventory creation in .NET.
 * 5. When building a backup verification tool that extracts encrypted archives, lists the extracted files, and saves the list without exposing the original passwords.
 */
