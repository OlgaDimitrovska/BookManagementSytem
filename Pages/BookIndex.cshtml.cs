using BookManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookManagementSystem.Pages.Books
{
    public class BookIndexModel : PageModel
    {
        BooksDAL objbook = new BooksDAL();
        public List<Book> book { get; set; }

        public void OnGet()
        {
            book = objbook.GetAllBooks().ToList();
        }
    }
}
