using BookManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookManagementSystem.Pages
{
    public class DeleteBookModel : PageModel
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

        public ActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            objbook.DeleteBook(id);

            return RedirectToPage("./BookIndex");
        }
    }
}
