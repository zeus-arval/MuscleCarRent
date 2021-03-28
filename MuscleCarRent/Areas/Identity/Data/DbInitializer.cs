using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MuscleCarRent.Data;
using MuscleCarRent.Models;

namespace MuscleCarRent.Areas.Identity.Data
{
    public class DbInitializer
    {
        public static void Initialize(MuscleCarRentContext context)
        {
            context.Database.EnsureCreated(); //Creating database if it does not exists

            //Looking for any car
            if (context.Cars.Any())
            {
                return; // DB exists and is seeded
            }

            string basePath = @"~\wwwroot\images\";

            var cars = new Car[]
            {
                new Car
                {
                    ID = 1, Model = "Galaxie 500 Sunliner", Brand = Brand.Ford, NumberOfSeats = 4, Power = 352, Engine = "V8 6.4",
                    BodyType = BodyType.FullSize, ProductionYear = 1961, Color = "Black", BasePrice = 100, PricePerHour = 20,
                    Images =
                        {
                            new Image{ImagePath = $"{basePath}FordGalaxie1", CarID = 1},
                            new Image{ImagePath = $"{basePath}FordGalaxie2", CarID = 1},
                            new Image{ImagePath = $"{basePath}FordGalaxie3", CarID = 1},
                            new Image{ImagePath = $"{basePath}FordGalaxie4", CarID = 1},
                            new Image{ImagePath = $"{basePath}FordGalaxie5", CarID = 1},
                            new Image{ImagePath = $"{basePath}FordGalaxie6", CarID = 1}
                        },
                    ShortDescription = "Black exterior, white convertible top, red and white interior.",
                    LongDescription = "Black beast with white convertible top and chrome accents. Red and white interior can surprise you. Transmition " +
                                      "is automatic with 3 speeds."
                },
                new Car
                {
                    ID = 2, Model = "GTX", Brand = Brand.Plymouth, NumberOfSeats = 4, Power = 425, Engine = "426ci V8 HEMI Engine",
                    BodyType = BodyType.PonyCar, ProductionYear = 1967, Color = "Blue", BasePrice = 110, PricePerHour = 23, 
                    Images =
                    {
                        new Image{ImagePath = $"{basePath}GTX1", CarID = 2},
                        new Image{ImagePath = $"{basePath}GTX2", CarID = 2},
                        new Image{ImagePath = $"{basePath}GTX3", CarID = 2},
                        new Image{ImagePath = $"{basePath}GTX4", CarID = 2},
                        new Image{ImagePath = $"{basePath}GTX5", CarID = 2},
                        new Image{ImagePath = $"{basePath}GTX6", CarID = 2}
                    },
                    ShortDescription = "Bright blue metallic exterior, black interior.",
                    LongDescription = "Excellent car with blue metallic exterior and black interior. 426ci V8 HEMI engine coupled with 3 speed automatic " +
                                      "transmition will give you a hot ride"
                }
            };
            
            context.Cars.AddRange();
            context.SaveChanges();

            var drivers = new Driver[]
            {
                new Driver
                {
                    FirstName = "Michael", LastName = "Vaggner", BirthDate = new DateTime(1992, 02, 12),
                    IsAvailable = true
                },
                new Driver
                {
                    FirstName = "Rain", LastName = "Copper", BirthDate = new DateTime(1994, 12, 03),
                     IsAvailable = true
                }
            };

            context.Drivers.AddRange();
            context.SaveChanges();
            
        }
    }
}
