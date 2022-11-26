using BookManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookManagementSystem.Pages.Client
{
    public class ClientDetailsModel : PageModel
    {
        ClientDAL objclient = new ClientDAL();
        public  BookManagementSystem.Models.Client client { get; set; }

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
    }
}
