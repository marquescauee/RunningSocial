using System.ComponentModel.DataAnnotations;

namespace RunSocial.Models
{
    public class Endereco
    {
        [Key]
        public int Id { get; set; }
        public string Rua { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        

    }
}
