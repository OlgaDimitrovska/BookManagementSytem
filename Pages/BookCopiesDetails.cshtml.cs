using BookManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookManagementSystem.Pages.BookCopies
{
    public class BookCopiesDetailsModel : PageModel
    {
        BookCopiesDAL bookCopiesDAL = new BookCopiesDAL();
        public BookManagementSystem.Models.BookCopies book { get; set; }

        public ActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            book = bookCopiesDAL.GetBookCopies(id);

            if (book == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
