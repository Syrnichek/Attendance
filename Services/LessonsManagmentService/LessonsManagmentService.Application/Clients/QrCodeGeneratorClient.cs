using System.Net.Http.Json;
using LessonsManagmentService.Core.Data;

namespace LessonsManagmentService.Application.Clients;

public class QrCodeGeneratorClient : IQrCodeGeneratorClient
{
    private readonly HttpClient _httpClient;

    public QrCodeGeneratorClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<byte[]> GenerateQrCodeAsync(string data)
    {
        var response = await _httpClient.PostAsJsonAsync("http://localhost:5245/api/QrCode/GenerateQrCode", new { Data = data });

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsByteArrayAsync();
        }

        return null;
    }
}