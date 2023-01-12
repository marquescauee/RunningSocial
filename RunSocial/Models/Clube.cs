using RunSocial.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RunSocial.Models
{
    public class Clube
    {
        [Key]
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public string? Imagem { get; set; }

        [ForeignKey("Endereco")]
        public int? EnderecoId { get; set; }
        public Endereco? Endereco { get; set; }

        public CategoriaClube CategoriaClube { get; set; }

        [ForeignKey("Usuario")]
        public string? UsuarioId { get; set; }
        public Usuario? Usuario { get; set;}
         
    }
}
