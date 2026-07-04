namespace ArtDeq.Models;

public class Artwork
{
    public string Id { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public Artist Artist { get; set; } = new();
    public string ImageUrl { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Currency { get; set; } = "AUD";
    public ArtworkType Type { get; set; }
    public string Size { get; set; } = string.Empty;
    public string Medium { get; set; } = string.Empty;
    public string Edition { get; set; } = string.Empty;
    public Availability Availability { get; set; }
    public string ShipsFrom { get; set; } = string.Empty;
    public bool DigitalProofVerified { get; set; }
    public string Description { get; set; } = string.Empty;
    public List<string> Tags { get; set; } = [];
    public int LikeCount { get; set; }
    public int CommentCount { get; set; }
    public bool IsNew { get; set; }
}
