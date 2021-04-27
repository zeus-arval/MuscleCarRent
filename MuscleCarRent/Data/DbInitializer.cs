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
                    IsAvailable = true, Cars =  null
                },
                new Driver
                {
                    FirstName = "Rain", LastName = "Copper", BirthDate = new DateTime(1994, 12, 03),
                     IsAvailable = true, Cars =  null
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
                    Brand = Brand.Plymouth, Model = "GTX", ShortDescription = "Black exterior, white convertible top, red and white interior.", 
                    LongDescription = "Black beast with white convertible top and chrome accents. Red and white interior can surprise you. Transmition is automatic with 3 speeds.",
                    ProductionYear = 1967, IsPopular = false, IsFavourite = false, Power = 425, Color = Color.Blue, BasePrice = 110, PricePerHour = 23, NumberOfSeats = 4, Engine = "426ci V8 HEMI",
                    NeedDriver = false, Surcharge = 0, DriverID = 2, CarTypeID = 1, BodyType = BodyType.PonyCar
                },
                new Car
                {
                    Brand = Brand.Ford, Model = "Galaxie 500 Sunliner",  ShortDescription = "Black exterior, white convertible top, red and white interior.",
                    LongDescription = "Black beast with white convertible top and chrome accents. Red and white interior can surprise you. Transmition is automatic with 3 speeds.",
                    ProductionYear = 1961, IsPopular = false, IsFavourite = false, Power = 352, Color = Color.Black, BasePrice = 100, PricePerHour = 20, NumberOfSeats = 4, Engine = "V8 6.4",
                    NeedDriver = false, Surcharge = 0, DriverID = 1, CarTypeID = 1, BodyType = BodyType.FullSize
                },
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

            var accounts = new Account[]
            {
                new Account
                {
                    BirthDate = new DateTime(1998,03,18), Email = "eragonart@gmail.com", FirstName = "Arturius", LastName = "Valden", Password = "As8fas46g", PhoneNumber = "+3725786421", RegistrationDate = new DateTime(2021, 04, 24), Username = "ArturiusValden" 
                },
                new Account
                {
                    BirthDate = new DateTime(1999,01,24), Email = "eduardbudr@gmail.com", FirstName = "Eduard", LastName = "Budr", Password = "ho2A5asd456", PhoneNumber = "+3725586269", RegistrationDate = new DateTime(2021, 04, 23), Username = "Eduardo"
                }
            };
            context.Accounts.AddRange(accounts);
            context.SaveChanges();
        }
    }
}
