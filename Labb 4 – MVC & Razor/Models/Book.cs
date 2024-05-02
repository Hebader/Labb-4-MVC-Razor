using System.ComponentModel.DataAnnotations;

namespace Labb_4___MVC___Razor.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
 
        [Required]
        public string BookTitle { get; set; }

        // Boolsk variabel som indikerar om boken är utlånad
        public bool IsBorrowed { get; set; }

        // Lista över kunder som har lånat boken
        public ICollection<BookCustomer> Borrowers { get; set; }
    }
}
