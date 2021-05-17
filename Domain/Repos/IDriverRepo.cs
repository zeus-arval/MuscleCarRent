using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MuscleCarRentProject.Domain.Repos;

namespace Domain.Repos
{
    public interface IDriverRepo : IRepo<Driver>
    {
        List<Driver> GetByCar(string id);
    }
}
