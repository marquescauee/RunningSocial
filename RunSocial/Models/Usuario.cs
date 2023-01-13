using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RunSocial.Models
{
    public class Usuario : IdentityUser
    {
        public int? Velocidade { get; set; }
        public int? Quilometragem { get; set; }

        [ForeignKey("Endereco")]
        public int? EnderecoId { get; set; }
        public Endereco? Endereco { get; set; }
        public ICollection<Clube> Clubes { get; set; }
        public ICollection<Corrida> Corridas { get; set; }
    }
}
