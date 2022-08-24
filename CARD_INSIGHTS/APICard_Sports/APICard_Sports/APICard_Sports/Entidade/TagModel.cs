using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace APICard_Sports.Entidade
{
    public class TagModel
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        //public int CardId { get; set; }
        //public virtual CardModel CardM { get; set; }
        public List<CardTagModel>? cardstags { get; set; }
    }
}
