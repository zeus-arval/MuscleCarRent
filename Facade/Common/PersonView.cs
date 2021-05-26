using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MuscleCarRentProject.Facade.Common;

namespace Facade.Common
{
    public abstract class PersonView : BaseView
    {
        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Display(Name = "First name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z '-]*$")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        [Display(Name = "Last name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z '-]*$")]
        public string LastName { get; set; }
        [Display(Name = "Full name")] public string FullName { get; set; }
        [Display(Name = "New Photo")] public IFormFile PersonPhoto { get; set; }
        [Display(Name = "Current photo")] public string PersonPhotoAsString { get; set; }
    }
}
