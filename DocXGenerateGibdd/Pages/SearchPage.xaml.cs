using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using DocXGenerateGibdd.Api;
using DocXGenerateGibdd.FileGenerate;
using DocXGenerateGibdd.Models;

namespace DocXGenerateGibdd.Pages;

public partial class SearchPage : Page
{
    public DriveLicense driveLicense { get; set; } = new DriveLicense();
    private readonly GenerateDoc _generateDoc;

    public SearchPage()
    {
        InitializeComponent();
        this.DataContext = driveLicense;
        _generateDoc = new GenerateDoc();
    }

    private async void SearchAdnGenerate_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            _generateDoc.Generate(await DriverLicenseApi.GetLicense(driveLicense.CertificateNumber));
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            throw;
        }
    }
}