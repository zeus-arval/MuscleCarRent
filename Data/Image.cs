using System.ComponentModel.DataAnnotations;

namespace MuscleCarRentProject.Data
{
    public sealed class Image
    {
        public int ID { get; set; }
        [Display(Name = "Image path")]
        public string ImagePath { get; set; }

        public Car Car { get; set; }
        public int CarID { get; set; }
    }
}
