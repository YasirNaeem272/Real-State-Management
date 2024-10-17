using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using RSM.BOL.Models;

namespace RSM.BOL.Models
{
    public class Property
    {
        [Key]
        public int ID { get; set; } // Primary Key
        [Required]
        public string PlotNo { get; set; }
        [Required]
        public string ProjectName { get; set; }
        [Required]
        public string Block { get; set; }
        [NotMapped]
        public Size Sizes { get; set; }
        [Required]
        public string Size { get; set; }
        [NotMapped]
        public PropertType PropertyTypes { get; set; }
        [Required]
        public string PropertyType { get; set; }
        [Required]
        public string North { get; set; }
        [Required]
        public string East { get; set; }
        [Required]
        public string West { get; set; }
        [Required]
        public string South { get; set; }
        [Required]
        public int StreetNo { get; set; }
        public int OwnerID { get; set; } //Foreign Key

        // Navigation Property
        [ForeignKey("OwnerID")]
        public virtual Owner Owner { get; set; }  // Ensure this property exists
        [NotMapped]
        public Status Statuses  { get; set; }
        [Required]
        public string Status { get; set; }

    }
    public enum Size
    {
        Small=1,
        Medium=2,
        Large=3,
        LargeSmall=4,
    }
    public enum PropertType
    {
        Residencial=1, Commercial=2, SemiCommercial=3,
    }
    public enum Status
    {
        Sold=1, Reserved=2, Available=3,
    }
}