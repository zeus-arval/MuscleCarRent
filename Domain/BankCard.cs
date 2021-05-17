using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MuscleCarRentProject.Data;
using MuscleCarRentProject.Domain.Common;

namespace Domain
{
    public class BankCard :BaseEntity<BankCardData>
    {
        public BankCard() : this(null) {}

        public BankCard(BankCardData b) : base(b)
        {

        }
    }
}
