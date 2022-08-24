using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace APICard_Sports.Entidade
{
    public class CardTagModel
    {
        
        public int CardId { get; set; }
        public CardModel? CardModelRef { get; set; }

        public int TagId { get; set; }
        public TagModel? TagModelRef { get; set; }
    }
}
