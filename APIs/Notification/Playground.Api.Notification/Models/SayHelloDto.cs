using System.Text.Json.Serialization;

namespace Playground.Api.Models;

public class SayHelloDto
{
    [JsonPropertyName("message")]
    public string Message { get; set; }
}
