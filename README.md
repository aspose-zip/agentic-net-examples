# agentic-net-examples
Agentic .NET examples for AI agents that create, extract, encrypt, and automate archives using Aspose.ZIP.


## Resources

| Resource | Link |
|----------|------|
| 📖 Documentation | [docs.aspose.com/zip/net](https://docs.aspose.com/zip/net/) |
| 📦 NuGet Package | [nuget.org/packages/Aspose.Zip](https://www.nuget.org/packages/Aspose.Zip) |
| 🚀 Release Notes | [releases.aspose.com/zip/net](https://releases.aspose.com/zip/net/) |
| 🌐 Online Apps | [products.aspose.app/zip](https://products.aspose.app/zip/family/) |
| 🤖 Agent API | [agent.json](/.well-known/agent.json) |

| Category   | Examples | Key APIs |
|------------|----------|----------|
| archives   | 575      | `ZipArchive`, `ZipEntry`, `ZipFile` |
| compression| 112      | `ZipCompressionLevel`, `ZipArchiveWriter`, `ZipEntry` |
| conversion | 91       | `ZipArchiveInfo`, `ZipArchiveReader`, `ZipFile` |
| decryption | 45       | `ZipDecryption`, `ZipEntry`, `ZipArchive` |
| encryption | 42       | `ZipEncryption`, `ZipEntry`, `ZipArchive` |
| events     | 51       | `ZipArchiveEvent`, `ZipArchive`, `ZipEntry` |

## Related Resources
Explore the Aspose.ZIP for .NET examples to see how C# archive processing can be streamlined with this powerful dotnet compression library. If you need to create or extract files, check the archives section; for fine‑tuned compression and decompression of a ZIP archive C# use the compression examples. When working with encrypted packages, the decryption and encryption samples demonstrate the C# ZIP library’s security features, while the events category shows how to hook into archive events during processing. For format changes, such as converting a ZIP to a TAR or extracting images, see the conversion examples in the Aspose.ZIP examples collection.

## Frequently Asked Questions

### Q: How to create a ZIP archive using Aspose.Zip for .NET  
Use `Aspose.Zip.ArchiveFactory.CreateArchive(ArchiveType.Zip)` to instantiate a `ZipArchive` object, then add files with `zipArchive.AddEntry(string entryName, Stream source)`. Finally call `zipArchive.Save("output.zip")` to write the **ZIP archive C#** file to disk. This pattern is demonstrated in the repository’s **Aspose.ZIP examples** for quick **C# archive processing**.

### Q: How to extract a ZIP archive in C# with Aspose.ZIP  
Call `ArchiveFactory.Extract("input.zip", "outputFolder")` or create a `ZipArchive` via `ArchiveFactory.Open("input.zip")` and iterate its `Entries` collection, invoking `entry.ExtractToFile(Path.Combine(destFolder, entry.Name))`. The method leverages the built‑in **dotnet compression library** and works with any **C# ZIP library** scenario.

### Q: How to password‑protect archives in dotnet  
Create a `ZipArchive` with `ArchiveFactory.CreateArchive(ArchiveType.Zip, new ZipOptions { Password = "MySecret" })`, then add entries as usual. When saving, the archive is encrypted using the supplied password, providing secure **C# archive processing** with the **Aspose.ZIP for .NET** API.

### Q: How to create 7z archives in C#  
Instantiate a `SevenZipArchive` via `ArchiveFactory.CreateArchive(ArchiveType.SevenZip)` and add files with `sevenZip.AddEntry(entryName, stream)`. Call `sevenZip.Save("archive.7z")` to produce a 7‑zip file, showcasing the **C# ZIP library**’s support for multiple formats.

### Q: How to work with TAR and GZIP archives in dotnet  
Use `ArchiveFactory.CreateArchive(ArchiveType.Tar)` for TAR files and `ArchiveFactory.CreateArchive(ArchiveType.Gzip)` for GZIP streams; both return `TarArchive` or `GzipArchive` objects that expose `AddEntry` and `Extract` methods. These classes let you perform **C# archive processing** of TAR/GZIP with the same **Aspose.ZIP for .NET** code base.

### Q: How to compress streams with Aspose.ZIP  
Open a `ZipArchive` in write mode: `var zip = ArchiveFactory.CreateArchive(ArchiveType.Zip); zip.AddEntry("data.bin", myStream); zip.Save(outputStream);`. This approach compresses any `Stream` directly, making it a handy snippet in the **Aspose.ZIP examples** for **dotnet compression library** usage.

### Q: How to use Aspose.ZIP without a license  
When no license file is supplied, the library operates in evaluation mode, allowing all API calls (e.g., `ZipArchive`, `ArchiveFactory`) but adding a small watermark to generated archives. You can still run the **C# ZIP library** code for development and testing; a commercial license removes the watermark and unlocks full performance.

### Q: What archive formats does Aspose.ZIP support  
`ArchiveFactory` recognizes `ArchiveType.Zip`, `ArchiveType.SevenZip`, `ArchiveType.Tar`, `ArchiveType.Gzip`, and `ArchiveType.Bzip2`, enabling creation and extraction of ZIP, 7z, TAR, GZIP, and BZIP2 files. This broad support makes Aspose.ZIP a versatile **dotnet compression library** for all common **C# archive processing** needs.


| Category   | Examples | Key APIs                                             |
|------------|----------|------------------------------------------------------|
| archives   | 575      | Archive, ArchiveEntry, ZipFile                       |
| compression| 112      | CompressionLevel, CompressionMethod, ZipOutputStream |
| conversion | 91       | ZipFile, Archive, ZipArchive                         |
| decryption | 45       | EncryptionAlgorithm, ZipDecryption, ZipArchiveEntry |
| encryption | 42       | EncryptionAlgorithm, ZipEncryption, ZipArchiveEntry |
| events     | 51       | ZipEvent, ZipArchiveEventArgs, ZipException          |


| Category   | Examples | Key APIs |
|------------|----------|----------|
| archives   | 575      | `Aspose.Zip.Archive`, `Aspose.Zip.ZipFile` |
| compression| 112      | `Aspose.Zip.CompressionLevel`, `Aspose.Zip.CompressionMethod` |
| conversion | 91       | `Aspose.Zip.ArchiveEntry`, `Aspose.Zip.ZipFile` |
| decryption | 45       | `Aspose.Zip.ZipDecryption` |
| encryption | 42       | `Aspose.Zip.ZipEncryption` |
| events     | 51       | `Aspose.Zip.ZipEvent` |
| files      | 33       | `Aspose.Zip.ZipFile`, `Aspose.Zip.ZipInputStream` |
| folders    | 27       | `Aspose.Zip.ArchiveEntry` |
| images     | 19       | `Aspose.Zip.ArchiveEntry` |
| merging    | 50       | `Aspose.Zip.ZipFile` (Merge support) |
| volumes    | 79       | `Aspose.Zip.ZipVolume` |