
using APICard_Sports.Entidade;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace APICard_Sports.Context
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
            {
            }
            public DbSet<CardModel>? Cardcontentdb { get; set; }
            public DbSet<TagModel>? Tagcontentdb { get; set; }
            //public DbSet<CardTagModel> CardTagDb { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
            {


            
        }
        }
    }