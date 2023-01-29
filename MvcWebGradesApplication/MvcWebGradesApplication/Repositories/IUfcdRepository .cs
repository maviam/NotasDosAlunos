using MvcWebGradesApplication.Models;

namespace MvcWebGradesApplication.Repositories
{
    public interface IUfcdRepository
    {
        public List<UfcdModel> Listar();
        public UfcdModel ProcurarPorCodigo(int codigo);
        public UfcdModel Inserir(UfcdModel ufcd);
        public void Atualizar(UfcdModel ufcd);
        public bool Eliminar(int codigo);
    }
}
