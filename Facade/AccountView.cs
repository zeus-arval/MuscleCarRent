﻿using System;
using System.ComponentModel.DataAnnotations;
using Facade.Common;
using Microsoft.AspNetCore.Http;

namespace Facade
{
    public sealed class AccountView : PersonView
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

        [Display(Name = "Driving license")]
        public IFormFile DLPhoto { get; set; }
        [Display(Name = "Driving license")]
        public string DrivingLicensePhotoAsString { get; set; }
        [Display(Name = "Is DL valid")]
        public bool? IsDrivingLicenseValid { get; set; } = false;
        [Display(Name = "BankCard Id")]
        public string BankCardId { get; set; }
        [Display(Name = "BankCard")]
        public string BankCardNumber { get; set; }
        [Display(Name = "Access Type ID")]
        public string AccessTypeId { get; set; }
        [Display(Name = "Access Type ID")]
        public string AccessTypeName { get; set; }
    }
}
