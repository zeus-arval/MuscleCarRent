using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Core;
using Data.Common;

namespace MuscleCarRentProject.Data
{
    public sealed class AccessTypeData : BaseData
    {
        public ICollection<AccountData> Accounts { get; set; }
        public AccessLevelEnum AccessLevel { get; set; }
    }
}
