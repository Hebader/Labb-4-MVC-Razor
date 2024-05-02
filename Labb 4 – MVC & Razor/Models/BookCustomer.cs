using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb_4___MVC___Razor.Models
{
    public class BookCustomer
    {
        [Key]
        public int BookCustomerId { get; set; }

        [ForeignKey("Customer")]
        public int FkCustomerId { get; set; }
        public Customer Customer { get; set; }

        [ForeignKey("Book")]
        public int FkBookId { get; set; }
        public Book Book { get; set; }
    }
}
