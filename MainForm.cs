using System;
using System.Windows.Forms;

public class MainForm : Form 
{
    private Button btnAdicionar, btnListar;
    private CadastroRepository repository = new CadastroRepository();

    public MainForm()
    {
        btnAdicionar = new Button { Text = "Adicionar Cadastro", Left = 10, Top = 10, Width = 150 };
        btnListar = new Button { Text = "Listar Cadastros", Left = 10, Top = 50, Width = 150 };

        btnAdicionar.Click += (sender, e) => new CadastroForm().ShowDialog();
        btnListar.Click += (sender, e) => ListarCadastros();

        Controls.Add(btnAdicionar);
        Controls.Add(btnListar);
    }
    private void ListarCadastros()
    {
        var lista = repository.ListarCadastros();
        string mensagem = string.Join("\n", lista.Select(c => $"{c.Id} - {c.Nome} - {c.Numero}"));
        MessageBox.Show(mensagem, "Lista de Cadastros");
    }

}