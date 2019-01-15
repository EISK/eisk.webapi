using System.ComponentModel.DataAnnotations;

namespace Eisk.Domains.Employee.Models.ValueObjects
{
    public class Address
    {
        [StringLength(60)]
        //[Required(ErrorMessage = "Address line required.")]
        [Display(Name = "Address line")]
        public string AddressLine { get; set; }

        [StringLength(15)]
        public string City { get; set; }

        [StringLength(15)]
        public string Region { get; set; }

        [StringLength(10)]
        [RegularExpression("\\d{1,10}", ErrorMessage = "Not a valid postal code. Please consider upto 10 digit for valid phone format.")]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        //[Required(ErrorMessage = "Country required.")]
        [StringLength(15)]
        public string Country { get; set; }
                
    }
}