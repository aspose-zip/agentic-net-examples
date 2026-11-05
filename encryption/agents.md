---
name: encryption
description: C# examples for Encryption using Aspose.ZIP for .NET
language: csharp
framework: net9.0
parent: ../agents.md
---

# AGENTS - Encryption

## Persona

You are a C# developer specializing in archive processing using Aspose.ZIP for .NET,
working within the **Encryption** category.
This folder contains standalone C# examples for Encryption operations.
See the root [agents.md](../agents.md) for repository-wide conventions and boundaries.

## Required Namespaces

- `using System;` (42/42 files)
- `using System.IO;` (42/42 files)
- `using Aspose.Zip.Saving;` (40/42 files) ← category-specific
- `using Aspose.Zip;` (38/42 files) ← category-specific
- `using Aspose.Zip.SevenZip;` (6/42 files) ← category-specific
- `using System.Collections.Generic;` (3/42 files)
- `using System.Text;` (3/42 files)
- `using System.Text.Json;` (1/42 files)
- `using System.Linq;` (1/42 files)

## Files in this folder

| File | Key APIs | Description |
|------|----------|-------------|
| [encrypt-a-7z-archive-with-aes-encryption-and-encrypted-headers-using-a-strong-password-and-save-it.cs](./encrypt-a-7z-archive-with-aes-encryption-and-encrypted-headers-using-a-strong-password-and-save-it.cs) |  | Encrypt a 7z archive with AES encryption and encrypted headers using a strong pa... |
| [create-a-7z-from-local-files-with-aes-entry-encryption-and-encrypted-headers-save-the-encrypted-7z-and-extract-it.cs](./create-a-7z-from-local-files-with-aes-entry-encryption-and-encrypted-headers-save-the-encrypted-7z-and-extract-it.cs) |  | Create a 7z from local files with AES entry encryption and encrypted headers, sa... |
| [create-a-7z-archive-from-a-directory-encrypt-it-with-aes-enable-encrypted-headers-and-save-the-archive.cs](./create-a-7z-archive-from-a-directory-encrypt-it-with-aes-enable-encrypted-headers-and-save-the-archive.cs) |  | Create a 7z archive from a directory, encrypt it with AES, enable encrypted head... |
| [set-different-passwords-for-individual-entries-within-a-7z-archive-and-save-the-protected-archive.cs](./set-different-passwords-for-individual-entries-within-a-7z-archive-and-save-the-protected-archive.cs) |  | Set different passwords for individual entries within a 7z archive and save the ... |
| [create-a-7z-with-distinct-caller-supplied-passwords-for-its-entries-and-header-encryption-disabled-save-it-and.cs](./create-a-7z-with-distinct-caller-supplied-passwords-for-its-entries-and-header-encryption-disabled-save-it-and.cs) |  | Create a 7z with distinct caller-supplied passwords for its entries and header e... |
| [build-a-7z-archive-from-a-directory-set-different-passwords-for-individual-entries-and-save-the-archive.cs](./build-a-7z-archive-from-a-directory-set-different-passwords-for-individual-entries-and-save-the-archive.cs) |  | Build a 7z archive from a directory, set different passwords for individual entr... |
| [load-a-zip-file-set-a-strong-password-configure-aes-256-encryptionoptions-and-save-encrypted-archive.cs](./load-a-zip-file-set-a-strong-password-configure-aes-256-encryptionoptions-and-save-encrypted-archive.cs) |  | Load a ZIP file, set a strong password, configure AES‑256 EncryptionOptions, and... |
| [apply-aes-256-encryptionoptions-to-archivesaveoptions-for-a-new-archive-and-save-the-password-protected-zip.cs](./apply-aes-256-encryptionoptions-to-archivesaveoptions-for-a-new-archive-and-save-the-password-protected-zip.cs) |  | Apply AES‑256 EncryptionOptions to ArchiveSaveOptions for a new archive and save... |
| [update-the-password-of-an-encrypted-zip-by-configuring-new-encryptionoptions-and-saving-the-modified-archive.cs](./update-the-password-of-an-encrypted-zip-by-configuring-new-encryptionoptions-and-saving-the-modified-archive.cs) | `ArchiveLoadOptions` | Update the password of an encrypted ZIP by configuring new EncryptionOptions and... |
| [generate-a-json-file-describing-the-aes-256-encryption-settings-applied-to-a-specific-zip-archive.cs](./generate-a-json-file-describing-the-aes-256-encryption-settings-applied-to-a-specific-zip-archive.cs) | `JsonSerializerOptions` | Generate a JSON file describing the AES‑256 encryption settings applied to a spe... |
| [re-encrypt-a-zip-by-loading-it-applying-a-new-complex-password-with-aes-256-and-saving-the-updated-archive.cs](./re-encrypt-a-zip-by-loading-it-applying-a-new-complex-password-with-aes-256-and-saving-the-updated-archive.cs) |  | Re‑encrypt a ZIP by loading it, applying a new complex password with AES‑256, an... |
| [load-a-zip-assign-a-long-complex-password-enable-encryption-and-write-the-encrypted-archive-to-disk.cs](./load-a-zip-assign-a-long-complex-password-enable-encryption-and-write-the-encrypted-archive-to-disk.cs) |  | Load a ZIP, assign a long complex password, enable encryption, and write the enc... |
| [configure-archivesaveoptions-with-aes-256-encryptionoptions-assign-a-secure-password-and-save-the-encrypted-zip.cs](./configure-archivesaveoptions-with-aes-256-encryptionoptions-assign-a-secure-password-and-save-the-encrypted-zip.cs) |  | Configure ArchiveSaveOptions with AES‑256 EncryptionOptions, assign a secure pas... |
| [apply-encryptionoptions-with-aes-256-to-an-existing-archivesaveoptions-instance-and-save-the-newly-encrypted-zip.cs](./apply-encryptionoptions-with-aes-256-to-an-existing-archivesaveoptions-instance-and-save-the-newly-encrypted-zip.cs) | `ArchiveSaveOptions` | Apply EncryptionOptions with AES‑256 to an existing ArchiveSaveOptions instance ... |
| [generate-a-password-meeting-complexity-guidelines-apply-it-to-the-archive-enable-aes-256-encryption-and-save.cs](./generate-a-password-meeting-complexity-guidelines-apply-it-to-the-archive-enable-aes-256-encryption-and-save.cs) |  | Generate a password meeting complexity guidelines, apply it to the archive, enab... |
| [load-a-source-zip-configure-encryptionoptions-for-aes-256-assign-a-strong-password-and-save-encrypted-file.cs](./load-a-source-zip-configure-encryptionoptions-for-aes-256-assign-a-strong-password-and-save-encrypted-file.cs) |  | Load a source ZIP, configure EncryptionOptions for AES‑256, assign a strong pass... |
| [set-encryptionoptions-to-aes-256-on-archivesaveoptions-provide-a-strong-password-and-write-the-encrypted-zip.cs](./set-encryptionoptions-to-aes-256-on-archivesaveoptions-provide-a-strong-password-and-write-the-encrypted-zip.cs) | `ArchiveSaveOptions` | Set EncryptionOptions to AES‑256 on ArchiveSaveOptions, provide a strong passwor... |
| [encrypt-a-compressed-zip-without-extracting-entries-by-configuring-encryptionoptions-and-invoking-save.cs](./encrypt-a-compressed-zip-without-extracting-entries-by-configuring-encryptionoptions-and-invoking-save.cs) | `ArchiveSaveOptions` | Encrypt a compressed ZIP without extracting entries by configuring EncryptionOpt... |
| [batch-encrypt-multiple-unencrypted-zip-files-using-aes-256-with-a-common-password-and-save-each-encrypted-archive.cs](./batch-encrypt-multiple-unencrypted-zip-files-using-aes-256-with-a-common-password-and-save-each-encrypted-archive.cs) |  | Batch encrypt multiple unencrypted ZIP files using AES‑256 with a common passwor... |
| [load-an-encrypted-zip-change-its-password-re-apply-aes-256-encryptionoptions-and-save-the-updated-archive.cs](./load-an-encrypted-zip-change-its-password-re-apply-aes-256-encryptionoptions-and-save-the-updated-archive.cs) | `ArchiveLoadOptions` | Load an encrypted ZIP, change its password, re‑apply AES‑256 EncryptionOptions, ... |
| [produce-a-json-metadata-file-describing-the-aes-256-encryption-applied-to-a-specific-zip-archive.cs](./produce-a-json-metadata-file-describing-the-aes-256-encryption-applied-to-a-specific-zip-archive.cs) |  | Produce a JSON metadata file describing the AES‑256 encryption applied to a spec... |
| [load-a-zip-apply-a-new-password-following-complexity-guidelines-and-save-the-re-encrypted-archive.cs](./load-a-zip-apply-a-new-password-following-complexity-guidelines-and-save-the-re-encrypted-archive.cs) |  | Load a ZIP, apply a new password following complexity guidelines, and save the r... |
| [create-a-zip-archive-encrypted-with-traditional-password-protection-containing-three-text-files-and-save-it.cs](./create-a-zip-archive-encrypted-with-traditional-password-protection-containing-three-text-files-and-save-it.cs) |  | Create a ZIP archive encrypted with traditional password protection containing t... |
| [generate-a-zip-archive-using-aes256-encryption-for-an-entire-folder-of-images-and-store-it-locally.cs](./generate-a-zip-archive-using-aes256-encryption-for-an-entire-folder-of-images-and-store-it-locally.cs) |  | Generate a ZIP archive using AES256 encryption for an entire folder of images an... |
| [compress-documents-into-a-single-zip-file-applying-aes128-encryption-to-one-file-and-traditional-encryption-to.cs](./compress-documents-into-a-single-zip-file-applying-aes128-encryption-to-one-file-and-traditional-encryption-to.cs) |  | Compress documents into a single ZIP file applying AES128 encryption to one file... |
| [encrypt-a-single-pdf-file-inside-a-new-zip-archive-using-aes192-encryption-and-save-the-archive.cs](./encrypt-a-single-pdf-file-inside-a-new-zip-archive-using-aes192-encryption-and-save-the-archive.cs) |  | Encrypt a single PDF file inside a new ZIP archive using AES192 encryption and s... |
| [create-a-password-protected-zip-archive-with-traditional-encryption-containing-a-nested-directory-structure-and.cs](./create-a-password-protected-zip-archive-with-traditional-encryption-containing-a-nested-directory-structure-and.cs) |  | Create a password‑protected ZIP archive with traditional encryption containing a... |
| [create-a-zip-archive-where-image-files-use-aes-key-sizes-128-192-and-256-and-save-it.cs](./create-a-zip-archive-where-image-files-use-aes-key-sizes-128-192-and-256-and-save-it.cs) |  | Create a ZIP archive where image files use AES key sizes 128, 192, and 256 and s... |
| [encrypt-an-entire-directory-of-confidential-documents-with-aes192-encryption-and-generate-the-protected-zip-file.cs](./encrypt-an-entire-directory-of-confidential-documents-with-aes192-encryption-and-generate-the-protected-zip-file.cs) |  | Encrypt an entire directory of confidential documents with AES192 encryption and... |
| [create-a-zip-archive-that-mixes-stored-uncompressed-entries-with-aes-encrypted-entries-and-save-it.cs](./create-a-zip-archive-that-mixes-stored-uncompressed-entries-with-aes-encrypted-entries-and-save-it.cs) |  | Create a ZIP archive that mixes stored (uncompressed) entries with AES‑encrypted... |
| *...and 12 more files* | | [View all](https://github.com/aspose-zip/agentic-net-examples/tree/26.11.0/encryption) |

## Category Statistics
- Total examples: 42
- Failed: 0
- Pass rate: 100.0%

## Key API Surface

- `ArchiveLoadOptions`
- `ArchiveSaveOptions`
- `JsonSerializerOptions`

## Failed Tasks

All tasks passed ✅

<!-- AUTOGENERATED:START -->
Updated: 2026-11-05 | Run: `20261103_153249` | Examples: 42
<!-- AUTOGENERATED:END -->