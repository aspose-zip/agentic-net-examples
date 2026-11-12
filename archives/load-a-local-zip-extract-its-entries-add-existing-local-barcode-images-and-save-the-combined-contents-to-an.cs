// HOW-TO: Extract ZIP, Add Barcode Images, and Save Updated Archive in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string inputZipPath = "input.zip";
            string extractDirectory = "extracted";
            string barcodeImagePath1 = "barcode1.png";
            string barcodeImagePath2 = "barcode2.png";
            string outputZipPath = "updated.zip";

            // Validate input ZIP file
            if (!File.Exists(inputZipPath))
            {
                Console.Error.WriteLine($"File not found: {inputZipPath}");
                return;
            }

            // Validate barcode image files
            if (!File.Exists(barcodeImagePath1))
            {
                Console.Error.WriteLine($"File not found: {barcodeImagePath1}");
                return;
            }
            if (!File.Exists(barcodeImagePath2))
            {
                Console.Error.WriteLine($"File not found: {barcodeImagePath2}");
                return;
            }

            // Ensure extraction directory exists
            Directory.CreateDirectory(extractDirectory);

            // Extract existing entries from the input ZIP
            using (Archive sourceArchive = new Archive(inputZipPath))
            {
                sourceArchive.ExtractToDirectory(extractDirectory);
            }

            // Prepare output directory if needed
            string outputDir = Path.GetDirectoryName(outputZipPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Create a new archive, add extracted files and barcode images, then save
            using (Archive newArchive = new Archive())
            {
                // Add all files from the extraction folder
                DirectoryInfo extractedInfo = new DirectoryInfo(extractDirectory);
                newArchive.CreateEntries(extractedInfo);

                // Add barcode images
                newArchive.CreateEntry("barcode1.png", barcodeImagePath1);
                newArchive.CreateEntry("barcode2.png", barcodeImagePath2);

                // Save the combined archive
                newArchive.Save(outputZipPath);
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
 * 1. When you need to unpack an existing ZIP, insert generated barcode PNG files, and repackage the contents for distribution.
 * 2. When automating shipment packaging that requires original documents plus barcode label images to be bundled into a single archive.
 * 3. When integrating a document management system that must extract files from a ZIP, attach scanning barcodes, and store the combined package back to storage.
 * 4. When building a batch process that updates legacy archives with new barcode assets without manually opening the ZIP.
 * 5. When preparing compliance reports where archived data must be supplemented with barcode images before being re‑zipped and sent to regulators.
 */
