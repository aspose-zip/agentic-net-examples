// HOW-TO: Extract Images from ZIP and Create Base64 Markdown in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Text;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputZipPath = "input.zip";
            string outputMarkdownPath = "output.md";

            if (!File.Exists(inputZipPath))
            {
                Console.Error.WriteLine($"File not found: {inputZipPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputMarkdownPath));

            using (FileStream zipStream = File.Open(inputZipPath, FileMode.Open, FileAccess.Read))
            using (Archive archive = new Archive(zipStream))
            using (StreamWriter writer = new StreamWriter(outputMarkdownPath, false, Encoding.UTF8))
            {
                foreach (ArchiveEntry entry in archive.Entries)
                {
                    string extension = Path.GetExtension(entry.Name).ToLowerInvariant();
                    bool isImage = extension == ".png" || extension == ".jpg" || extension == ".jpeg" || extension == ".gif" || extension == ".bmp";

                    if (!isImage)
                    {
                        continue;
                    }

                    string mimeType;
                    switch (extension)
                    {
                        case ".png":
                            mimeType = "image/png";
                            break;
                        case ".jpg":
                        case ".jpeg":
                            mimeType = "image/jpeg";
                            break;
                        case ".gif":
                            mimeType = "image/gif";
                            break;
                        case ".bmp":
                            mimeType = "image/bmp";
                            break;
                        default:
                            mimeType = "application/octet-stream";
                            break;
                    }

                    using (Stream entryStream = entry.Open())
                    using (MemoryStream memory = new MemoryStream())
                    {
                        entryStream.CopyTo(memory);
                        byte[] imageBytes = memory.ToArray();
                        string base64Data = Convert.ToBase64String(imageBytes);

                        writer.WriteLine($"### {entry.Name}");
                        writer.WriteLine();
                        writer.WriteLine($"![{entry.Name}](data:{mimeType};base64,{base64Data})");
                        writer.WriteLine();
                        writer.WriteLine("```base64");
                        writer.WriteLine(base64Data);
                        writer.WriteLine("```");
                        writer.WriteLine();
                    }
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
 * 1. When you need to embed images from a zip archive directly into a README or documentation without storing separate files.
 * 2. When generating a self‑contained markdown report that includes screenshots or diagrams packaged in a zip.
 * 3. When automating the conversion of archived product assets into Base64 strings for web APIs or email bodies.
 * 4. When creating portable markdown files for offline viewing where all images must be encoded inline.
 * 5. When processing user‑uploaded zip files to extract and display images in a web application without saving them to disk.
 */
