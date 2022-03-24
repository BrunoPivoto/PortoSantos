using Microsoft.EntityFrameworkCore;
using Porto.Domain.Entities;
using Porto.Infra.Mapping;

namespace Porto.Infra.Context{
    public class PortoContext : DbContext{
        public PortoContext(){ }
        public PortoContext(DbContextOptions<PortoContext> options) : base(options){ }
        public virtual DbSet<Container> Containers {get ; set; }
        public virtual DbSet<Movement> Movements {get ; set; }


        //ALETERE PARA SUA STRING DE CONEXÃO PARA PODER FAZER A MIGRAÇÃO AQUI E NO APPSETTINGS.JSON
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=PORTOAPI; User Id=PC-BRUNO\\bruno; Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder builder){
            builder.ApplyConfiguration(new ContainerMap());
        }
    }
}