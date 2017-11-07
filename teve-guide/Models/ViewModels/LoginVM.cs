using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace teve_guide.Models.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Du måste fylla i ditt användarnamn")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Du måste fylla i ditt lösenord")]

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}