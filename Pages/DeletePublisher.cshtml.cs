using BookManagementSystem.Models;
using BookManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookManagementSystem.Pages.Publisher
{
    public class DeletePublisherModel : PageModel
    {
        PublisherDAL objpub = new PublisherDAL();

        public BookManagementSystem.Models.Publisher pub { get; set; }

        public ActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            pub = objpub.GetPublisherID(id);

            if (pub == null)
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

            objpub.DeletePublisher(id);

            return RedirectToPage("./PublisherIndex");
        }
    }
}
