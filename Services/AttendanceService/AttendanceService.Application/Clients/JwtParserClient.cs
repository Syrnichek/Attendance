using System.Net.Http.Json;
using AttendanceService.Core.Data;
using AttendanceService.Core.Entities;
using Newtonsoft.Json;

namespace AttendanceService.Application.Clients;

public class JwtParserClient : IJwtParserClient
{
    private readonly HttpClient _httpClient;

    public JwtParserClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<UserBase> ParseJwtAsync(string data)
    {
        var response = await _httpClient.PostAsJsonAsync("http://localhost:5291/api/JwtParser/ParseJwt", new { Data = data });

        if (response.IsSuccessStatusCode)
        {
            string responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<UserBase>(responseContent);
        }

        return null;
    }
}