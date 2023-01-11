using System.ComponentModel.DataAnnotations;

namespace RunSocial.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public int? Velocidade { get; set; }
        public int? Quilometragem { get; set; }

        public Endereco? Endereco { get; set; }
        public ICollection<Clube> Clubes { get; set; }
        public ICollection<Corrida> Corridas { get; set; }
    }
}
