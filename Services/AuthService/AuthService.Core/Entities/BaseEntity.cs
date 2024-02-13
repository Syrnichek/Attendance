using System.ComponentModel.DataAnnotations;

namespace AuthService.Core.Entities;

public class BaseEntity
{
    [Key]
    public string Id { get; set; }
    
    public string Name { get; set; }
}