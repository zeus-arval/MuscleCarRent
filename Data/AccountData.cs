using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MuscleCarRentProject.Data.Common;

namespace MuscleCarRentProject.Data
{
    public sealed class AccountData : PersonInfoData
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
        public string PersonalPhoto { get; set; }
        public string DrivingLicense { get; set; }
        public bool? IsDrivingLicenseValid { get; set; } = false;
        public string AccessTypeID { get; set; }
        public string BankCardID { get; set; }
    }
}
