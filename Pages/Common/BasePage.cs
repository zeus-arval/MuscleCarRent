using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Pages.Common
{
    public class BasePage : PageModel
    {
        public string NameSort { get; protected set; }
        public string DateSort { get; protected set; }
        public string CurrentFilter { get; protected set; }
        public string CurrentSort { get; protected set; }
        public virtual bool HasPreviousPage { get; set; }
        public virtual bool HasNextPage { get; set; }
        public virtual int? PageIndex { get; set; }
    }
}
