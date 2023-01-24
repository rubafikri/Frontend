using System.ComponentModel.DataAnnotations;

namespace BookStore.API.Models
{
    public class Sales
    {
        public int Id { get; set; }
        public string AppUserId { get; set; } 
        public AppUser AppUser { get; set; }
        public int BookId { get; set; }
        public Books Book { get; set; }
        public decimal Amount { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime OrderDate { get; set; } 
        public decimal TotalPrice { get; set; }
        public IsSoldStatus IsSold { get; set; } = 0;

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime SoldDate { get; set; }
    }

    public enum IsSoldStatus
    {
        ok = 1,
        notOk = 0
    }
}
