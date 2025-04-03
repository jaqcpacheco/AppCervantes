public class CadastroRepository

 {
     public void AdicionarCadastro(string nome, int numero)
     {
         using (var context = new AppDbContext())
         {
             var cadastro = new Cadastro {};
             context.Cadastros.Add(cadastro);
             context.SaveChanges();
         }
     }
 
     public List<Cadastro> ListarCadastros()
     {
         using (var context = new AppDbContext())
         {
             return context.Cadastros.ToList();
         }
     }
 
     public void AtualizarCadastro(int id, string nome, int numero)
     {
         using (var context = new AppDbContext())
         {
             var cadastro = context.Cadastros.Find(id);
             if (cadastro != null)
             {
                 cadastro.Nome = nome;
                 cadastro.Numero = numero;
                 context.SaveChanges();
             }
         }
     }
 
     public void ExcluirCadastro(int id)
     {
         using (var context = new AppDbContext())
         {
             var cadastro = context.Cadastros.Find(id);
             if (cadastro != null)
             {
                 context.Cadastros.Remove(cadastro);
                 context.SaveChanges();
             }
         }
     }
 }