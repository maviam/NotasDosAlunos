using MvcWebGradesApplication.Models;

namespace MvcWebGradesApplication.Repositories
{
    public interface IFormandoRepository
    {
        public List<FormandoModel> Listar();
        public FormandoModel ProcurarPorId(int id);
        public FormandoModel Inserir(FormandoModel formando);
        public void Atualizar(FormandoModel formando);
        public bool Eliminar(int id);
    }
}
