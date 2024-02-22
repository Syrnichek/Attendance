using System.Net.Http.Json;
using System.Text;
using AttendanceService.Application.Commands;
using AttendanceService.Core.Entities;
using Newtonsoft.Json;

namespace AttendanceService.Application.Clients;

public class LessonGeneratorClient
{
    private readonly HttpClient _httpClient;

    public LessonGeneratorClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<Lesson> GenerateLessonAsync(AddLessonCommand data)
    {
        string jsonContent = JsonConvert.SerializeObject(data);
        
        StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
        
        var response = await _httpClient.PostAsJsonAsync("http://localhost:5082/api/LessonsManagment/GenerateLesson", content);

        if (response.IsSuccessStatusCode)
        {
            string responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Lesson>(responseContent);
        }

        return null;
    }
}