using System;
using System.ComponentModel.DataAnnotations;

namespace events.register.api.Models
{
    public class ParticipanteEvento
    {
        [Required(ErrorMessage ="Nome � obrigat�rio")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "Data de nascimento � obrigat�ria")]
        [DataType(DataType.Date)]
        public string Nascimento { get; set; }
        
        [Required(ErrorMessage = "Cpf � obrigat�rio")]
        [DisplayFormat(DataFormatString = "{0:000\\.000\\.000-00}", ApplyFormatInEditMode = true)]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "E-mail � obrigat�rio")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail inv�lido.")]
        [EmailAddress(ErrorMessage = "E-mail inv�lido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Cidade � obrigat�rio")]
        public string Cidade { get; set; }
    }
}
