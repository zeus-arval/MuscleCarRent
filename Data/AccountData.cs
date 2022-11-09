using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MuscleCarRentProject.Data.Common;

namespace MuscleCarRentProject.Data
{
    public sealed class AccountData : PersonInfoData
    {
        [StringLength(50)] public string Username { get; set; }
        [StringLength(50)] public string Password { get; set; }
        [StringLength(50)] public string Email { get; set; }
        [StringLength(50)] public string PhoneNumber { get; set; }
        public byte[] DrivingLicensePhoto { get; set; }
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
        public bool? IsDrivingLicenseValid { get; set; } = false;

        [StringLength(50)] public string AccessTypeId { get; set; }
        [StringLength(50)] public string AccessTypeName { get; set; }

        [StringLength(50)] public string BankCardId { get; set; }
        [StringLength(50)] public string BankCardNumber { get; set; }
    }
}
