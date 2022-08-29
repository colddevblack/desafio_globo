using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace APICard_Sports.Entidade
{
    public class CardModel
    {
        [Key]
        public int Id { get; set; }

        public string? Texto { get; set; }
        public DateTime? DataCriacao { get; set; }

        public DateTime? DataModificacao { get; set; }

        ////referencias outra model Tipo 
        //public int Tagid { get; set; }
        //public virtual TagModel TagM { get; set; }
       public ICollection<TagModel> Tags { get; set; }
    }
}
