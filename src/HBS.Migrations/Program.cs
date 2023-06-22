using HBS.Core.Entities;
using HBS.Migrations;

var factory = new Factory();
var context = factory.CreateDbContext(args);

Console.WriteLine("Set default data started...");

var hotels = new List<Hotel>()
{
    new(
    id: 0,
    rating: 9.4,
    coordinates: new(55.167137, 61.379574),
    name: "Raddison Blu",
    address: "ул. Труда, 179",
    shortDescription: "Рестик с пивом на первом этаже",
    longDescription: "В целом ничё так, правда дороговато, да и пиво дорогое",
    photos: new[]
    {
        "https://avatars.mds.yandex.net/get-altay/4562252/2a0000017c0aa9847ab0268650ee32e6d324/XXL",
        "https://q.bstatic.com/images/hotel/max1024x768/297/29708934.jpg",
        "http://img-fotki.yandex.ru/get/9169/183023283.7d/0_f7fea_2e778fd7_XXL.jpg"
    }),

    new(
    id: 0,
    rating: 8.3,
    coordinates: new(55.16725, 61.395924),
    name: "Малахит",
    address: "ул. Труда, 153",
    shortDescription: "Выпускной там был, прикольно внутри",
    longDescription: "Ну отель как отель, чё бубнить то",
    photos: new[]
    {
        "https://www.komandirovka.ru/upload/save_file31/2b3/2b35da40e84368caecf3d942050b9471.jpg",
        "https://www.multitour.ru/files/imgs/77a04c3fb0b2f9d90c299f7b77b930bf738aac7c.jpeg",
        "https://img-fotki.yandex.ru/get/9061/24559203.c/0_c2d7f_972e0045_XL.jpg"
    }),

    new(
    id: 0,
    rating: 30,
    coordinates: new(55.161903, 61.43048),
    name: "Видгов",
    address: "просп. Ленина, 26А",
    shortDescription: "Рядом Горки и внутри прикольный туннель стеклянный",
    longDescription: "Не уверен, что в туннель пустят, рядом с Горками могут убить",
    photos: new[]
    {
        "https://fkomplekt.ru/uploadedFiles/catalogimages/big/223128_466185913421530_711943627_n.jpg",
        "https://s.101hotelscdn.ru/uploads/image/hotel_image/2556/281942.jpg",
        "https://sdoclub.ru/files/pages/%D0%B4%D0%B2%D0%B0%20%D0%B7%D0%B4%D0%B0%D0%BD%D0%B8%D1%8F%20%D1%81%20%D0%BF%D0%B5%D1%80%D0%B5%D1%85%D0%BE%D0%B4%D0%BE%D0%BC.jpg"
    })
};

context.Hotels.AddRange(hotels);
context.SaveChanges();

Console.WriteLine("Set default data succeeded.");