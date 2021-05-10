using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Core;

namespace MuscleCarRentProject.Data
{
    public sealed class AccessTypeData : UniqueItem
    {
        [InverseProperty(nameof(AccountData.AccessType))]
        public ICollection<AccountData> Accounts { get; set; }
        public AccessLevel AccessLevel { get; set; }
    }
}
