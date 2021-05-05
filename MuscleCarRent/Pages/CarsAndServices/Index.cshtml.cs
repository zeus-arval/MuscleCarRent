using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MuscleCarRent.Data;
using MuscleCarRentProject.Data;

namespace MuscleCarRent.Pages.CarsAndServices
{
    public class IndexModel : PageModel
    {
        private readonly MuscleCarRent.Data.MuscleCarRentDBContext _context;

        public IndexModel(MuscleCarRent.Data.MuscleCarRentDBContext context)
        {
            _context = context;
        }

        public IList<CarData> Car { get;set; }
        public IList<ImageData> Image { get; set; }

        public async Task OnGetAsync()
        {
            Car = await _context.Cars
                .Include(c => c.CarType)
                .Include(c => c.Images)
                .Include(c => c.Driver).ToListAsync();
        }
    }
}
