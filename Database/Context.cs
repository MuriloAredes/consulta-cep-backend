using consultaCep_backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace consultaCep_backend.Database
{
    public class Context : DbContext
    {
        public virtual DbSet<EnderecoEntite>? Enderecos { get; set; }
        public Context(DbContextOptions<Context> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<EnderecoEntite>();

            base.OnModelCreating(builder);
        }
    }
}
