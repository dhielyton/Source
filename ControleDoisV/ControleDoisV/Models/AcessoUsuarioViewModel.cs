using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDoisV.Models
{
    public class AcessoUsuarioViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Display(Name = "Lembrar de Mim")]
        public bool LembrarDeMim { get; set; }
    }
}
