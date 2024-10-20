using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSM.BOL.Models
{
    public class PropertySell
    {
        [Key]
        public int ID { get; set; }
        public int PropertyID  { get; set; } //FK
        [ForeignKey("PropertyID")]
        public virtual Property Property { get; set; }
        [Required]
        public string Onbooking { get; set; }
        [Required]
        public int PossessionCharges { get; set; }
        [Required]
        public int TotalCostOfLand { get; set; }
        [Required]
        public string Type { get; set; } //(Installlement/FullPaid)
        [NotMapped]
        public Type Types { get; set; } //(Installlement/FullPaid)
        [Required]
        public int CornerCharges { get; set; }
        [Required]
        public int DevelopmentCharges { get; set; }
        [Required]
        public int Balance { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public string PossessionDate { get; set; }
        [Required]
        public int TotalInsMonth { get; set; }
        [Required]
        public int Recived { get; set; } //(Which User)
        [Required]
        public string CareOf { get; set; } 

    }
    public enum Type
    {
        Installlement=1,
        
        FullPaid=2
    }
}
