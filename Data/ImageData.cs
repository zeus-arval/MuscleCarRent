using Data.Common;
using Microsoft.AspNetCore.Http;

namespace MuscleCarRentProject.Data
{
    public sealed class ImageData : BaseData
    {
        public byte[] Image { get; set; }
        public string CarId { get; set; }
    }
}
