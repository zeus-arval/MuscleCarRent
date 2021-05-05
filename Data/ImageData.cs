using System.ComponentModel.DataAnnotations;

namespace MuscleCarRentProject.Data
{
    public sealed class ImageData
    {
        public int ID { get; set; }
        [Display(Name = "Image path")]
        public string ImagePath { get; set; }

        public CarData Car { get; set; }
        public int CarID { get; set; }
    }
}
