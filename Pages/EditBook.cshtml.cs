using BookManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookManagementSystem.Pages
{
    public class EditBookModel : PageModel
    {
        BooksDAL objbook = new BooksDAL();

        [BindProperty]
        
        public Book book { get; set; }

        public EditBookModel()
        {
            this.book = new Book();
        }

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

        public ActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            objbook.UpdateBook(book);

            return RedirectToPage("./Index");
        }
    }
}
