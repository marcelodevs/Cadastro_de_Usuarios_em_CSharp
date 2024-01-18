using ControleDeContatos.Data;
using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _bancoContext;

        public ContatoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public ContatoModel ListarId(int id)
        {
            return _bancoContext.Contatos.FirstOrDefault(x => x.Id == id); // pega o primeiro
        }
        public List<ContatoModel> BuscarTodos()
        {
            return [.. _bancoContext.Contatos]; // carrega tudo do banco de dados
        }
        public ContatoModel Adicionar(ContatoModel contato)
        {
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();
            return contato;
        }
        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDB = ListarId(contato.Id) ?? throw new Exception("Houve um erro ao atualizar o contato.");
            contatoDB.Nome = contato.Nome;
            contatoDB.Email = contato.Email;
            contatoDB.Contato = contato.Contato;

            _bancoContext.Contatos.Update(contatoDB);
            _bancoContext.SaveChanges();
            return contatoDB;
        }
        public bool Apagar(int id)
        {
            ContatoModel contatoDB = ListarId(id) ?? throw new System.Exception("Houve um erro ao deletar o contato."); // verifica se eh nulo

            _bancoContext.Contatos.Remove(contatoDB);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}
