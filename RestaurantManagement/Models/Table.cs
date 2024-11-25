using System.ComponentModel.DataAnnotations;

namespace RestaurantManagement.Models
{
    public class Table
    {
        [Key]
        public int TableID { get; set; }

        [Required]
        [StringLength(100)] // Reduced length, as table numbers are typically short
        public string TableNumber { get; set; }

        [Required]
        [StringLength(100)] // Assuming a table can seat between 1 and 20 people
        public string TableCapacity { get; set; }
    }
}

