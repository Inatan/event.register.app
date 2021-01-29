using System;
using System.ComponentModel.DataAnnotations;

namespace events.register.api.Models
{
    public class ParticipanteEvento
    {
        [Required(ErrorMessage ="Nome é obrigatório")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "Data de nascimento é obrigatória")]
        [DataType(DataType.Date)]
        public string Nascimento { get; set; }
        
        [Required(ErrorMessage = "Cpf é obrigatório")]
        [DisplayFormat(DataFormatString = "{0:000\\.000\\.000-00}", ApplyFormatInEditMode = true)]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "E-mail é obrigatório")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail inválido.")]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Cidade é obrigatório")]
        public string Cidade { get; set; }
    }
}
