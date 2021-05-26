using Data.Common;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace MuscleCarRentProject.Data
{
    public sealed class ImageData : BaseData
    {
        public byte[] Image { get; set; }
        [StringLength(50)] public string CarModel { get; set; }
        [StringLength(50)] public string CarId { get; set; }
    }
}
