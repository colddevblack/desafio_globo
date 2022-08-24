
using APICard_Sports.Context;
using APICard_Sports.Entidade;
using Microsoft.AspNetCore.Mvc;
//using System.Management.Automation.PowerShell;

namespace APICard_Sports.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DataBaseIncialController : ControllerBase
    {
        //efetuar as migrations antes de executar Migrations Entity
      

        public ILogger<CardController> _logger;
        public DataContext db;

        public DataBaseIncialController(DataContext conect, ILogger<CardController> logger)
        {
            db = conect;
            _logger = logger;
        }

        //POST api/DataBaseIncial/CriarBancoCadastroInicial
        [HttpPost]
        public string CriarBancoCadastroCardTeste()
        {
            // arranje  
            var cli = new CardModel()
            {
                Texto = "Teste",
                DataCriacao = DateTime.Now,
                DataModificacao = DateTime.Now, 
            };

            var obj = db.Cardcontentdb.Add(cli);

            db.SaveChanges();
            return "Cadastro efetuado no banco" + cli;
        }

     
    }
}