using ElectronicJournal.DTO.ModelsDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicJournal.ViewModels
{
    public class RegisterModel : LoginModel
    {
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль введен неверно")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Role { get; set; }
        public HumanAddDto Human {get;set ; }
    }
}
