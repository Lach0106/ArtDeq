namespace ArtDeq.Models;

public class Artist
{
    public string Handle { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public string AvatarUrl { get; set; } = string.Empty;
    public bool IsVerified { get; set; }
    public bool IsActiveNow { get; set; }
}
