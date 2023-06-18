using TAF_TMS_C1onl.Models.Enums;

namespace TAF_TMS_C1onl.Models;

public record User
{
    public UserType UserType { get; set; }
    public string? Username { get; init; } = string.Empty;
    public string? Password { get; init; } = string.Empty;
}