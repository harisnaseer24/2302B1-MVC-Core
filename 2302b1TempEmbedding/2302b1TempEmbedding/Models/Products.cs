using System.ComponentModel.DataAnnotations;

namespace _2302b1TempEmbedding.Models
{
    public class Products
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string pname { get; set; }

        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$")]
        public string description { get; set; }
        [Required]
        public int price { get; set; }

    }
}
