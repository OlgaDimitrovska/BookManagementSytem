using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookManagementSystem.Models
{
    public class BookCopies
    {
        public Int64 id { get; set; }
        //public virtual Book Book { get; set; }
        public Int64 NumberOfCopies { get; set; }
        //public virtual Library library { get; set; }
        public Int64 FK_Library { get; set; }
        public Int64 FK_Book { get; set; }
        public List<SelectListItem> sliListLibraries { get; set; }

        public List<SelectListItem> sliListBooks { get; set; }
        public BookCopies()
        {

            sliListLibraries = new List<SelectListItem>();

            LibraryDAL libraryDAL = new LibraryDAL();
            foreach (var library in libraryDAL.GetAllLibraries())
            {
                sliListLibraries.Add(new SelectListItem(library.Name, library.id.ToString()));
            }

            sliListBooks = new List<SelectListItem>();

            BooksDAL booksDAL = new BooksDAL();
            foreach (var book in booksDAL.GetAllBooks())
            {
                sliListBooks.Add(new SelectListItem(book.Title, book.id.ToString()));
            }


        }

    }
}
