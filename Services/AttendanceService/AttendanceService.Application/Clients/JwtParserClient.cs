using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
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
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", data);
        
        var response = await _httpClient.PostAsJsonAsync("https://localhost:7145/api/Auth/ParseJwt", new { Data = data });

        if (response.IsSuccessStatusCode)
        {
            string responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<UserBase>(responseContent);
        }

        return null;
    }
}