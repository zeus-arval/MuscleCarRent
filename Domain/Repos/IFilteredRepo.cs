using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleCarRentProject.Domain.Repos
{
    public interface IFilteredRepo
    {
        public string CurrentFilter { get; set; }
        public string SearchString { get; set; }
    }
}
