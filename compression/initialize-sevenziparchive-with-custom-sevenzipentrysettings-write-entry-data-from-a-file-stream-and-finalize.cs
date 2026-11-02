// HOW-TO: Create a 7z Archive from a File Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.SevenZip;

class Program
{
    static void Main(string[] args)
    {
        string inputFilePath = "input.txt";
        string outputArchivePath = "output/output.7z";

        try
        {
            if (!File.Exists(inputFilePath))
            {
                Console.Error.WriteLine($"File not found: {inputFilePath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputArchivePath));

            using (FileStream outputStream = File.Open(outputArchivePath, FileMode.Create))
            {
                using (SevenZipArchive archive = new SevenZipArchive())
                {
                    archive.CreateEntry("entry.txt", inputFilePath);
                    archive.Save(outputStream);
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
 * 1. When you need to package a single text file into a 7z archive for secure distribution in a .NET application.
 * 2. When you want to automate backup of configuration files by compressing them into a 7z container using Aspose.Zip.
 * 3. When you are building a deployment tool that must create 7z packages on the fly from generated logs.
 * 4. When you need to integrate 7z compression into a Windows service that archives processed data files.
 * 5. When you are developing a client‑side utility that compresses user‑selected files into a 7z archive before uploading to a server.
 */
