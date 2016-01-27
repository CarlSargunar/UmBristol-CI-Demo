using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmBristol.CI.Library.ViewModels
{
    public class ContactFormViewModel
    {
        public ContactFormViewModel()
        {

        }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "This is a required field")]
        [StringLength(40, ErrorMessage = "This field cannot be longer than 40 characters")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "This is a required field")]
        [StringLength(80, ErrorMessage = "This field cannot be longer than 80 characters")]
        public string LastName { get; set; }

        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Required(ErrorMessage = "This is a required field")]
        [StringLength(80, ErrorMessage = "This field cannot be longer than 80 characters")]
        public string Email { get; set; }

        [Display(Name = "Comments")]
        [Required(ErrorMessage = "This is a required field")]
        [StringLength(500, ErrorMessage = "This field cannot be longer than 500 characters")]
        public string Comments { get; set; }

        [Display(Name = "Marketing Opt In")]
        public bool MarketingOptIn { get; set; }
    }
}
