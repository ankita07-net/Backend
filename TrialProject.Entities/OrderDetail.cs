using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TrialProjectEntities
{
   public class OrderDetail
    {
        [Key]
        public int OrderId { get; set; }
        public int OrederPrice { get; set; }
        public int Quantity { get; set; }
    }
}
