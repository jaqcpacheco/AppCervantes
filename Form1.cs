using System;
 using System.Windows.Forms;
 
 public class Form1 : Form
{
    private TextBox txtNome, txtNumero;
    private Button btnSalvar;
 
    public Form1()
    {
        this.Text = "Cadastro";
        this.Width = 400;
        this.Height = 300;
 
        Label lblNome = new Label { Text = "Nome:", Left = 20, Top = 20, Width = 100 };
        txtNome = new TextBox { Left = 120, Top = 20, Width = 200 };
 
        Label lblNumero = new Label { Text = "Número:", Left = 20, Top = 60, Width = 100 };
        txtNumero = new TextBox { Left = 120, Top = 60, Width = 200 };
 
        btnSalvar = new Button { Text = "Salvar", Left = 120, Top = 100, Width = 100 };
        btnSalvar.Click += (sender, e) => SalvarCadastro();
 
        Controls.Add(lblNome);
        Controls.Add(txtNome);
        Controls.Add(lblNumero);
        Controls.Add(txtNumero);
        Controls.Add(btnSalvar);
    }
 
    private void SalvarCadastro()
    {
        try
        {
            using (var db = new AppDbContext())
            {
            string nome = txtNome.Text;
            if (!int.TryParse(txtNumero.Text, out int numero))
            {
                MessageBox.Show("Número inválido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var cadastro = new Cadastro { Nome = nome, Numero = numero };
            db.Cadastros.Add(cadastro);
            db.SaveChanges();  

            
            var log = new LogOperacao
            {
                Operacao = "Novo cadastro",
                CadastroId = cadastro.Id  
            };
            db.LogOperacoes.Add(log);
            db.SaveChanges();

            MessageBox.Show("Cadastro salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        }
        catch (Exception ex)
        {
        MessageBox.Show("Erro ao salvar: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}