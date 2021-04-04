using MuscleCarRent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuscleCarRent.Data
{
    public class DbInitializer
    {
        public static void Initialize(MuscleCarRentDBContext context)
        {
            if (context.Cars.Any())
                return;

            var drivers = new Driver[]
           {
                new Driver
                {
                    FirstName = "Michael", LastName = "Vaggner", BirthDate = new DateTime(1992, 02, 12),
                    IsAvailable = true, OrderedDates = null, Cars =  null
                },
                new Driver
                {
                    FirstName = "Rain", LastName = "Copper", BirthDate = new DateTime(1994, 12, 03),
                     IsAvailable = true, OrderedDates = null, Cars =  null
                }
           };

            context.Drivers.AddRange(drivers);
            context.SaveChanges();


            var carTypes = new CarType[]
            {
                new CarType{ RentType = (RentType)0},
                new CarType{ RentType = (RentType)1},
                new CarType{ RentType = (RentType)2},
                new CarType{ RentType = (RentType)3},
            };

            context.CarTypes.AddRange(carTypes);
            context.SaveChanges();

            var cars = new Car[]
            {
                new Car
                {
                    Model = "Galaxie 500 Sunliner", Brand = Brand.Ford, NumberOfSeats = 4, Power = 352, Engine = "V8 6.4",
                    BodyType = BodyType.FullSize, ProductionYear = 1961, Color = "Black", BasePrice = 100, PricePerHour = 20, CarTypeID = 1, 
                    DriverID = 1, IsFavourite = false, IsPopular = false, NeedDriver = false, Surcharge = 0, Driver = null,
                    ShortDescription = "Black exterior, white convertible top, red and white interior.",
                    LongDescription = "Black beast with white convertible top and chrome accents. Red and white interior can surprise you. Transmition " +
                                      "is automatic with 3 speeds."
                },
                new Car
                {
                    Model = "GTX", Brand = Brand.Plymouth, NumberOfSeats = 4, Power = 425, Engine = "426ci V8 HEMI Engine",
                    BodyType = BodyType.PonyCar, ProductionYear = 1967, Color = "Blue", BasePrice = 110, PricePerHour = 23, CarTypeID = 1,
                    DriverID = 2, IsFavourite = false, IsPopular = false, NeedDriver = false, Surcharge = 0, Driver = null,
                    ShortDescription = "Bright blue metallic exterior, black interior.",
                    LongDescription = "Excellent car with blue metallic exterior and black interior. 426ci V8 HEMI engine coupled with 3 speed automatic " +
                                      "transmition will give you a hot ride"
                }
            };
            context.Cars.AddRange(cars);
            context.SaveChanges();

            string basePath = @"~\wwwroot\images\";

            var images = new Image[]
            {
                new Image { CarID = 1, ImagePath = basePath + "FordGalaxie1" },
                new Image { CarID = 1, ImagePath = basePath + "FordGalaxie2" },
                new Image { CarID = 1, ImagePath = basePath + "FordGalaxie3" },
                new Image { CarID = 1, ImagePath = basePath + "FordGalaxie4" },
                new Image { CarID = 1, ImagePath = basePath + "FordGalaxie5" },
                new Image { CarID = 1, ImagePath = basePath + "FordGalaxie6" },

                new Image { CarID = 2, ImagePath = basePath + "GTX1" },
                new Image { CarID = 2, ImagePath = basePath + "GTX2" },
                new Image { CarID = 2, ImagePath = basePath + "GTX3" },
                new Image { CarID = 2, ImagePath = basePath + "GTX4" },
                new Image { CarID = 2, ImagePath = basePath + "GTX5" },
                new Image { CarID = 2, ImagePath = basePath + "GTX6" }
            };
            context.Images.AddRange(images);
            context.SaveChanges();
        }
    }
}
