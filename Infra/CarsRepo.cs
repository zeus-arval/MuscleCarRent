using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MuscleCarRentProject.Data;
using MuscleCarRentProject.Domain;
using MuscleCarRentProject.Domain.Repos;

namespace Infra
{
    public sealed class CarsRepo : PagedRepo<Car, CarData>, ICarsRepo
    {
    }
}
