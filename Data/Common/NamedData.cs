using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Data.Common;

namespace MuscleCarRentProject.Data.Common
{
    public abstract class NamedData : BaseData, IPersonInfoEntityData
    {
        [Required]
        [StringLength(50)]
        [Display(Name = "First name")]
        [RegularExpression(@"^[A-Za-z]{2,50}", ErrorMessage = "Person's name has to contain only letters")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "First name")]
        [RegularExpression(@"^[A-Za-z]{2,50}", ErrorMessage = "Person's name has to contain only letters")]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
    }
}
