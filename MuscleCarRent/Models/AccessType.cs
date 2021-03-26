using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuscleCarRent.Models
{
    public enum AccessLevel
    {
        Admin = 1,
        User
    }

    public class AccessType
    {
        public ICollection<Account> Accounts { get; set; }
        public AccessLevel AccessLevel { get; set; }
    }
}
