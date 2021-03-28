using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MuscleCarRent.Models
{
    public enum AccessLevel
    {
        Admin,
        User
    }

    public class AccessType
    {
        [InverseProperty(nameof(Account.AccessType))]
        public ICollection<Account> Accounts { get; set; }
        public AccessLevel AccessLevel { get; set; }
    }
}
