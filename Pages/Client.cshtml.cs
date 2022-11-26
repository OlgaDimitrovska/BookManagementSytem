using BookManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookManagementSystem.Pages.Client
{
    public class ClientModel : PageModel
    {
        ClientDAL objclient = new ClientDAL();

        [BindProperty]
        public BookManagementSystem.Models.Client client { get; set; }

        public ActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            objclient.AddClient(client);

            return RedirectToPage("./ClientIndex");
        }
    }
}
