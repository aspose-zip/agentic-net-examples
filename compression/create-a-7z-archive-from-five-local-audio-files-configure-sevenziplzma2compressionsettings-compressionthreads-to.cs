// HOW-TO: Create 7z Archive of Multiple Audio Files with 8 Threads in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Zip;
using Aspose.Zip.SevenZip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input audio file paths
            string inputPath1 = @"C:\Audio\track1.mp3";
            string inputPath2 = @"C:\Audio\track2.mp3";
            string inputPath3 = @"C:\Audio\track3.wav";
            string inputPath4 = @"C:\Audio\track4.flac";
            string inputPath5 = @"C:\Audio\track5.aac";

            // Verify each input file exists
            if (!File.Exists(inputPath1)) { Console.Error.WriteLine($"File not found: {inputPath1}"); return; }
            if (!File.Exists(inputPath2)) { Console.Error.WriteLine($"File not found: {inputPath2}"); return; }
            if (!File.Exists(inputPath3)) { Console.Error.WriteLine($"File not found: {inputPath3}"); return; }
            if (!File.Exists(inputPath4)) { Console.Error.WriteLine($"File not found: {inputPath4}"); return; }
            if (!File.Exists(inputPath5)) { Console.Error.WriteLine($"File not found: {inputPath5}"); return; }

            // Hardcoded output archive path
            string outputPath = @"C:\Archives\parallel.7z";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure LZMA2 compression with 8 threads
            SevenZipLZMA2CompressionSettings lzma2Settings = new SevenZipLZMA2CompressionSettings();
            lzma2Settings.CompressionThreads = 8;

            // Apply the compression settings to entry settings
            SevenZipEntrySettings entrySettings = new SevenZipEntrySettings(lzma2Settings);

            // Create the 7z archive with the specified entry settings
            using (SevenZipArchive archive = new SevenZipArchive(entrySettings))
            {
                // Keep streams open until the archive is saved
                List<Stream> openStreams = new List<Stream>();

                // Add each audio file as an entry
                Stream stream1 = File.OpenRead(inputPath1);
                archive.CreateEntry(Path.GetFileName(inputPath1), stream1);
                openStreams.Add(stream1);

                Stream stream2 = File.OpenRead(inputPath2);
                archive.CreateEntry(Path.GetFileName(inputPath2), stream2);
                openStreams.Add(stream2);

                Stream stream3 = File.OpenRead(inputPath3);
                archive.CreateEntry(Path.GetFileName(inputPath3), stream3);
                openStreams.Add(stream3);

                Stream stream4 = File.OpenRead(inputPath4);
                archive.CreateEntry(Path.GetFileName(inputPath4), stream4);
                openStreams.Add(stream4);

                Stream stream5 = File.OpenRead(inputPath5);
                archive.CreateEntry(Path.GetFileName(inputPath5), stream5);
                openStreams.Add(stream5);

                // Save the archive to the specified output path
                archive.Save(outputPath);

                // Dispose all opened file streams
                foreach (Stream s in openStreams)
                {
                    s.Dispose();
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
 * 1. When you need to bundle several music tracks into a single 7z file for easy distribution while maximizing compression speed using multiple CPU cores in a C# application.
 * 2. When an audio processing pipeline must archive generated MP3, WAV, FLAC, and AAC files into a compressed archive for backup or transfer, and you want to control the number of compression threads.
 * 3. When deploying a media library to client machines, you can package the files into a 7z archive with parallel compression to reduce archive creation time in a .NET environment.
 * 4. When creating a downloadable content pack for a game or app, you can use this code to compress various audio assets into a single 7z file with eight threads for faster packaging.
 * 5. When automating nightly builds that include audio resources, you can generate a 7z archive with a specified thread count to ensure consistent performance across builds.
 */
