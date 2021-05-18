using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MuscleCarRentProject.Domain.Repos;

namespace Domain.Repos
{
    public interface IOrdersRepo : IRepo<Order>
    {
        ICollection<Order> GetByCarID(string ID);
        ICollection<Order> GetByAccountID(string ID);
    }
}
