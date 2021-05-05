using System;
using System.ComponentModel.DataAnnotations;
using Data.Common;

namespace MuscleCarRentProject.Data
{
    public abstract class PersonData : BaseData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
