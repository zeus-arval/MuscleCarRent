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

namespace MuscleCarRent.Pages.BankCards
{
    public class EditModel : PageModel
    {
        private readonly MuscleCarRent.Data.MuscleCarRentDBContext _context;

        public EditModel(MuscleCarRent.Data.MuscleCarRentDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BankCardData BankCard { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BankCard = await _context.BankCards
                .Include(b => b.Account).FirstOrDefaultAsync(m => m.ID == id);

            if (BankCard == null)
            {
                return NotFound();
            }
           ViewData["AccountID"] = new SelectList(_context.Accounts, "ID", "Email");
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

            _context.Attach(BankCard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BankCardExists(BankCard.ID))
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

        private bool BankCardExists(string id)
        {
            return _context.BankCards.Any(e => e.ID == id);
        }
    }
}
