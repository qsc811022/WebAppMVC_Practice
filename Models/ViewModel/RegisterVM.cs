using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

using WebAppMVC.Models.EFModel;

namespace WebAppMVC.Models.ViewModel
{
    public class RegisterVM
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(200)]
        public string Email { get; set; }

    }
    public  static class RegisterAssember
    {
        public static Register VM2Entity(this RegisterVM source)
        {
            return new Register {Name= source.Name, Email=source.Email};
        }
    }
}