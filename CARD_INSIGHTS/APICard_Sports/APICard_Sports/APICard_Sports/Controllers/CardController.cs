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
        public HttpStatusCode CriarCard(string text, string? tag)
        {
            var tagm = new TagModel();
            var model = new CardModel()
            {
                Texto = text,
                Tags = null,
                DataCriacao = DateTime.Now,
                DataModificacao = DateTime.Now,
            };
            if (tag != null)
            {

                tagm.Name = tag;
                db.Tagcontentdb.Add(tagm);
                db.SaveChanges();

            }
            if (tag != null)
            {
                var searchtag = (from u in db.Tagcontentdb where (tag != null ? u.Name == tag : 0 == 0) select u).Single();
                var listtag = new List<TagModel>();
                listtag.Add(searchtag);
                model.Tags = listtag;
                db.Cardcontentdb.Add(model);
                db.SaveChanges();
            }
            db.Cardcontentdb.Add(model);
            db.SaveChanges();

            //model.cardstags.Add(taglist[0]);



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


