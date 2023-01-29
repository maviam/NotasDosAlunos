using Microsoft.AspNetCore.Mvc;
using MvcWebGradesApplication.Models;
using MvcWebGradesApplication.Models.ViewModels;
using MvcWebGradesApplication.Repositories;

namespace MvcWebGradesApplication.Controllers
{
    public class UfcdsController : Controller
    {
        private readonly IUfcdRepository _ufcdRepository;
        private readonly IFormadorRepository _formadorRepository;
        public UfcdsController(IUfcdRepository ufcdRepository, IFormadorRepository formadorRepository) 
        { 
            _ufcdRepository= ufcdRepository;
            _formadorRepository= formadorRepository;
        }
        public IActionResult Index()
        {
            var listaDeUfcds = _ufcdRepository.Listar();
            return View(listaDeUfcds);
        }

        public IActionResult Add()
        {
            var formadores = _formadorRepository.Listar();
            var viewModel = new UfcdFormsViewModel { Formadores = formadores };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(UfcdModel ufcd)
        {
            if (ufcd != null)
            {
                TempData["MensagemDeSucesso"] = "Ufcd inserida com sucesso!";
                _ufcdRepository.Inserir(ufcd);
            }
            else
            {
                TempData["MensagemDeCancelamento"] = "Erro na inserção dos dados da ufcd! Tente navamente";
            }

			return RedirectToAction(nameof(Index));
		}

        public IActionResult Edit(int? codigo)
        {
            if (codigo == null)
            {
                throw new Exception("Código da ufcd não encontrado");
            }

			var ufcd = _ufcdRepository.ProcurarPorCodigo(codigo.Value);
			var formadores = _formadorRepository.Listar();
			var viewModel = new UfcdFormsViewModel { Ufcd = ufcd, Formadores = formadores };
            
            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UfcdModel ufcd)
        {
            if (ufcd != null)
            {
                TempData["MensagemDeSucesso"] = "Dados da ufcd atualizados com sucesso!";
                _ufcdRepository.Atualizar(ufcd);
            }
            else
            {
                TempData["MensagemDeCancelamento"] = "Erro na atualização dos dados da ufcd! Tente navamente";
            }
            
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int? codigo)
        {
			if (codigo == null)
			{
				return NotFound();
			}

			var ufcd = _ufcdRepository.ProcurarPorCodigo(codigo.Value);

			if (codigo == null)
			{
				return NotFound();
			}

			return View(ufcd);
		}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int codigo)
        {   
            if (_ufcdRepository.Eliminar(codigo))
            {
                TempData["MensagemDeSucesso"] = "Ufcd removida com sucesso!";
            }
            else
            {
                TempData["MensagemDeCancelamento"] = "Erro ao eliminar a ufcd! Tente navamente";
            }
            
            return RedirectToAction(nameof(Index));
        }
    }
}
