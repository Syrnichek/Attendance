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
        string jsonContent = JsonConvert.SerializeObject(data);
        
        StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
        
        var response = await _httpClient.PostAsJsonAsync("http://localhost:5048/api/Auth/ParseJwt", content);

        if (response.IsSuccessStatusCode)
        {
            string responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<UserBase>(responseContent);
        }

        return null;
    }
}