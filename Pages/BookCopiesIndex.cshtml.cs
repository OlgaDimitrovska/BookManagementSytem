using BookManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookManagementSystem.Pages.BookCopies
{
    public class BookCopiesIndexModel : PageModel
    {
        BookCopiesDAL bookCopiesDAL = new BookCopiesDAL();
        public List<BookManagementSystem.Models.BookCopies> bookcpy { get; set; }

        public void OnGet()
        {
            bookcpy = bookCopiesDAL.GetAllBookCopies().ToList();
        }
    }
}
