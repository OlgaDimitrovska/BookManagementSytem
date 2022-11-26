using BookManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookManagementSystem.Pages
{
    public class DeleteLibraryModel : PageModel
    {
        LibraryDAL objlib = new LibraryDAL();

        public BookManagementSystem.Models.Library lib { get; set; }

        public ActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            lib = objlib.GetLibraryData(id);

            if (lib == null)
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

            objlib.DeleteLibrary(id);

            return RedirectToPage("./LibraryIndex");
        }
    }
}
