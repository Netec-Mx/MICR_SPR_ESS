using Microsoft.EntityFrameworkCore;
using MVCMonolitico.Models.Entities;

namespace MVCMonolitico.Models.Data
{
    public class AppDBContext:DbContext
    {
        public AppDBContext() { }
        public AppDBContext(DbContextOptions<AppDBContext> dbContextOptions):
            base(dbContextOptions){ }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName:"data");
        }

        /*Se registran las entidades*/
        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }

        /*Se configura el modelo*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*Se configuran los autoincrement*/
            modelBuilder.Entity<User>().Property(t => t.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Item>().Property(t => t.Id)
                .ValueGeneratedOnAdd();

            base.OnModelCreating(modelBuilder);
        }




    }
}
