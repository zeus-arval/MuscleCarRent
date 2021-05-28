using System;
using System.ComponentModel.DataAnnotations;
using Core;
using Data.Common;

namespace MuscleCarRentProject.Data.Common
{
    public abstract class PersonInfoData : BaseData, IPersonInfoEntityData
    {
        [StringLength(50)] public string FirstName { get; set; }
        [StringLength(50)] public string LastName { get; set; }
        public byte[] PersonPhoto { get; set; }
        public DateTime Birthday { get; set; }
    }
}
