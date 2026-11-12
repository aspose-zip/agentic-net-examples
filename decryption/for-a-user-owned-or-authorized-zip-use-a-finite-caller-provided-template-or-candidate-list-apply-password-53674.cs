// HOW-TO: How To Test Multiple Passwords On A ZIP And Log Results In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ZIP path
            string inputZipPath = @"C:\Data\protected.zip";

            // Hardcoded output CSV report path
            string outputReportPath = @"C:\Data\PasswordAttemptsReport.csv";

            // Verify input ZIP exists
            if (!File.Exists(inputZipPath))
            {
                Console.Error.WriteLine($"File not found: {inputZipPath}");
                return;
            }

            // Prepare list of candidate passwords
            List<string> passwordList = new List<string>
            {
                "password1",
                "password2",
                "123456",
                "secret"
            };

            // Build CSV content
            StringBuilder csvBuilder = new StringBuilder();
            csvBuilder.AppendLine("Attempt,Success");

            int attemptNumber = 1;
            foreach (string pwd in passwordList)
            {
                bool success = false;
                try
                {
                    // Attempt to open the archive with the current password
                    ArchiveLoadOptions loadOptions = new ArchiveLoadOptions
                    {
                        DecryptionPassword = pwd
                    };

                    using (Archive archive = new Archive(inputZipPath, loadOptions))
                    {
                        // If no exception, the password is correct
                        success = true;
                    }
                }
                catch (Exception)
                {
                    // Opening failed, password incorrect
                    success = false;
                }

                // Record attempt result (do not store the password itself)
                csvBuilder.AppendLine($"{attemptNumber},{success}");
                attemptNumber++;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputReportPath));

            // Write CSV report to file
            File.WriteAllText(outputReportPath, csvBuilder.ToString());

            Console.WriteLine($"Password attempt report saved to: {outputReportPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to verify which password from a known list unlocks a protected ZIP file without exposing the passwords, they can use this code to attempt each password and record success in a CSV.
 * 2. When auditing security of archived data and generating a report of password attempts for compliance, this approach automates the trial and logs attempt numbers and outcomes.
 * 3. When integrating a password‑cracking routine into a larger C# application that processes user‑uploaded ZIP files, the snippet shows how to safely try candidate passwords and capture results without storing the secret.
 * 4. When troubleshooting a corrupted or forgotten ZIP password, a developer can supply possible passwords and obtain a quick CSV summary indicating which one works.
 * 5. When building a batch job that scans multiple archives with predefined password candidates and needs a lightweight report of successful unlocks, this code provides the necessary logic and CSV output.
 */
