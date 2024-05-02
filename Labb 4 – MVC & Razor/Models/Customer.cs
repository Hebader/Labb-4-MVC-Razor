using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Labb_4___MVC___Razor.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
      
        [Required]
        [DisplayName("Customer Name")]
        [StringLength(50, MinimumLength = 10)]

        public string CustomerName { get; set; }
     
        [Required]
        [EmailAddress]

        public string Email { get; set; }
       
        [Required]
        [Phone]

        public string PhoneNumber { get; set; }

        public ICollection<BookCustomer>? BorrowedBooks { get; set; }
    }
}
