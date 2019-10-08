using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TrialProjectEntities
{
    public class Category
    {
        [Key]
        public int CId { get; set; }
        public string CName { get; set; }
        public string CDetails { get; set; }
      
      public virtual ICollection<Product> Product { get; set; }

    }
}
