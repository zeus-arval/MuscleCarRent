using System;
using System.Collections.Generic;
using System.Text;
using MuscleCarRentProject.Core;

namespace Core
{
    public interface IPersonInfoEntityData : IEntityData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
    }
}
