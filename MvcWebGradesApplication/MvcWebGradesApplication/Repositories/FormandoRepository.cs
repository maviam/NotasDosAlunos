using MvcWebGradesApplication.Data;
using MvcWebGradesApplication.Models;

namespace MvcWebGradesApplication.Repositories
{
    public class FormandoRepository : IFormandoRepository
    {
        private readonly DataContext _dataContext;
        public FormandoRepository(DataContext dataContext) 
        {
            _dataContext = dataContext;
        }

        public FormandoModel Inserir(FormandoModel formando)
        {
            _dataContext.Formandos.Add(formando);
            _dataContext.SaveChanges();
            return formando;
        }

        public List<FormandoModel> Listar()
        {
            return _dataContext.Formandos.OrderBy(f => f.Nome).ToList();
        }
    }
}
