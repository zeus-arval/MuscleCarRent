using System;
using System.Collections.Generic;
using System.Text;

namespace MuscleCarRentProject.Core
{
    public interface IEntityData : IBaseEntity
    {
        public new string Id { get; set; }
        public new byte[] RowVersion { get; set; }
    }
}
