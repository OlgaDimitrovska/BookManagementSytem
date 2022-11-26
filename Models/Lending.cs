using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BookManagementSystem.Models
{
    public class Lending
    {
        public Int64 Id { get; set; }
        public string DatumZajmuvanje { get; set; }
        public string? DatumVratena { get; set; }
        public Int64 FK_Client { get; set; }
        public Int64 FK_Book { get; set; }

        public List<SelectListItem> sliListClients { get; set; }

        public List<SelectListItem> sliListBooks { get; set; }
        public Lending()
        {

            sliListClients = new List<SelectListItem>();

            ClientDAL clientDAL = new ClientDAL();
            foreach (var client in clientDAL.GetAllClients())
            {
                sliListClients.Add(new SelectListItem(client.Name, client.id.ToString()));
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
