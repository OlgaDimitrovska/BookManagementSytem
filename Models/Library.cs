using System.ComponentModel.DataAnnotations;

namespace BookManagementSystem.Models
{
    public class Library
    {
        public Int64 id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }


    }
}
