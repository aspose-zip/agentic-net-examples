// HOW-TO: Create Gzipped TAR Archive with CSV Entry Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Text;
using Aspose.Zip;
using Aspose.Zip.Tar;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = "output/output.tar.gz";

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TarArchive archive = new TarArchive())
            {
                string csvContent = "Id,Name,Value\n1,Item1,100\n2,Item2,200";

                using (MemoryStream csvStream = new MemoryStream(Encoding.UTF8.GetBytes(csvContent)))
                {
                    archive.CreateEntry("newdata.csv", csvStream);
                }

                archive.SaveGzipped(outputPath);
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
 * 1. When you need to generate a compressed TAR.GZ package that includes a dynamically created CSV report for distribution or backup.
 * 2. When integrating a .NET application with legacy Unix systems that require data to be delivered as a gzipped tar archive containing CSV files.
 * 3. When automating the creation of deployment bundles that must combine configuration data generated at runtime into a single .tar.gz file.
 * 4. When exporting large datasets from a database to a compressed archive for efficient storage or transfer, adding the CSV directly without writing to disk first.
 * 5. When building a CI/CD pipeline step that packages test results or logs as a CSV inside a gzipped tar to be uploaded to artifact repositories.
 */
