using Microsoft.EntityFrameworkCore;
using MvcWebGradesApplication.Data;
using MvcWebGradesApplication.Models;

namespace MvcWebGradesApplication.Repositories
{
    public class FormadorRepository : IFormadorRepository
    {
        private readonly DataContext _dataContext;
        public FormadorRepository(DataContext dataContext) 
        {
            _dataContext = dataContext;
        }

        public List<FormadorModel> Listar()
        {
            return _dataContext.Formadores.OrderBy(f => f.Nome).ToList();
        }

        public FormadorModel ProcurarPorNif(long nif)
        {
            return _dataContext.Formadores.Where(f => f.Nif == nif).First();
        }

        public FormadorModel Inserir(FormadorModel formador)
        {
            _dataContext.Formadores.Add(formador);
            _dataContext.SaveChanges();
            return formador;
        }

        public void Atualizar(FormadorModel formador)
        {
            bool existeFormador = _dataContext.Formadores.Any(f => f.Nif == formador.Nif);

            if (!existeFormador)
            {
                throw new Exception("Nif não encontrado");
            }
            var formadorBD = ProcurarPorNif(formador.Nif);
            
            if (formadorBD == null) 
            {
                throw new Exception("Erro na atualização dos dados do formador!");
            }

            formadorBD.Nif = formador.Nif;  
            formadorBD.Nome = formador.Nome;
            formadorBD.Email = formador.Email;
            formadorBD.Telemovel= formador.Telemovel;

            _dataContext.Formadores.Update(formadorBD);
            _dataContext.SaveChanges();
        }

        public bool Eliminar(long nif)
        {
            var formadorBD = ProcurarPorNif(nif);

            if (formadorBD == null)
            {
                throw new Exception("Erro na eliminação dos dados do formador!");
            }

            _dataContext.Formadores.Remove(formadorBD);
            _dataContext.SaveChanges();

            return true;
        }
    }
}
