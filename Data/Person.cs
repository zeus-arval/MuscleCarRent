using System;
using System.ComponentModel.DataAnnotations;

namespace MuscleCarRentProject.Data
{
    public abstract class Person
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
