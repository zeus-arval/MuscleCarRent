using Core;
using Facade;

namespace MuscleCarRentProject.Facade.Common
{
    public abstract class BaseView : UniqueItem, IBaseEntityView
    {
        public byte[] RowVersion { get; set; }
    }
}
