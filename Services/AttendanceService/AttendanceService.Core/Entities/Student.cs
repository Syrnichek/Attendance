using System.ComponentModel.DataAnnotations;
using AttendanceService.Core.Entities.Enums;
using Newtonsoft.Json;

namespace AttendanceService.Core.Entities;

public class Student : UserBase
{
    [Key]
    [JsonProperty("studentId")]
    public int Id { get; set; }
    public StudentFlagEnum StudentFlagEnum { get; set; }
}