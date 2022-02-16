using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class AppointmentModel
    {
        [Required]
        [StringLength(20, MinimumLength = 4)]
        [DisplayName("Patient's Full Name")]
        public string PatientName { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Appointment Request Date")]
        public DateTime AppointmentTime { get; set; }

        [Range(90000, double.PositiveInfinity)]
        [DataType(DataType.Currency)]
        [DisplayName("Patient's Approximate Net Worth")]
        public decimal PatientNetWorth { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 4)] 
        [DisplayName("Primary Doctor's Last Name")]
        public string DoctorName { get; set; }

        [Range(5, 10)]
        [DisplayName("Patient's Persieved Level of Pain (1 low to 10 high)")]
        public int PainLevel { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        [DisplayName("Patient's Occupation Street Name")]
        public string Street{ get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        [DisplayName("Patient's Occupation City Name")]
        public string City { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Patient's E-Mail Address")]
        public string Email{ get; set; }

        [DataType(DataType.PhoneNumber)]
        [DisplayName("Patient's Phone Number")]
        public int PhoneNumber { get; set; }
    }
}
