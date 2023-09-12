using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using DocXGenerateGibdd.Models;

namespace DocXGenerateGibdd.Api;

public class DriverLicenseApi
{
    private static HttpClient GetHttpClient => new HttpClient();
    private static string BaseAddress => "http://localhost/InfoBase1/hs/CertificateCenter/getData/";

    public static async Task<DriveLicense?> GetLicense(string certificateNumber)
    {
        var httpClient = GetHttpClient;
        
        string json = await httpClient.GetStringAsync(BaseAddress + certificateNumber);
        
        return JsonSerializer.Deserialize<DriveLicense>(json);
    }
}