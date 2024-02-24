using System.Net.Http.Json;
using System.Text;
using AttendanceService.Core.Data;
using AttendanceService.Core.Entities;
using Newtonsoft.Json;

namespace AttendanceService.Application.Clients;

public class LessonGeneratorClient : ILessonGeneratorClient
{
    private readonly HttpClient _httpClient;

    public LessonGeneratorClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<Lesson> GenerateLessonAsync(AddLessonResponse data)
    {
        string jsonContent = JsonConvert.SerializeObject(data);

        StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
        
        var response = await _httpClient.PostAsJsonAsync("http://localhost:5082/api/LessonsManagment/GenerateLesson", new
        {
            TeacherId = data.TeacherId.ToString(),
            StudentIds = data.StudentIds.Select(x => x.ToString()).ToList()
        });

        if (response.IsSuccessStatusCode)
        {
            string responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Lesson>(responseContent);
        }

        return null;
    }
}