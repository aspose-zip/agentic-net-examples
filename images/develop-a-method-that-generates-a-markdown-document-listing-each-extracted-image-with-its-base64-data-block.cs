// HOW-TO: Generate Markdown With Base64 Images From ZIP In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Text;
using Aspose.Zip;

public class Program
{
    private static string GetMimeType(string extension)
    {
        switch (extension)
        {
            case ".png":
                return "png";
            case ".jpg":
            case ".jpeg":
                return "jpeg";
            case ".gif":
                return "gif";
            case ".bmp":
                return "bmp";
            default:
                return "octet-stream";
        }
    }

    public static void Main(string[] args)
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
            {
                StringBuilder markdownBuilder = new StringBuilder();
                markdownBuilder.AppendLine("# Extracted Images");
                markdownBuilder.AppendLine();

                foreach (ArchiveEntry entry in archive.Entries)
                {
                    string extension = Path.GetExtension(entry.Name).ToLowerInvariant();
                    if (extension == ".png" || extension == ".jpg" || extension == ".jpeg" || extension == ".gif" || extension == ".bmp")
                    {
                        using (MemoryStream memory = new MemoryStream())
                        {
                            using (Stream entryStream = entry.Open())
                            {
                                entryStream.CopyTo(memory);
                            }

                            byte[] imageData = memory.ToArray();
                            string base64 = Convert.ToBase64String(imageData);
                            string mime = GetMimeType(extension);

                            markdownBuilder.AppendLine($"## {entry.Name}");
                            markdownBuilder.AppendLine();
                            markdownBuilder.AppendLine($"![{entry.Name}](data:image/{mime};base64,{base64})");
                            markdownBuilder.AppendLine();
                        }
                    }
                }

                File.WriteAllText(outputMarkdownPath, markdownBuilder.ToString());
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
 * 1. When you need to document all images inside a zip file by embedding them directly in a markdown report for easy viewing in version‑controlled documentation.
 * 2. When you want to create a self‑contained README that includes screenshots or graphics extracted from an archive without storing separate image files.
 * 3. When an automated build process must convert packaged assets into a single markdown file for audit or compliance reviews.
 * 4. When a web‑based viewer requires Base64‑encoded image data in markdown to render pictures without additional HTTP requests.
 * 5. When migrating legacy zip‑bundled design assets into a markdown‑based knowledge base and need a quick C# script to perform the conversion.
 */
