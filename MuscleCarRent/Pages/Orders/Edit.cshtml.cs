using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MuscleCarRent.Data;
using MuscleCarRentProject.Data;

namespace MuscleCarRent.Pages.Orders
{
    public class EditModel : PageModel
    {
        private readonly MuscleCarRent.Data.MuscleCarRentDBContext _context;

        public EditModel(MuscleCarRent.Data.MuscleCarRentDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public OrderData Order { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Order = await _context.Orders
                .Include(o => o.Account)
                .Include(o => o.Car).FirstOrDefaultAsync(m => m.ID == id);

            if (Order == null)
            {
                return NotFound();
            }
           ViewData["AccountID"] = new SelectList(_context.Accounts, "ID", "Email");
           ViewData["CarID"] = new SelectList(_context.Cars, "ID", "Color");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(Order.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.ID == id);
        }
    }
}
