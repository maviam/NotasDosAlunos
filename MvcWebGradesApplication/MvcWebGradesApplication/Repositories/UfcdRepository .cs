using Microsoft.EntityFrameworkCore;
using MvcWebGradesApplication.Data;
using MvcWebGradesApplication.Models;
using MvcWebGradesApplication.Models.Enums;

namespace MvcWebGradesApplication.Repositories
{
    public class UfcdRepository : IUfcdRepository
    {
        private readonly DataContext _dataContext;
        public UfcdRepository(DataContext dataContext) 
        {
            _dataContext = dataContext;
        }

        public List<UfcdModel> Listar()
        {
            return _dataContext.Ufcds.OrderBy(uf => uf.Denominacao).ToList();
        }

        public UfcdModel ProcurarPorCodigo(int codigo)
        {
            return _dataContext.Ufcds.Where(uf => uf.Codigo == codigo).First();
        }

        public UfcdModel Inserir(UfcdModel ufcd)
        {
            _dataContext.Ufcds.Add(ufcd);
            _dataContext.SaveChanges();
            return ufcd;
        }

        public void Atualizar(UfcdModel ufcd)
        {
            bool existeUfcd = _dataContext.Ufcds.Any(uf => uf.Codigo == ufcd.Codigo);

            if (!existeUfcd)
            {
                throw new Exception("Código da ufcd não encontrado");
            }
            var ufcdBD = ProcurarPorCodigo(ufcd.Codigo);
            
            if (ufcdBD == null) 
            {
                throw new Exception("Erro na atualização da informação sobre a ufcd!");
            }

            ufcdBD.Codigo = ufcd.Codigo;
            ufcdBD.Denominacao = ufcd.Denominacao;
            ufcdBD.Duracao = ufcd.Duracao;
            ufcdBD.Componente = ufcd.Componente;
            ufcd.Formador= ufcd.Formador;

            _dataContext.Ufcds.Update(ufcdBD);
            _dataContext.SaveChanges();
        }

        public bool Eliminar(int codigo)
        {
            var ufcdBD = ProcurarPorCodigo(codigo);

            if (ufcdBD == null)
            {
                throw new Exception("Erro na eliminação dos dados da ufcd!");
            }

            _dataContext.Ufcds.Remove(ufcdBD);
            _dataContext.SaveChanges();

            return true;
        }
    }
}
