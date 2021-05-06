using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MuscleCarRent.Data;
using MuscleCarRentProject.Data;
using Pages.Common;

namespace MuscleCarRent.Pages.Accounts
{
    public class AccountModel : BasePage
    {
        private readonly MuscleCarRentDBContext _context;

        public AccountModel(MuscleCarRentDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public AccountData Account { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Accounts.Add(Account);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
