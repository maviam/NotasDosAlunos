using MvcWebGradesApplication.Models;

namespace MvcWebGradesApplication.Repositories
{
    public interface IFormandoRepository
    {
        public List<FormandoModel> Listar();
        public FormandoModel Inserir(FormandoModel formando);
    }
}
