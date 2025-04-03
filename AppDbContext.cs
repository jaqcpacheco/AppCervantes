using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Cadastro> Cadastros { get; set; }
    public DbSet<LogOperacao> LogOperacoes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    optionsBuilder.UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=Jaque10.;");
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuração da chave estrangeira
        modelBuilder.Entity<LogOperacao>()
            .HasOne(lo => lo.Cadastro)
            .WithMany()
            .HasForeignKey(lo => lo.CadastroId);

        base.OnModelCreating(modelBuilder);
    }
}
