using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TrialProject.Entities;

namespace TrialProjectEntities
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        public string Item { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int Total { get; set; }
        public int PId { get; set; }
        [ForeignKey("PId")]
        public Product product { get; set; }
        public int UId { get; set; }

        public virtual User user { get; set; }
    }
}
