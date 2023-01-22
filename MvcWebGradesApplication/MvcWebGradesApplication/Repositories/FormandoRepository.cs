using Microsoft.EntityFrameworkCore;
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

        public List<FormandoModel> Listar()
        {
            return _dataContext.Formandos.OrderBy(f => f.Nome).ToList();
        }

        public FormandoModel ProcurarPorId(int id)
        {
            return _dataContext.Formandos.First(f => f.Id == id);
        }

        public FormandoModel Inserir(FormandoModel formando)
        {
            _dataContext.Formandos.Add(formando);
            _dataContext.SaveChanges();
            return formando;
        }

        public void Atualizar(FormandoModel formando)
        {
            bool existeFormando = _dataContext.Formandos.Any(f => f.Id == formando.Id);

            if (!existeFormando)
            {
                throw new Exception("Id não encontrado");
            }
            var formandoBD = ProcurarPorId(formando.Id);
            
            if (formandoBD == null) 
            {
                throw new Exception("Erro na atualização dos dados do formando!");
            }

            formandoBD.Nome = formando.Nome;
            formandoBD.Email = formando.Email;
            formandoBD.DataNascimento = formando.DataNascimento;
            formandoBD.Telemovel= formando.Telemovel;
            formandoBD.Sexo= formando.Sexo;

            _dataContext.Formandos.Update(formandoBD);
            _dataContext.SaveChanges();
        }

        public bool Eliminar(int id)
        {
            var formandoBD = ProcurarPorId(id);

            if (formandoBD == null)
            {
                throw new Exception("Erro na eliminação dos dados do formando!");
            }

            _dataContext.Formandos.Remove(formandoBD);
            _dataContext.SaveChanges();

            return true;
        }

       

       
    }
}
