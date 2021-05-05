using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MuscleCarRent.Data;
using MuscleCarRentProject.Data;

namespace MuscleCarRent.Pages.CarsAndServices
{
    public class CreateModel : PageModel
    {
        private readonly MuscleCarRent.Data.MuscleCarRentDBContext _context;

        public CreateModel(MuscleCarRent.Data.MuscleCarRentDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CarTypeID"] = new SelectList(_context.Set<CarTypeData>(), "ID", "ID");
        ViewData["DriverID"] = new SelectList(_context.Set<DriverData>(), "ID", "ID");
            return Page();
        }

        [BindProperty]
        public CarData Car { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Cars.Add(Car);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
