using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Core;
using Data.Common;

namespace MuscleCarRentProject.Data
{
    public sealed class AccessTypeData : BaseData
    {
        public AccessLevelEnum AccessLevel { get; set; }
    }
}
