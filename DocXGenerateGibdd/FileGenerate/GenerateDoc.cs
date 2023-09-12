using System;
using System.Globalization;
using System.IO;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using DocXGenerateGibdd.Models;
using Xceed.Words.NET;
using Path = System.IO.Path;

namespace DocXGenerateGibdd.FileGenerate;

public class GenerateDoc
{
    string initialTemplate = Path.Combine(Environment.CurrentDirectory, "template.docx");
    string resultDirectoryPath = Path.Combine(Environment.CurrentDirectory, "output");


    public void Generate(DriveLicense driveLicense)
    {
        string outputPath = Path.Combine(resultDirectoryPath, $"{driveLicense.SecondName}.docx");

        File.Copy(initialTemplate, outputPath, true);

        using (WordprocessingDocument doc = WordprocessingDocument.Open(outputPath, true))
        {
            var document = doc.MainDocumentPart?.Document;

            foreach (var text in document.Descendants<Text>())
            {
                if (text.Text.Contains("LastName"))
                    text.Text = text.Text.Replace("LastName", driveLicense.SecondName);

                if (text.Text.Contains("FullName"))
                    text.Text = text.Text.Replace("FullName",
                        $"{driveLicense.FirstName} {driveLicense.MiddleName}");

                if (text.Text.Contains("DateBirth"))
                    text.Text = text.Text.Replace("DateBirth",
                        driveLicense.DateOfBirth.ToString(CultureInfo.InvariantCulture));

                if (text.Text.Contains("PlaceOfBirth"))
                    text.Text = text.Text.Replace("PlaceOfBirth", driveLicense.PlaceOfBirth);

                if (text.Text.Contains("DateStart"))
                    text.Text = text.Text.Replace("DateStart",
                        driveLicense.DateOfIssue.ToString(CultureInfo.InvariantCulture));

                if (text.Text.Contains("DateEnd"))
                    text.Text = text.Text.Replace("DateEnd",
                        driveLicense.ExpirationDate.ToString(CultureInfo.InvariantCulture));

                if (text.Text.Contains("Gibdd"))
                    text.Text = text.Text.Replace("Gibdd", driveLicense.GIBDD);

                if (text.Text.Contains("CertificateNumber"))
                    text.Text = text.Text.Replace("CertificateNumber", driveLicense.CertificateNumber);

                if (text.Text.Contains("PlaceLive"))
                    text.Text = text.Text.Replace("PlaceLive", driveLicense.PlaceOfLiving);

                if (text.Text.Contains("Cathegories"))
                    text.Text = text.Text.Replace("Cathegories",
                        String.Join(" ", driveLicense.CategoryTypes));
                
                
            }
        }
    }
}