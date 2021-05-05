using System.ComponentModel.DataAnnotations;
using Data.Common;

namespace MuscleCarRentProject.Data
{
    public sealed class ImageData : BaseData
    {
        [Display(Name = "Image path")]
        public string ImagePath { get; set; }

        public CarData Car { get; set; }
        public int CarID { get; set; }
    }
}
