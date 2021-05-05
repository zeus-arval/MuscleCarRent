using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MuscleCarRent.Data;
using MuscleCarRentProject.Data;

namespace MuscleCarRent.Pages.Drivers
{
    public class DetailsModel : PageModel
    {
        private readonly MuscleCarRent.Data.MuscleCarRentDBContext _context;

        public DetailsModel(MuscleCarRent.Data.MuscleCarRentDBContext context)
        {
            _context = context;
        }

        public DriverData Driver { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Driver = await _context.Drivers.FirstOrDefaultAsync(m => m.ID == id);

            if (Driver == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
