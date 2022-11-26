using BookManagementSystem.Models;
using BookManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookManagementSystem.Pages.Client
{
    public class EditClientModel : PageModel
    {
        ClientDAL objdal = new ClientDAL();

        [BindProperty]
        public BookManagementSystem.Models.Client client { get; set; }

        public ActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            client = objdal.GetClientDataID(id);

            if (client == null)
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
            objdal.UpdateClient(client);

            return RedirectToPage("./ClientIndex");
        }
    }
}
