using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace MuscleCarRent.Models
{
    public class Account : Person
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string? PersonalPhoto { get; set; }
        public string? DrivingLicense { get; set; }
        public bool? IsDrivingLicenseValid { get; set; }

        [InverseProperty(nameof(Order.Account))]
        public ICollection<Order> Orders { get; set; }
        public AccessType AccessType { get; set; }
        public BankCard? BankCard { get; set; }
        [InverseProperty(nameof(Promotion.Account))]
        public ICollection<Promotion> Promotions { get; set; }
        [InverseProperty(nameof(PersonalPromotion.Account))]
        public ICollection<PersonalPromotion> PersonalPromotions { get; set; }
    }
}
