using Data.Common;
using Microsoft.AspNetCore.Http;

namespace MuscleCarRentProject.Data
{
    public sealed class ImageData : BaseData
    {
        public IFormFile Photo { get; set; }
        public string PhotoAsString { get; set; }
        public string CarID { get; set; }
    }
}
