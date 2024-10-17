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
        public string Onbooking { get; set; }
        public int PossessionCharges { get; set; }
        public int TotalCostOfLand { get; set; }
        public string Type { get; set; } //(Installlement/FullPaid)
        public int CornerCharges { get; set; }
        public int DevelopmentCharges { get; set; }
        public int Balance { get; set; }
        public DateTime Date { get; set; }
        public string PossessionDate { get; set; }
        public int TotalInsMonth { get; set; }
        public int Recived { get; set; } //(Which User)
        public string CareOf { get; set; } 

    }
}
