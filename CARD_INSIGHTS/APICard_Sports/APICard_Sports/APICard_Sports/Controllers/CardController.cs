using Microsoft.AspNetCore.Mvc;
using System.Net;
using APICard_Sports.Context;
using APICard_Sports.Entidade;
using Microsoft.EntityFrameworkCore;
using APICard_Sports.Controllers;

namespace APICard_Sports.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        
        public DataContext db;

        public CardController(DataContext conect)
        {
            db = conect;
            
        }

        //POST api/CardController/CriaCard
        [HttpPost]
        public HttpStatusCode CriarCard(string text, string tag)
        {

         var taglist = new List<CardTagModel>();
         var model = new CardModel();
         model.Texto = text;
         model.DataCriacao = DateTime.Now;
         model.DataModificacao = DateTime.Now;
         //var tagcriar = new TagModel();
            
         //   tagcriar.Name = tag;
         //   taglist[0].TagModelRef.Name = tag;    
         //   db.Tagcontentdb.Add(tagcriar);
            

            db.SaveChanges();

            //model.cardstags.Add(taglist[0]);

            db.Cardcontentdb.Add(model);
         db.SaveChanges();
         
         return HttpStatusCode.Created;
        }
        // PUT api/CardController/EditarCard
        [HttpPut]
        public HttpStatusCode EditarCard(string text)
        {
            var card = (from u in db.Cardcontentdb where (text != null ? u.Texto == text : 0 == 0) select u).Single();

            try
            {
               
                    card.Texto = text;
                    card.DataModificacao = DateTime.Now;
                    //card.DataCriacao = card.DataCriacao;
                    db.Entry(card).State = EntityState.Modified;
                    db.SaveChanges();
                    return HttpStatusCode.Accepted;
               
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // GET api/CardController/ListaCard

        [HttpGet]
        public List<CardModel> ListaCard()
        {
            try
            {
             return db.Cardcontentdb.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        // GET api/CardController/BuscarCard

        [HttpGet]
        public CardModel BuscasCard(string text)
        {
                try
                {
                // consulta linq
                var card = (from u in db.Cardcontentdb where text == null || u.Texto == text select u).Single();

                    return card;
                }
                catch (Exception ex)
                {
                    throw  ex;
                } 
        }



        // DELETE: api/CardController/DeleteCard
        
        [HttpDelete]
        public HttpStatusCode DeleteCard(string text)
        {
            try
            {
                // consulta linq
                var card = (from u in db.Cardcontentdb where text == null || u.Texto == text select u).Single();
                int id = card.Id;
                var cli = db.Cardcontentdb.Find(id);
                db.Cardcontentdb.Remove(cli);
                db.SaveChanges();
                return HttpStatusCode.Accepted;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }

}


