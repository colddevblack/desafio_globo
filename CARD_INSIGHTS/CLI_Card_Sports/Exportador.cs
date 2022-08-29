using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APICard_Sports.Context;
using APICard_Sports.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using APICard_Sports.Controllers;

namespace CLI_Card_Sports
{
    public class Exportador
    {
        public DataContext db;

        public Exportador(DataContext conect)
        {
            db = conect;

        }
        public void Export()
        {

            
            string linha = "";
            string[] linhaseparada = null;
            StreamReader reader = new StreamReader(@"C:\Users\Cold\Desktop\DOTNET\Card_Insights\CLI_Card_Sports\CSV\cards.csv", Encoding.UTF8, true);
            while (true)
            {
                linha = reader.ReadLine();
                if (linha == null) break;
                linhaseparada = linha.Split(';');
                string resultado = string.Format(
                @"Linha - 
                    Campo 1: {0}
                    Campo 2: {1}", linhaseparada[0], linhaseparada[1]);
                Console.WriteLine(resultado);

                //var tagm = new TagModel()
                //{
                //    Name = linhaseparada[1],
                //};
                //var listtag = new List<TagModel>();
                //listtag.Add(tagm);
                //var modelcard = new CardModel()
                //{
                //    Texto = linhaseparada[0],
                //    Tags = listtag,
                //    DataCriacao = DateTime.Now,
                //    DataModificacao = DateTime.Now,

                //};

                //db.Cardcontentdb?.Add(modelcard);
                //db.SaveChanges();
                //db.Tagcontentdb?.Add(tagm);
                //db.SaveChanges();
                
                var createcontrol = new CardController(db);
                createcontrol.CriarCard(linhaseparada[0], linhaseparada[1]);
            }
            
        }
    }
}
