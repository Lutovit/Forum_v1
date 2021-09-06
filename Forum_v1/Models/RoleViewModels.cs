using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Forum_v1.Models
{
    public class CreateRoleModel
    {
        [Required]
        [Display(Name = "Имя роли")]
        public string Name { get; set; }
    }


    public class EditRoleModel
    {
        public string Id { get; set; }

        [Display(Name = "Наименование роли:")]
        [Required]
        public string Name { get; set; }
    }

}
