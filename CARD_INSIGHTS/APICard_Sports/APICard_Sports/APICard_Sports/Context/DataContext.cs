
using APICard_Sports.Entidade;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace APICard_Sports.Context
{
    public class DataContext : DbContext
    {
            public DataContext(DbContextOptions<DataContext> options) : base(options)
            {
            }
            public DbSet<CardModel>? Cardcontentdb { get; set; }
            public DbSet<TagModel>? Tagcontentdb { get; set; }
            public DbSet<CardTagModel> CardTagDb { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
            modelBuilder.Entity<CardTagModel>().HasKey(sc => new { sc.TagId, sc.CardId });

            modelBuilder.Entity<CardTagModel>()
                .HasOne<CardModel>(sc => sc.CardModelRef)
                .WithMany(s => s.cardstags)
                .HasForeignKey(sc => sc.CardId);


            modelBuilder.Entity<CardTagModel>()
                .HasOne<TagModel>(sc => sc.TagModelRef)
                .WithMany(s => s.cardstags)
                .HasForeignKey(sc => sc.TagId);
        }
        }
    }