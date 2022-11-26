using BookManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookManagementSystem.Pages.BookCopies
{
    public class DeleteBookCopiesModel : PageModel
    {
        BookCopiesDAL bookCopiesDAL = new BookCopiesDAL();

        public BookManagementSystem.Models.BookCopies bookcp { get; set; }

        public ActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            bookcp = bookCopiesDAL.GetBookCopies(id);

            if (bookcp == null)
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

            bookCopiesDAL.DeleteBookCopies(id);

            return RedirectToPage("./BookCopiesIndex");
        }
    }
}
