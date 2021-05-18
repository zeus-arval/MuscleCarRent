using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MuscleCarRentProject.Data;
using MuscleCarRentProject.Facade.Common;

namespace Facade
{
    public sealed class AccountView : BaseView
    {
        [Required]
        [MaxLength(50)]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Registration date")]
        public DateTime RegistrationDate { get; set; } = DateTime.Now;

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Personal photo")]
        public string PersonalPhoto { get; set; }
        [Display(Name = "Driving license")]
        public string DrivingLicense { get; set; }
        [Display(Name = "Is DL valid")]
        public bool? IsDrivingLicenseValid { get; set; } = false;
        public string BankCardID { get; set; }
        public string BankCardNumber { get; set; }
    }
}
