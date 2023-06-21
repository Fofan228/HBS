using HBS.Core.Entities;
using HBS.Migrations;

var factory = new Factory();
var context = factory.CreateDbContext(args);

var hotels = new List<Hotel>()
{
    new(0, 10, new(10, 10), "Hotel 0", "Address 0", "Short description 0", "Long description 0", new[] { "Photo 0", "Photo 1", "Photo 2" }),
    new(0, 20, new(20, 20), "Hotel 1", "Address 1", "Short description 1", "Long description 1", new[] { "Photo 3", "Photo 4", "Photo 5" }),
    new(0, 30, new(30, 30), "Hotel 2", "Address 2", "Short description 2", "Long description 2", new[] { "Photo 6", "Photo 7", "Photo 8" })
};

context.Hotels.AddRange(hotels);
context.SaveChanges();