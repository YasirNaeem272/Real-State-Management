using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSM.BOL.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        [Required(ErrorMessage = "RoleName is Required")]
        public string  RoleName { get; set; }
    }
}
