using System;
using System.Linq;
using MuscleCarRentProject.Data;
using MuscleCarRentProject.Infra;

namespace MuscleCarRentProject.Infra.Common
{
    public class DbInitializer
    {
        public static void Initialize(MuscleCarRentDBContext context)
        {
            if (context.Cars.Any())
                return;
            
            var drivers = new DriverData[]
            {
                new()
                {
                    FirstName = "Michael", LastName = "Vaggner", Birthday = new DateTime(1992, 02, 12), 
                    IsAvailable = true
                },
                new()
                {
                    FirstName = "Rain", LastName = "Copper", Birthday = new DateTime(1994, 12, 03),
                     IsAvailable = true
                }
            };

            context.Drivers.AddRange(drivers);
            context.SaveChanges();


            var carTypes = new CarTypeData[]
            {
                new CarTypeData{ RentTypeEnum = (RentTypeEnum)0},
                new CarTypeData{ RentTypeEnum = (RentTypeEnum)1},
                new CarTypeData{ RentTypeEnum = (RentTypeEnum)2},
                new CarTypeData{ RentTypeEnum = (RentTypeEnum)3},
            };

            context.CarTypes.AddRange(carTypes);
            context.SaveChanges();

            var accessTypes = new AccessTypeData[] {
                new() {AccessLevel = AccessLevelEnum.Admin},
                new() {AccessLevel = AccessLevelEnum.User}
            };
            
            context.AccessTypes.AddRange(accessTypes);
            context.SaveChanges();

            var cars = new CarData[]
            {
                new CarData
                {
                    Brand = BrandEnum.Plymouth, Model = "GTX", ShortDescription = "Black exterior, white convertible top, red and white interior.", 
                    LongDescription = "Black beast with white convertible top and chrome accents. Red and white interior can surprise you. Transmition is automatic with 3 speeds.",
                    ProductionYear = 1967, IsPopular = false, IsFavourite = false, Power = 425, Color = ColorEnum.Blue, BasePrice = 110, PricePerHour = 23, NumberOfSeats = 4, Engine = "426ci V8 HEMI",
                    NeedDriver = false, Surcharge = 0, BodyType = BodyTypeEnum.PonyCar
                },
                new CarData
                {
                    Brand = BrandEnum.Ford, Model = "Galaxie 500 Sunliner",  ShortDescription = "Black exterior, white convertible top, red and white interior.",
                    LongDescription = "Black beast with white convertible top and chrome accents. Red and white interior can surprise you. Transmition is automatic with 3 speeds.",
                    ProductionYear = 1961, IsPopular = false, IsFavourite = false, Power = 352, Color = ColorEnum.Black, BasePrice = 100, PricePerHour = 20, NumberOfSeats = 4, Engine = "V8 6.4",
                    NeedDriver = false, Surcharge = 0, BodyType = BodyTypeEnum.FullSize
                },
            };
            context.Cars.AddRange(cars);
            context.SaveChanges();
            
            var images = new ImageData[]
            {
                new() {Image = null, CarId = null}
            };

            context.Images.AddRange(images);
            context.SaveChanges();

            var bankCards = new BankCardData[] {
                new() {
                    CardHolderFullName = "Artur Valdna", CVV = 123, CardNumber = 1234567891011121,
                    ExpirationTime = new DateTime(2021, 2, 10)
                }
            };

            context.AddRange(bankCards);
            context.SaveChanges();

            var orders = new OrderData[] { new() };

            context.AddRange(orders);
            context.SaveChanges();

            var orderedData = new OrderedDateData[] {new()};

            context.AddRange(orderedData);
            context.SaveChanges();

            var promotions = new PromotionData[] {new()};

            context.AddRange(promotions);
            context.SaveChanges();

            var accounts = new AccountData[]
            {
                new()
                {
                    Birthday = new DateTime(1998,03,18), Email = "eragonart@gmail.com", FirstName = "Arturius", LastName = "Valden", Password = "As8fas46g", PhoneNumber = "+3725786421", RegistrationDate = new DateTime(2021, 04, 24), Username = "ArturiusValden" 
                },
                new()
                {
                    Birthday = new DateTime(1999,01,24), Email = "eduardbudr@gmail.com", FirstName = "Eduard", LastName = "Budr", Password = "ho2A5asd456", PhoneNumber = "+3725586269", RegistrationDate = new DateTime(2021, 04, 23), Username = "Eduardo"
                }
            };
            context.Accounts.AddRange(accounts);
            context.SaveChanges();
            
        }
    }
}
