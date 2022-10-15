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
    public class RegisterDetailsVM
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(200)]
        public string Email { get; set; }

        public DateTime CreateTime { get; set; }
    }

    public  static class RegisterAssember
    {
        public static Register VM2Entity(this RegisterVM source)
        {
            return new Register {Name= source.Name, Email=source.Email};
        }
        public static RegisterDetailsVM Entity2DetailsVM(this Register source)
        {
            return new RegisterDetailsVM {Id=source.Id,
                Name = source.Name,
                Email = source.Email,
                CreateTime=source.CreateTime
            };
        }
        public static List<RegisterDetailsVM> Entity2DetailsVM(this IEnumerable<Register> source)
        {
            if (source == null || source.Count() == 0)
            {
                return Enumerable.Empty<RegisterDetailsVM>().ToList();
            }
            return source.Select(x=>x.Entity2DetailsVM()).ToList();
        }

    }
}