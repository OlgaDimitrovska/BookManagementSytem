using BookManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookManagementSystem.Pages
{
    public class BookCopiesModel : PageModel
    {
        BookCopiesDAL bookCopiesDAL = new BookCopiesDAL();

        [BindProperty]
        public BookManagementSystem.Models.BookCopies bookcpy { get; set; }

        

        public BookCopiesModel()
        {
            this.bookcpy = new BookManagementSystem.Models.BookCopies();
        }

        public ActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            bookCopiesDAL.AddBookCopies(bookcpy);

            return RedirectToPage("./BookCopiesIndex");
        }
    }
}