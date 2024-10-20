using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RSM.BOL.Models
{
    public class Property
    {
        [Key]
        public int PropertyID { get; set; }

        [Required(ErrorMessage = "Plot No is required")]
        [DisplayName("Plot #")]
        public string PlotNo { get; set; }

        [Required]
        public string ProjectName { get; set; }
        [Required]
        public string Block { get; set; }
        [Required]
        public PropertySize Size { get; set; }
        [DisplayName("Property Type")]
        [Required(ErrorMessage = "Property Type is required")]
        public PropertyType PropertyType { get; set; }
        [Required]
        public string North { get; set; }
        [Required]
        public string East { get; set; }
        [Required]
        public string West { get; set; }
        [Required]
        public string South { get; set; }
        [DisplayName("Property Status")]
        [Required(ErrorMessage = "Property status is required")]
        public PropertyStatus PropertyStatus { get; set; }

        public int? OwnerId { get; set; }

        [ForeignKey("OwnerId")]
        public virtual Owner Owner { get; set; }


    }
}

public enum PropertyType
{
    Residential,
    Commercial,
    [Display(Name = "Semi-Commercial")]
    SemiCommercial
}
public enum PropertySize
{
    Small = 1,
    Medium = 2,
    Large = 3,
    LargeSmall = 4,
}
public enum PropertyStatus
{
    Sold,
    Available,
    Reserved
}
