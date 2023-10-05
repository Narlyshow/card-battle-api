using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardBattle.Domain.Models
{
    [Table("players")]
    public class Players
    {
        public Players()
        {
        }

        public Players(string nome_de_usuario, string senha, string email, string nome_do_personagem)
        {
            this.nome_de_usuario = nome_de_usuario;
            this.senha = senha;
            this.email = email;
            this.nome_do_personagem = nome_do_personagem;
        }


        [Key]
        public int id { get; set; }
        public string nome_de_usuario { get; set; }
        public string senha { get; set; }
        public string email { get; set; }
        public string nome_do_personagem { get; set; }

    
    }
}
