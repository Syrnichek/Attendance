using System.Net.Http.Json;
using System.Text;
using AuthService.Core.Data;
using AuthService.Core.Entities;
using AuthService.Core.Responses;
using Newtonsoft.Json;

namespace AuthService.Application.Clients;

public class RegisterUserClient : IRegisterUserClient
{
    private readonly HttpClient _httpClient;

    public RegisterUserClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<User> RegisterUserAsync(RegisterUserResponse registerUserResponse)
    {
        string jsonContent = JsonConvert.SerializeObject(registerUserResponse);

        StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
        
        var response = await _httpClient.PostAsJsonAsync("http://localhost:5087/api/AttendanceService/AddUser", new
        {
            UserName = registerUserResponse.UserName,
            Password = registerUserResponse.Password,
            UserRole = registerUserResponse.UserRole,
            UserNote = registerUserResponse.UserNote
        });

        if (response.IsSuccessStatusCode)
        {
            string responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<User>(responseContent);
        }

        return null;
    }
}