using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MuscleCarRent.Data;
using MuscleCarRent.Models;

namespace MuscleCarRent.Pages.CarsAndServices
{
    public class CreateModel : PageModel
    {
        private readonly MuscleCarRent.Data.MuscleCarDBContext _context;

        public CreateModel(MuscleCarRent.Data.MuscleCarDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CarTypeID"] = new SelectList(_context.Set<CarType>(), "ID", "ID");
        ViewData["DriverID"] = new SelectList(_context.Set<Driver>(), "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Car Car { get; set; }

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
