namespace HBS.Core.Entities;

public sealed record Coordinates
{
    public Coordinates(double longitude, double latitude)
    {
        Longitude = Math.Round(longitude, 4);
        Latitude = Math.Round(latitude, 4);
    }

    public double Longitude { get; }
    public double Latitude { get; }
}