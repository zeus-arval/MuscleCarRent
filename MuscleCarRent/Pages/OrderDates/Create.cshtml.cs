using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MuscleCarRent.Data;
using MuscleCarRent.Models;

namespace MuscleCarRent.Pages.OrderDates
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
        ViewData["CarID"] = new SelectList(_context.Cars, "ID", "Color");
            return Page();
        }

        [BindProperty]
        public OrderedDate OrderedDate { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.OrderedDates.Add(OrderedDate);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
