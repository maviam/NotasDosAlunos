using MvcWebGradesApplication.Models;

namespace MvcWebGradesApplication.Repositories
{
    public interface IFormadorRepository
    {
        public List<FormadorModel> Listar();
        public FormadorModel ProcurarPorNif(long nif);
        public FormadorModel Inserir(FormadorModel formador);
        public void Atualizar(FormadorModel formador);
        public bool Eliminar(long nif);
    }
}
