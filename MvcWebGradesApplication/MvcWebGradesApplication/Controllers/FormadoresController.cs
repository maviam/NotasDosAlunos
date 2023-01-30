using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcWebGradesApplication.Models;
using MvcWebGradesApplication.Repositories;

namespace MvcWebGradesApplication.Controllers
{
    public class FormadoresController : Controller
    {
        private readonly IFormadorRepository _formadorRepository;
        public FormadoresController(IFormadorRepository formadorRepository) 
        { 
            _formadorRepository= formadorRepository;
        }
        public IActionResult Index()
        {
            var listaDeFormadores = _formadorRepository.Listar();
            return View(listaDeFormadores);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(FormadorModel formador)
        {
			if (!ModelState.IsValid)
			{

                return View(formador);
			}

			if (formador != null)
            {
                TempData["MensagemDeSucesso"] = "Formador inserido com sucesso!";
                _formadorRepository.Inserir(formador);
            }
            else
            {
                TempData["MensagemDeCancelamento"] = "Erro na inserção do formador! Tente navamente";
            }
            
			return RedirectToAction(nameof(Index));
		}

        public IActionResult Edit(long? nif)
        {
            if (nif == null)
            {
                throw new Exception("Nif não encontrado");
            }

            var formador = _formadorRepository.ProcurarPorNif(nif.Value);
            
            if (formador == null)
            {
                return NotFound();
            }

            return View(formador);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(FormadorModel formador)
        {
            if (formador != null)
            {
                TempData["MensagemDeSucesso"] = "Dados do formador atualizados com sucesso!";
                _formadorRepository.Atualizar(formador);
            }
            else
            {
                TempData["MensagemDeCancelamento"] = "Erro na atualização dos dados do formador! Tente navamente";
            }
            
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(long? nif)
        {
			if (nif == null)
			{
				return NotFound();
			}

			var formador = _formadorRepository.ProcurarPorNif(nif.Value);

			if (formador == null)
			{
				return NotFound();
			}

			return View(formador);
		}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(long nif)
        {   
            if (_formadorRepository.Eliminar(nif))
            {
                TempData["MensagemDeSucesso"] = "Formador removido com sucesso!";
            }
            else
            {
                TempData["MensagemDeCancelamento"] = "Erro ao remover o formador! Tente navamente";
            }
            
            return RedirectToAction(nameof(Index));
        }
    }
}
