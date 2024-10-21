using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        [Required(ErrorMessage ="Payment on Booking is Required")]
        [DisplayName("Payment on Booking")]
        public int PaymentOnBooking { get; set; }


        [Required(ErrorMessage = "Possession Charges is Required")]
        [DisplayName("Possession Charges")]
        public int PossessionCharges { get; set; }


        [Required(ErrorMessage = "Total cost is Required")]
        [DisplayName("Total cost of Property")]
        public int TotalCostOfProperty { get; set; }

        [Required(ErrorMessage = "Payment Plan is Required")]
        [DisplayName("Payment Plan")]
        public PaymentPlan PaymentPlan { get; set; } //(Installlement/FullPaid)


        [Required(ErrorMessage = "Corner Charges is Required")]
        [DisplayName("Corner Charges")]
        public int CornerCharges { get; set; }


        [Required(ErrorMessage = "Development Charges is Required")]
        [DisplayName("Development Charges")]
        public int DevelopmentCharges { get; set; }

        [Required]
        public int Balance { get; set; }

        [Required]
        public string SoldDate { get; set; }

        [Required(ErrorMessage = "Possession Date is Required")]
        [DisplayName("Possession Date")]
        public string PossessionDate { get; set; }


        [Required(ErrorMessage = "Number of Installments is Required")]
        [DisplayName("Installments")]
        public int NumberOfInstallments { get; set; }
        [Required]
        public int EntryByUser { get; set; } //(Currently logged in user)
        [Required]
        public int CareOf { get; set; } 

    }
    public enum PaymentPlan
    {
        Installlement=1,
        FullPaid=2
    }
}
