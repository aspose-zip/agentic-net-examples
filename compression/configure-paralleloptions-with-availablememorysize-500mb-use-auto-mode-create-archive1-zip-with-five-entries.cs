// HOW-TO: Create ZIP Archive With Limited Memory Using ParallelOptions In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDir = @"C:\Data\";
            string[] inputFileNames = new string[]
            {
                "input1.txt",
                "input2.txt",
                "input3.txt",
                "input4.txt",
                "input5.txt"
            };
            string outputPath = @"C:\Output\archive1.zip";

            FileStream[] sourceStreams = new FileStream[inputFileNames.Length];
            for (int i = 0; i < inputFileNames.Length; i++)
            {
                string inputPath = Path.Combine(inputDir, inputFileNames[i]);
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
                sourceStreams[i] = File.Open(inputPath, FileMode.Open, FileAccess.Read);
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (FileStream zipFile = File.Open(outputPath, FileMode.Create))
            using (Archive archive = new Archive())
            {
                for (int i = 0; i < inputFileNames.Length; i++)
                {
                    archive.CreateEntry(inputFileNames[i], sourceStreams[i]);
                }

                Aspose.Zip.Saving.ParallelOptions parallelOpts = new Aspose.Zip.Saving.ParallelOptions()
                {
                    AvailableMemorySize = 500 * 1024 * 1024
                };

                ArchiveSaveOptions saveOpts = new ArchiveSaveOptions()
                {
                    ParallelOptions = parallelOpts
                };

                archive.Save(zipFile, saveOpts);
            }

            foreach (FileStream fs in sourceStreams)
            {
                fs.Dispose();
            }

            Console.WriteLine("Archive created successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to compress multiple files into a single ZIP on a server that has only 500 MB of free RAM, you can use this code to limit memory usage while creating the archive.
 * 2. When building a backup utility that must run on low‑memory Windows machines, the ParallelOptions setting ensures the ZIP creation does not exceed the available memory.
 * 3. When processing large batches of log files in a .NET application and you want to generate a single archive without exhausting system resources, this approach creates the archive efficiently.
 * 4. When integrating Aspose.Zip into an automated deployment pipeline that packages configuration files, you can control memory consumption to keep the build agent stable.
 * 5. When developing a desktop tool that lets users select several documents and save them as a ZIP, the code demonstrates how to manage memory and use parallel saving for faster performance.
 */
