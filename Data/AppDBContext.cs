using Microsoft.EntityFrameworkCore;
using ms_controle_financeiro.Model.Entities;

namespace ms_controle_financeiro.Data
{
    public class AppDBContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Balance> Balances { get; set; }
        public virtual DbSet<Input> Inputs { get; set; }
        public virtual DbSet<Output> Outputs { get; set; }
        public virtual DbSet<Log> Logs { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Input>()
            .HasOne(input => input.User)
            .WithMany(user => user.Inputs)
            .HasForeignKey(input => input.UserId);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Output>()
            .HasOne(output => output.User)
            .WithMany(user => user.Outputs)
            .HasForeignKey(output => output.UserId);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Balance>()
            .HasOne(balance => balance.User)
            .WithOne(user => user.Balances)
            .HasForeignKey<Balance>(balance => balance.UserId);
        }

    }
}