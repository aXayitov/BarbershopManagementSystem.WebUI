using System.ComponentModel.DataAnnotations;

namespace BarbershopManagementSystem.WebUI.Configuration;

public class ApiConfiguration
{
    public const string SectionName = "API";

    [Required]
    public string Url { get; init; }
}
