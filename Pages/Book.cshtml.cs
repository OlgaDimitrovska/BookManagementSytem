using BookManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Runtime.CompilerServices;

namespace BookManagementSystem.Pages
{
    public class BookModel : PageModel
    {
        BooksDAL objBook = new BooksDAL();

        [BindProperty]
        public Book book { get; set; }

        public BookModel()
        {
            this.book = new Book();
        }

        public ActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            objBook.AddBook(book);

            return RedirectToPage("./BookIndex");
        }
    }
}