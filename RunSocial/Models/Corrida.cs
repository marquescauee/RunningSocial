using RunSocial.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RunSocial.Models
{
    public class Corrida
    {
        [Key]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string? Imagem { get; set; }

        [ForeignKey("Address")]
        public int EnderecoId { get; set; }
        public Endereco Endereco { get; set; }
        public CategoriaCorrida CategoriaCorrida { get; set; }

        [ForeignKey("User")]
        public int? UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
    }
}
