using BookManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookManagementSystem.Pages.Client
{
    public class ClientIndexModel : PageModel
    {
        ClientDAL objclient = new ClientDAL();
        public List<BookManagementSystem.Models.Client> clients { get; set; }

        public void OnGet()
        {
            clients = objclient.GetAllClients().ToList();
        }
    }
}
