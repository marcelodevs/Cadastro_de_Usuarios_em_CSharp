using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome obrigatório!")]
        public required string Nome { get; set; }
        [Required(ErrorMessage = "E-mail obrigatório!")]
        [EmailAddress(ErrorMessage = "E-mail inválido!")]
        public required string Email { get; set; }
        [Required(ErrorMessage = "Contato obrigatório!")]
        [Phone(ErrorMessage = "Celular inválido!")]
        public required string Contato { get; set; }
    }
}
