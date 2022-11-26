using BookManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookManagementSystem.Pages.BookCopies
{
    public class EditBookCopiesModel : PageModel
    {
        BookCopiesDAL objbook = new BookCopiesDAL();

        [BindProperty]
        public BookManagementSystem.Models.BookCopies book { get; set; }

        public ActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            book = objbook.GetBookCopies(id);

            if (book == null)
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
            objbook.UpdateBookCopies(book);

            return RedirectToPage("./BookCopiesIndex");
        }
    }
}
