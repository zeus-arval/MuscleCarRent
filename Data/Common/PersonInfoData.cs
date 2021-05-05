using System;
using System.ComponentModel.DataAnnotations;
using Core;
using Data.Common;

namespace MuscleCarRentProject.Data.Common
{
    public abstract class PersonInfoData : BaseData, IPersonInfoEntityData
    {
        [Display(Name = "First Name")]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [StringLength(50)]
        public string LastName { get; set; }
        [DataType(DataType.Date)]public DateTime BirthDay { get; set; }
    }
}
