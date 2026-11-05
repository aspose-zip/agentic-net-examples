# Encrypt ZIP Archives in C# with Aspose.ZIP  

A set of ready‑to‑run C# examples that demonstrate how to use **Aspose.ZIP for .NET** – a UI‑agnostic backend API that works in ASP.NET Core, console apps, Azure Functions, Docker containers, and any .NET 9+ environment.  
The samples cover creating password‑protected ZIP files with AES‑256, batch‑encrypting existing ZIP archives, applying AES‑192 encryption per entry while compressing JSON files, configuring `ArchiveSaveOptions` with secure passwords, and building a 7z archive with distinct entry passwords and header encryption disabled.

## What You Can Do  

- **Create an AES‑256 encrypted ZIP archive with a password** – set `EncryptionOptions` on `ArchiveSaveOptions` and save a new archive (`protected.zip`).  
- **Batch encrypt multiple existing ZIP files using AES‑256 and a common password** – iterate over a folder of unencrypted ZIPs, apply the same password, and write each encrypted archive to an output folder.  
- **Compress a collection of JSON files into a ZIP while encrypting each file with AES‑192** – add each JSON file individually and assign its own `EncryptionOptions`.  
- **Configure `ArchiveSaveOptions` with AES‑256 encryption and a secure password before saving** – demonstrates the explicit creation of `EncryptionOptions` and assignment to the save options object.  
- **Create a 7z archive with per‑entry passwords and header encryption disabled** – shows how to turn off header encryption while supplying distinct passwords for each entry.

## Quick Start  

The most common scenario is creating a password‑protected ZIP with AES‑256 encryption:

```csharp
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Saving;

class Program
{
    static void Main()
    {
        string inputFile   = "data\\sample.txt";
        string outputZip   = "output\\encrypted.zip";
        string password    = "MyStrongP@ssw0rd";

        if (!File.Exists(inputFile))
        {
            Console.Error.WriteLine($"File not found: {inputFile}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputZip));

        // Set up AES‑256 encryption options
        var encOptions = new EncryptionOptions
        {
            EncryptionAlgorithm = EncryptionAlgorithm.Aes256,
            Password = password
        };

        // Apply encryption to the archive save options
        var saveOptions = new ArchiveSaveOptions
        {
            EncryptionOptions = encOptions
        };

        // Create the archive and add the file
        using (var archive = new Archive())
        {
            archive.AddEntry(Path.GetFileName(inputFile), File.ReadAllBytes(inputFile));
            archive.Save(outputZip, saveOptions);
        }

        Console.WriteLine($"Encrypted ZIP created at: {outputZip}");
    }
}
```

## Requirements  

- .NET 9 or later  
- Aspose.Zip NuGet package  

```bash
dotnet add package Aspose.Zip
```

## Resources  

| Resource | Link |
|----------|------|
| Documentation | https://docs.aspose.com/zip/net/ |
| NuGet | https://www.nuget.org/packages/Aspose.Zip |
| Release Notes | https://releases.aspose.com/zip/net/ |
| Online Apps | https://products.aspose.app/zip/family/ |

## Files

Examples and tasks in this folder:

| Example |
|---------|
| [apply-aes-256-encryptionoptions-to-archivesaveoptions-for-a-new-archive-and-save-the-password-protected-zip.cs](./apply-aes-256-encryptionoptions-to-archivesaveoptions-for-a-new-archive-and-save-the-password-protected-zip.cs) |
| [apply-aes192-encryption-to-a-zip-archive-that-already-contains-aes128-encrypted-entries-creating-a-mixed.cs](./apply-aes192-encryption-to-a-zip-archive-that-already-contains-aes128-encrypted-entries-creating-a-mixed.cs) |
| [apply-encryptionoptions-with-aes-256-to-an-existing-archivesaveoptions-instance-and-save-the-newly-encrypted-zip.cs](./apply-encryptionoptions-with-aes-256-to-an-existing-archivesaveoptions-instance-and-save-the-newly-encrypted-zip.cs) |
| [batch-encrypt-multiple-unencrypted-zip-files-using-aes-256-with-a-common-password-and-save-each-encrypted-archive.cs](./batch-encrypt-multiple-unencrypted-zip-files-using-aes-256-with-a-common-password-and-save-each-encrypted-archive.cs) |
| [build-a-7z-archive-from-a-directory-set-different-passwords-for-individual-entries-and-save-the-archive.cs](./build-a-7z-archive-from-a-directory-set-different-passwords-for-individual-entries-and-save-the-archive.cs) |
| [compress-a-collection-of-xml-files-into-a-zip-archive-using-aes128-encryption.cs](./compress-a-collection-of-xml-files-into-a-zip-archive-using-aes128-encryption.cs) |
| [compress-a-set-of-json-files-into-a-zip-archive-applying-aes192-encryption-to-each-file-individually.cs](./compress-a-set-of-json-files-into-a-zip-archive-applying-aes192-encryption-to-each-file-individually.cs) |
| [compress-documents-into-a-single-zip-file-applying-aes128-encryption-to-one-file-and-traditional-encryption-to.cs](./compress-documents-into-a-single-zip-file-applying-aes128-encryption-to-one-file-and-traditional-encryption-to.cs) |
| [compress-multiple-csv-files-into-a-zip-archive-using-traditional-password-protection-for-all-files-and-store-it.cs](./compress-multiple-csv-files-into-a-zip-archive-using-traditional-password-protection-for-all-files-and-store-it.cs) |
| [configure-archivesaveoptions-with-aes-256-encryptionoptions-assign-a-secure-password-and-save-the-encrypted-zip.cs](./configure-archivesaveoptions-with-aes-256-encryptionoptions-assign-a-secure-password-and-save-the-encrypted-zip.cs) |
| [create-a-7z-archive-from-a-directory-encrypt-it-with-aes-enable-encrypted-headers-and-save-the-archive.cs](./create-a-7z-archive-from-a-directory-encrypt-it-with-aes-enable-encrypted-headers-and-save-the-archive.cs) |
| [create-a-7z-from-local-files-with-aes-entry-encryption-and-encrypted-headers-save-the-encrypted-7z-and-extract-it.cs](./create-a-7z-from-local-files-with-aes-entry-encryption-and-encrypted-headers-save-the-encrypted-7z-and-extract-it.cs) |
| [create-a-7z-with-distinct-caller-supplied-passwords-for-its-entries-and-header-encryption-disabled-save-it-and.cs](./create-a-7z-with-distinct-caller-supplied-passwords-for-its-entries-and-header-encryption-disabled-save-it-and.cs) |
| [create-a-password-protected-zip-archive-with-traditional-encryption-containing-a-nested-directory-structure-and.cs](./create-a-password-protected-zip-archive-with-traditional-encryption-containing-a-nested-directory-structure-and.cs) |
| [create-a-password-protected-zip-archive-with-traditional-encryption-that-includes-both-files-and-empty-folders.cs](./create-a-password-protected-zip-archive-with-traditional-encryption-that-includes-both-files-and-empty-folders.cs) |
| [create-a-zip-archive-encrypted-with-traditional-password-protection-containing-three-text-files-and-save-it.cs](./create-a-zip-archive-encrypted-with-traditional-password-protection-containing-three-text-files-and-save-it.cs) |
| [create-a-zip-archive-that-mixes-stored-uncompressed-entries-with-aes-encrypted-entries-and-save-it.cs](./create-a-zip-archive-that-mixes-stored-uncompressed-entries-with-aes-encrypted-entries-and-save-it.cs) |
| [create-a-zip-archive-that-stores-files-without-compression-but-protects-them-with-traditional-password-encryption.cs](./create-a-zip-archive-that-stores-files-without-compression-but-protects-them-with-traditional-password-encryption.cs) |
| [create-a-zip-archive-where-image-files-use-aes-key-sizes-128-192-and-256-and-save-it.cs](./create-a-zip-archive-where-image-files-use-aes-key-sizes-128-192-and-256-and-save-it.cs) |
| [create-a-zip-archive-with-mixed-encryption-where-text-files-use-traditional-password-protection-and-images-use.cs](./create-a-zip-archive-with-mixed-encryption-where-text-files-use-traditional-password-protection-and-images-use.cs) |
| [create-a-zip-archive-with-stored-uncompressed-entries-protected-by-aes256-encryption-and-save-it-for-distribution.cs](./create-a-zip-archive-with-stored-uncompressed-entries-protected-by-aes256-encryption-and-save-it-for-distribution.cs) |
| [encrypt-a-7z-archive-with-aes-encryption-and-encrypted-headers-using-a-strong-password-and-save-it.cs](./encrypt-a-7z-archive-with-aes-encryption-and-encrypted-headers-using-a-strong-password-and-save-it.cs) |
| [encrypt-a-compressed-zip-without-extracting-entries-by-configuring-encryptionoptions-and-invoking-save.cs](./encrypt-a-compressed-zip-without-extracting-entries-by-configuring-encryptionoptions-and-invoking-save.cs) |
| [encrypt-a-single-image-file-inside-a-zip-archive-using-traditional-password-protection.cs](./encrypt-a-single-image-file-inside-a-zip-archive-using-traditional-password-protection.cs) |
| [encrypt-a-single-pdf-file-inside-a-new-zip-archive-using-aes192-encryption-and-save-the-archive.cs](./encrypt-a-single-pdf-file-inside-a-new-zip-archive-using-aes192-encryption-and-save-the-archive.cs) |
| [encrypt-a-single-text-file-within-an-existing-zip-archive-using-aes256-encryption.cs](./encrypt-a-single-text-file-within-an-existing-zip-archive-using-aes256-encryption.cs) |
| [encrypt-an-entire-directory-hierarchy-using-aes128-encryption-and-generate-a-compressed-zip-archive-for-backup.cs](./encrypt-an-entire-directory-hierarchy-using-aes128-encryption-and-generate-a-compressed-zip-archive-for-backup.cs) |
| [encrypt-an-entire-directory-of-confidential-documents-with-aes192-encryption-and-generate-the-protected-zip-file.cs](./encrypt-an-entire-directory-of-confidential-documents-with-aes192-encryption-and-generate-the-protected-zip-file.cs) |
| [encrypt-files-in-a-zip-archive-using-traditional-password-protection-for-text-files-and-aes256-for-binary-files.cs](./encrypt-files-in-a-zip-archive-using-traditional-password-protection-for-text-files-and-aes256-for-binary-files.cs) |
| [generate-a-json-file-describing-the-aes-256-encryption-settings-applied-to-a-specific-zip-archive.cs](./generate-a-json-file-describing-the-aes-256-encryption-settings-applied-to-a-specific-zip-archive.cs) |
[**View all 42 examples →**](https://github.com/aspose-zip/agentic-net-examples/tree/26.11.0/encryption)
