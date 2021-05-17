using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MuscleCarRentProject.Domain.Repos;

namespace Domain.Repos
{
    public interface IOrderedDateRepo : IRepo<OrderedDate>
    {
        ICollection<OrderedDate> GetByCarID(string id);
    }
}
