using Microsoft.AspNetCore.Mvc;
using System.Net;
using APICard_Sports.Context;
using APICard_Sports.Entidade;
using Microsoft.EntityFrameworkCore;

namespace APICard_Sports.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        
        public DataContext db;

        public TagController(DataContext conect)
        {
            db = conect;
            
        }

        //POST api/TagController/CriaTag
        [HttpPost]
        public HttpStatusCode CriarTag(string name)
        {
         var model = new TagModel();

         model.Name = name;
         
         db.Tagcontentdb.Add(model);
         db.SaveChanges();
         
         return HttpStatusCode.Created;
        }
        // PUT api/TagController/EditarTag
        [HttpPut]
        public HttpStatusCode EditarTag(string name)
        {
         var card = (from u in db.Tagcontentdb where (name != null ? u.Name == name : 0 == 0) select u).Single();

            try
            {
                card.Name = name;
                db.Entry(card).State = EntityState.Modified;
                db.SaveChanges();
                return HttpStatusCode.Accepted;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // GET api/TagController/ListaTag

        [HttpGet]
        public List<TagModel> ListaTag()
        {
            try
            {
                return db.Tagcontentdb.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // GET api/TagController/BuscarTag

        [HttpGet]
        public TagModel BuscasTag(string nome)
        {
                try
                {
                // consulta linq
                var card = (from u in db.Tagcontentdb where (nome != null ? u.Name == nome : 0 == 0) select u).Single();

                return card;
                }
                catch (Exception ex)
                {
                throw  ex;
                } 
        }

        // DELETE: api/TagController/DeleteTag
        [HttpDelete]
        public HttpStatusCode DeleteTag(string nome)
        {
            try
            {
                // consulta linq
                var card = (from u in db.Tagcontentdb where (nome != null ? u.Name == nome : 0 == 0) select u).Single();
                int id = card.Id;
                var cli = db.Tagcontentdb.Find(id);
                db.Tagcontentdb.Remove(cli);
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


