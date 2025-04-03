public class Cadastro
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public int Numero { get; set; }
    public DateTime DataCriacao { get; set; } = DateTime.UtcNow;  
}
