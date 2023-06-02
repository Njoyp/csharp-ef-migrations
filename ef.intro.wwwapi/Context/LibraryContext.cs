using ef.intro.wwwapi.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Runtime.CompilerServices;

namespace ef.intro.wwwapi.Context
{
    public class LibraryContext : DbContext
    {
        private static string GetConnectionString()
        {
            string jsonSettings = File.ReadAllText("appsettings.json");
            JObject configuration = JObject.Parse(jsonSettings);

            return configuration["ConnectionStrings"]["DefaultConnectionString"].ToString();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //optionsBuilder.UseInMemoryDatabase(databaseName: "Library");            
            optionsBuilder.UseNpgsql(GetConnectionString());
        }
         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
           .HasKey(m => new { m.Id });

        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        //TODO:  add publisher DbSet Property
        public DbSet<Publisher> Publishers { get; set; }
    }
}
