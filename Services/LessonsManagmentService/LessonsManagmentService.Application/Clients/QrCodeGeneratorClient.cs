using System.Net.Http.Json;

namespace LessonsManagmentService.Application.Clients;

public class QrCodeGeneratorClient
{
    private readonly HttpClient _httpClient;

    public QrCodeGeneratorClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<byte[]> GenerateQrCodeAsync(string data)
    {
        var response = await _httpClient.PostAsJsonAsync("api/QrCode/GenerateQrCode", new { Data = data });

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsByteArrayAsync();
        }

        return null;
    }
}