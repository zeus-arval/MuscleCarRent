using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MuscleCarRentProject.Domain;
using MuscleCarRentProject.Domain.Repos;

namespace MuscleCarRentProject.Domain.Repos
{
    public interface ICarsRepo : IRepo<Car>
    {
        List<Car> GetByCarTypeID(string ID);
    }
}
