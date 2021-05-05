using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MuscleCarRentProject.Data
{
    public enum AccessLevel
    {
        Admin,
        User
    }

    public sealed class AccessType
    {
        public int ID { get; set; }
        [InverseProperty(nameof(Account.AccessType))]
        public ICollection<Account> Accounts { get; set; }
        public AccessLevel AccessLevel { get; set; }
    }
}
