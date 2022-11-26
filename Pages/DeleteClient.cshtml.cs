using BookManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookManagementSystem.Pages.Client
{
    public class DeleteClientModel : PageModel
    {
        ClientDAL objclient = new ClientDAL();

        public BookManagementSystem.Models.Client client { get; set; }

        public ActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            client = objclient.GetClientDataID(id);

            if (client == null)
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

            objclient.DeleteClient(id);

            return RedirectToPage("./ClientIndex");
        }
    }
}
