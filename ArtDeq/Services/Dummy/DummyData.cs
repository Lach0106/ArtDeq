using ArtDeq.Models;

namespace ArtDeq.Services.Dummy;

public static class DummyData
{
    public static IReadOnlyList<Artwork> Artworks { get; } = new List<Artwork>
    {
        new()
        {
            Id = "1",
            Title = "Quiet Corner",
            Artist = new Artist
            {
                Handle = "meadow.sketch",
                DisplayName = "Meadow Sketch",
                AvatarUrl = "avatar_meadow_sketch.png",
                IsVerified = true,
                IsActiveNow = true
            },
            ImageUrl = "quiet_corner.png",
            Price = 320m,
            Currency = "USD",
            Type = ArtworkType.Physical,
            Size = "5 x 7 in (12.7 x 17.8 cm)",
            Medium = "Watercolor on Cold Press Paper",
            Edition = "1 / 25 (Hand-signed)",
            Availability = Availability.Available,
            ShipsFrom = "Canada",
            DigitalProofVerified = true,
            Description = "A soft study of morning light filtering through a bedroom window, painted on a quiet Sunday.",
            Tags = ["watercolor", "landscape", "original"],
            LikeCount = 142,
            CommentCount = 8,
            IsNew = true
        },
        new()
        {
            Id = "2",
            Title = "Evening Tide",
            Artist = new Artist
            {
                Handle = "coastal.arts",
                DisplayName = "Coastal Arts",
                AvatarUrl = "avatar_coastal_arts.png",
                IsVerified = false,
                IsActiveNow = false
            },
            ImageUrl = "evening_tide.png",
            Price = 480m,
            Currency = "USD",
            Type = ArtworkType.Physical,
            Size = "8 x 10 in (20.3 x 25.4 cm)",
            Medium = "Oil on Canvas",
            Edition = "Original",
            Availability = Availability.Available,
            ShipsFrom = "Australia",
            DigitalProofVerified = false,
            Description = "The golden hour over the Pacific coast, captured in oils.",
            Tags = ["oil", "seascape", "original"],
            LikeCount = 89,
            CommentCount = 5
        },
        new()
        {
            Id = "3",
            Title = "Urban Bloom",
            Artist = new Artist
            {
                Handle = "city.petals",
                DisplayName = "City Petals Studio",
                AvatarUrl = "avatar_city_petals.png",
                IsVerified = true,
                IsActiveNow = true
            },
            ImageUrl = "urban_bloom.png",
            Price = 195m,
            Currency = "USD",
            Type = ArtworkType.Digital,
            Size = "3000 x 4000 px (300 dpi)",
            Medium = "Digital Painting",
            Edition = "1 / 10 (Signed Print)",
            Availability = Availability.Available,
            ShipsFrom = "UK",
            DigitalProofVerified = true,
            Description = "Where concrete meets wildflowers — a love letter to city gardens.",
            Tags = ["digital", "floral", "urban"],
            LikeCount = 214,
            CommentCount = 19,
            IsNew = true
        },
        new()
        {
            Id = "4",
            Title = "Golden Hour",
            Artist = new Artist
            {
                Handle = "lightseekers",
                DisplayName = "Lightseekers Co.",
                AvatarUrl = "avatar_lightseekers.png",
                IsVerified = true,
                IsActiveNow = false
            },
            ImageUrl = "golden_hour.png",
            Price = 750m,
            Currency = "USD",
            Type = ArtworkType.Physical,
            Size = "12 x 16 in (30.5 x 40.6 cm)",
            Medium = "Acrylic on Wood Panel",
            Edition = "Original",
            Availability = Availability.Sold,
            ShipsFrom = "USA",
            DigitalProofVerified = true,
            Description = "Light as subject, not scene. This piece is about the feeling of 5pm.",
            Tags = ["acrylic", "abstract", "light"],
            LikeCount = 331,
            CommentCount = 24
        },
        new()
        {
            Id = "5",
            Title = "Minimal Study #3",
            Artist = new Artist
            {
                Handle = "form.studio",
                DisplayName = "Form Studio",
                AvatarUrl = "avatar_form_studio.png",
                IsVerified = false,
                IsActiveNow = true
            },
            ImageUrl = "minimal_study_3.png",
            Price = 260m,
            Currency = "USD",
            Type = ArtworkType.Physical,
            Size = "6 x 6 in (15.2 x 15.2 cm)",
            Medium = "Ink on Arches Paper",
            Edition = "3 / 15 (Hand-signed)",
            Availability = Availability.Available,
            ShipsFrom = "Japan",
            DigitalProofVerified = false,
            Description = "The third in a series exploring negative space and restrained line.",
            Tags = ["ink", "minimal", "abstract"],
            LikeCount = 67,
            CommentCount = 3
        },
        new()
        {
            Id = "6",
            Title = "Forest Spirit",
            Artist = new Artist
            {
                Handle = "woodlandink",
                DisplayName = "Woodland Ink",
                AvatarUrl = "avatar_woodland_ink.png",
                IsVerified = false,
                IsActiveNow = false
            },
            ImageUrl = "forest_spirit.png",
            Price = 390m,
            Currency = "USD",
            Type = ArtworkType.Physical,
            Size = "9 x 12 in (22.9 x 30.5 cm)",
            Medium = "Gouache on Black Paper",
            Edition = "Original",
            Availability = Availability.Available,
            ShipsFrom = "Canada",
            DigitalProofVerified = true,
            Description = "Ancient trees as guardians. Painted in gouache on black paper for a luminous effect.",
            Tags = ["gouache", "botanical", "illustration"],
            LikeCount = 178,
            CommentCount = 11
        },
    };
}
