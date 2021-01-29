using events.register.api.Attributes;
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
        [DataMaiorIdade(ErrorMessage = "Somente maiores de idade podem se cadastrar")]
        public DateTime Nascimento { get; set; }
        
        [Required(ErrorMessage = "Cpf é obrigatório")]
        [CpfFormat(ErrorMessage = "Cpf inválido")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "E-mail é obrigatório")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail inválido.")]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Cidade é obrigatório")]
        public string Cidade { get; set; }
    }
}
