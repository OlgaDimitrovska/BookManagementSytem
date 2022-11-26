using BookManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookManagementSystem.Pages.Books
{
    public class BookDetailsModel : PageModel
    {
        BooksDAL objbook = new BooksDAL();
        public Book book { get; set; }

        public ActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            book = objbook.GetBookData(id);

            if (book == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
