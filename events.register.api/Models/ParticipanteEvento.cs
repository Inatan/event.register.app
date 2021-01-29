using events.register.api.Attributes;
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
        [DataMaiorIdade(ErrorMessage = "Somente maiores de idade podem se cadastrar")]
        public DateTime Nascimento { get; set; }
        
        [Required(ErrorMessage = "Cpf � obrigat�rio")]
        [CpfFormat(ErrorMessage = "Cpf inv�lido")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "E-mail � obrigat�rio")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail inv�lido.")]
        [EmailAddress(ErrorMessage = "E-mail inv�lido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Cidade � obrigat�rio")]
        public string Cidade { get; set; }
    }
}
