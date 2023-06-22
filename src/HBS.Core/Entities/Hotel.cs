namespace HBS.Core.Entities;

public sealed class Hotel
{
    public Hotel(long id, double rating, Coordinates coordinates, string name, string address, string shortDescription, string longDescription, string[] photos, string city)
    {
        Id = id;
        Rating = rating;
        Coordinates = coordinates;
        Name = name;
        Address = address;
        ShortDescription = shortDescription;
        LongDescription = longDescription;
        Photos = photos;
        City = city;
    }

    private Hotel() { }

    public long Id { get; set; }
    public double Rating { get; set; }
    public Coordinates Coordinates { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string ShortDescription { get; set; } = null!;
    public string LongDescription { get; set; } = null!;
    public string[] Photos { get; set; } = null!;
    public string City { get; set; } = null!;
}