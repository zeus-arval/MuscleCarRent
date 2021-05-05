using System;
using System.ComponentModel.DataAnnotations;
using Core;
using MuscleCarRentProject.Core;

namespace Data.Common
{
    public class BaseData : UniqueItem, IEntityData
    {
        [Timestamp] public byte[] RowVersion { get; set; }
    }
}
