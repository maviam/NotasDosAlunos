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
                return RedirectToAction(nameof(Index));
            }

            TempData["MensagemDeCancelamento"] = "Erro na inserção do formando! Tente navamente";
            return RedirectToAction(nameof(Index));

        }
    }
}
