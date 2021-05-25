using MuscleCarRentProject.Domain.Repos;
using System.Collections.Generic;

namespace Domain.Repos
{
    public interface IPromotionRepo :IRepo<Promotion> {
        ICollection<Promotion> GetByAccountId(string Id);
        ICollection<Promotion> GetByCarId(string Id);
    }
}
