﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MuscleCarRentProject.Domain.Repos;

namespace Domain.Repos
{
    public interface IOrderedDatesRepo : IRepo<OrderedDate>
    {
        ICollection<OrderedDate> GetByCarId(string id);
    }
}
