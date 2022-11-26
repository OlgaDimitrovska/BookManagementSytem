using BookManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookManagementSystem.Pages
{
    public class EditLendingModel : PageModel
    {
        LendingDAL objlend = new LendingDAL();

        [BindProperty]
        public Models.Lending lend { get; set; }

        public ActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            lend = objlend.GetLending(id);

            if (lend == null)
            {
                return NotFound();
            }
            return Page();
        }

        public ActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            objlend.UpdateLending(lend);

            return RedirectToPage("./LendingIndex");
        }
    }
}
