using System.ComponentModel.DataAnnotations;

namespace RestaurantManagement.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        [Required]
        [StringLength(100)]
        public string CustomerName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(255)]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
