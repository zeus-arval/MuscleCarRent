using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using MuscleCarRentProject.Facade.Common;

namespace Facade
{
    public sealed class ImageView : BaseView
    {
        [Display(Name = "New Photo")] public IFormFile Photo { get; set; }
        [Display(Name = "Current Photo")] public string CarPhotoAsString { get; set; }
        [Required] public string CarId { get; set; }
        public string CarModel { get; set; }
    }
}
