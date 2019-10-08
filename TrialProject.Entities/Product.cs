using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TrialProjectEntities
{
   public class Product
    {
        [Key]
        public int PId { get; set; }
        public string PName { get; set; }
        public int PPrice { get; set; }
        public int Quantity { get; set; }

        public string PImage { get; set; }

        [ForeignKey("Category")]
        public int CId { get; set; }
        public virtual Category Category { get; set; }


    }
}
