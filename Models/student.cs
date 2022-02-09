using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace dotnetMidtermStarter.Models;

public class Student {
    
    //JSON property name should be here because google charts excpects it.


    [Key]
    [JsonPropertyName("Id")]
    public string? Id { get; set; }

    [JsonPropertyName("FirstName")]
    public string? FirstName { get; set; }

    [JsonPropertyName("LastName")]
    public string? LastName { get; set; }

    [JsonPropertyName("Department")]
    public string? Department { get; set; }
}