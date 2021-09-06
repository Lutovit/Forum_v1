using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ForumAPI_with_Angular.Models
{
    public class UserTranferObject
    {
        public string Id { set; get; }

        public string ClientName { set; get; }

        public string CompanyName { set; get; }

        public string Email { set; get; }

        public string DateOfRegistration { set; get; }

        public bool isBanned { set; get; }

        public bool isDelited { set; get; }
    }




    public class RegisterTranferObject
    {
        [Required]
        [Display(Name = "Ваше имя")]
        public string ClientName { get; set; }

        [Display(Name = "Компания (не обязательно)")]
        public string CompanyName { get; set; }


        [Required]
        [EmailAddress]
        [Display(Name = "Адрес электронной почты")]
        public string Email { get; set; }


        [Required]
        [StringLength(100, ErrorMessage = "Значение {0} должно содержать не менее {2} символов.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }


        [DataType(DataType.Password)]
        [Display(Name = "Подтверждение пароля")]
        [Compare("Password", ErrorMessage = "Пароль и его подтверждение не совпадают.")]
        public string ConfirmPassword { get; set; }
    }
}
