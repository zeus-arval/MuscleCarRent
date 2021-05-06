using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MuscleCarRent.Data;
using MuscleCarRentProject.Data;

namespace MuscleCarRent.Pages.OrderDates
{
    public class DeleteModel : PageModel
    {
        private readonly MuscleCarRent.Data.MuscleCarRentDBContext _context;

        public DeleteModel(MuscleCarRent.Data.MuscleCarRentDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public OrderedDateData OrderedDate { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            OrderedDate = await _context.OrderedDates
                .Include(o => o.Car).FirstOrDefaultAsync(m => m.ID == id);

            if (OrderedDate == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            OrderedDate = await _context.OrderedDates.FindAsync(id);

            if (OrderedDate != null)
            {
                _context.OrderedDates.Remove(OrderedDate);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
