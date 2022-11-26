using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookManagementSystem.Models
{
    public class Book
    {
        public Int64 id { get; set; }
        public string Title { get; set; }
        public string YearOfIssue { get; set; }
        public Int64 NumberOfPages { get; set; }
        public Int64 FK_Publisher { get; set; }
        public List<SelectListItem> sliListPublishers { get; set; }

        public Book (){

            sliListPublishers = new List<SelectListItem> ();

           PublisherDAL publisherDAL = new PublisherDAL();
            foreach (var publisher in publisherDAL.GetAllPublishers())
            {
                sliListPublishers.Add(new SelectListItem(publisher.Name, publisher.Id.ToString()));
            }
        }

        //public virtual Publisher Publisher { get; set; }
    }
}
