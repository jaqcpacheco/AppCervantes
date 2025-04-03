public class LogOperacao
{
    public int Id { get; set; }
    public string? Operacao { get; set; }
    public DateTime DataOperacao { get; set; } = DateTime.UtcNow;

    public int CadastroId { get; set; }
    public Cadastro? Cadastro { get; set; } 
}