using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CRUDOperations.Models
{
    public class UsersViewModel
    {
        public Int64 UserId { get; set; }
        [Required(ErrorMessage="Please Enter User Name")]
        [Display(Name="User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please Enter User Email")]
        [Display(Name = "User Email")]
        public string UserEmail { get; set; }
    }
}