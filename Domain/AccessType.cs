﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Repos;
using MuscleCarRentProject.Data;
using MuscleCarRentProject.Domain.Common;

namespace Domain
{
    public sealed class AccessType : BaseEntity<AccessTypeData>
    {
        public AccessType() : this(null){}

        public AccessType(AccessTypeData a) : base(a)
        {
            accounts = getLazy<Account, IAccountsRepo>(a => a.GetByAccessTypeId(Id));
        }
        public AccessLevelEnum AccessLevel => Data?.AccessLevel ?? AccessLevelEnum.User;

        public Lazy<ICollection<Account>> accounts { get; }
        public ICollection<Account> Accounts => accounts.Value;
    }
}
