using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSM.BOL.Models
{
    public class Owner
    {
        [Key] // Primary Key
        public int OwnerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CNIC { get; set; }
        public string CellNo { get; set; }
        //public int OwnerIdTest {  get; set; }
    }

}

