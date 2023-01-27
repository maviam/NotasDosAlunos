using Microsoft.AspNetCore.Mvc;
using MvcWebGradesApplication.Models;
using MvcWebGradesApplication.Repositories;

namespace MvcWebGradesApplication.Controllers
{
    public class FormandosController : Controller
    {
        private readonly IFormandoRepository _formandoRepository;
        public FormandosController(IFormandoRepository formandoRepository) 
        { 
            _formandoRepository= formandoRepository;
        }
        public IActionResult Index()
        {
            var listaDeFormandos = _formandoRepository.Listar();
            return View(listaDeFormandos);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(FormandoModel formando)
        {
            if (formando != null)
            {
                TempData["MensagemDeSucesso"] = "Formando inserido com sucesso!";
                _formandoRepository.Inserir(formando);
            }
            else
            {
                TempData["MensagemDeCancelamento"] = "Erro na inserção do formando! Tente navamente";
            }
            
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formando = _formandoRepository.ProcurarPorId(id.Value);
            
            if (formando == null)
            {
                return NotFound();
            }

            return View(formando);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(FormandoModel formando)
        {
            if (formando != null)
            {
                TempData["MensagemDeSucesso"] = "Dados do formando atualizados com sucesso!";
                _formandoRepository.Atualizar(formando);
            }
            else
            {
                TempData["MensagemDeCancelamento"] = "Erro na atualização dos dados do formando! Tente navamente";
            }
            
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
			if (id == null)
			{
				return NotFound();
			}

			var formando = _formandoRepository.ProcurarPorId(id.Value);

			if (formando == null)
			{
				return NotFound();
			}

			return View(formando);
		}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {   
            if (_formandoRepository.Eliminar(id))
            {
                TempData["MensagemDeSucesso"] = "Formando removido com sucesso!";
            }
            else
            {
                TempData["MensagemDeCancelamento"] = "Erro ao remover o formando! Tente navamente";
            }
            
            return RedirectToAction(nameof(Index));
        }
    }
}
