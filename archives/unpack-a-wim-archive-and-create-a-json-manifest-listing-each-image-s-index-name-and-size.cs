// HOW-TO: Extract Images from WIM Archive and Generate JSON Manifest in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Aspose.Zip.Wim;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "sample.wim";
            string outputFolder = "ExtractedImages";
            string manifestPath = Path.Combine(outputFolder, "manifest.json");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputFolder);
            Directory.CreateDirectory(Path.GetDirectoryName(manifestPath));

            List<ManifestItem> manifest = new List<ManifestItem>();

            using (FileStream fs = File.OpenRead(inputPath))
            using (WimArchive archive = new WimArchive(fs))
            {
                for (int i = 0; i < archive.Images.Count; i++)
                {
                    string imageFolder = Path.Combine(outputFolder, $"Image_{i}");
                    Directory.CreateDirectory(imageFolder);
                    archive.Images[i].ExtractToDirectory(imageFolder);

                    ManifestItem item = new ManifestItem();
                    item.Index = i;
                    item.Name = $"Image_{i}";
                    item.Size = 0;
                    manifest.Add(item);
                }
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("[");
            for (int i = 0; i < manifest.Count; i++)
            {
                ManifestItem mi = manifest[i];
                sb.Append("  {");
                sb.Append($"\"Index\": {mi.Index}, ");
                sb.Append($"\"Name\": \"{mi.Name}\", ");
                sb.Append($"\"Size\": {mi.Size}");
                sb.Append("}");
                if (i < manifest.Count - 1) sb.AppendLine(",");
                else sb.AppendLine();
            }
            sb.AppendLine("]");

            File.WriteAllText(manifestPath, sb.ToString());
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    private class ManifestItem
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public long Size { get; set; }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to programmatically unpack a Windows Imaging Format (WIM) file to access individual images for deployment or analysis.
 * 2. When you want to create a machine‑readable inventory of extracted images, such as a JSON manifest, to feed into automation pipelines.
 * 3. When you are building a backup verification tool that extracts each WIM image and records its index, name, and size for later comparison.
 * 4. When you need to separate each image in a multi‑image WIM into its own folder for custom processing or modification.
 * 5. When you are integrating WIM extraction into a C# application that must log extracted image metadata for reporting or auditing purposes.
 */
