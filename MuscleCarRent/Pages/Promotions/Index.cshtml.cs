using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MuscleCarRent.Data;
using MuscleCarRentProject.Data;

namespace MuscleCarRent.Pages.Promotions
{
    public class IndexModel : PageModel
    {
        private readonly MuscleCarRent.Data.MuscleCarRentDBContext _context;

        public IndexModel(MuscleCarRent.Data.MuscleCarRentDBContext context)
        {
            _context = context;
        }

        public IList<PromotionData> Promotion { get;set; }

        public async Task OnGetAsync()
        {
            Promotion = await _context.Promotions
                .Include(p => p.Account)
                .Include(p => p.Car).ToListAsync();
        }
    }
}
