using BookManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookManagementSystem.Pages
{
    public class DeleteLendingModel : PageModel
    {
        LendingDAL objlending = new LendingDAL();

        public Models.Lending lend { get; set; }

        public ActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            lend = objlending.GetLending(id);

            if (lend == null)
            {
                return NotFound();
            }
            return Page();
        }

        public ActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            objlending.DeleteLending(id);

            return RedirectToPage("./LendingIndex");
        }
    }
}
