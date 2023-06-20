namespace HBS.Core.Models;

public struct Coordinate
{
    public Coordinate(double longitude, double latitude)
    {
        Longitude = longitude;
        Latitude = latitude;
    }

    public double Longitude { get; private set; }
    public double Latitude { get; private set; }
}