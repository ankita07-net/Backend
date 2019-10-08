using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TrialProject.Entities;

namespace TrialProjectEntities
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }
        public string Email { get; set; }
        public int HouseNo { get; set; }
        public string Address1 { get; set; }
        public int PinCode { get; set; }
        public string city { get; set; }
        public string State { get; set; }
        public int UId { get; set; }
        public virtual User User { get; set; }
        
       
    }
}
