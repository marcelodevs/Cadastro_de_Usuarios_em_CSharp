using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRespositorio;
        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRespositorio = contatoRepositorio;
        }
        public IActionResult Index()
        {
            List<ContatoModel> contatos = _contatoRespositorio.BuscarTodos();
            return View(contatos);
        }
        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar(int id)
        {
            ContatoModel contato = _contatoRespositorio.ListarId(id);
            return View(contato);
        }
        public IActionResult ApagarConfirm(int id)
        {
            ContatoModel contato = _contatoRespositorio.ListarId(id);
            return View(contato);
        }
        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _contatoRespositorio.Apagar(id);
                if (apagado) TempData["MsgSucess"] = "Usuário apagado com sucesso!";
                else TempData["MsgError"] = "Não foi possível apagar o usuário!";
                return RedirectToAction("Index");
            } catch (System.Exception error)
            {
                TempData["MsgError"] = error.Message;
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult Criar(ContatoModel c)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRespositorio.Adicionar(c);
                    TempData["MsgSucess"] = "Usuário cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(c);
            } catch (System.Exception error)
            {
                TempData["MsgError"] = error.Message;
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult Alterar(ContatoModel c)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRespositorio.Atualizar(c);
                    TempData["MsgSucess"] = "Usuário alterado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View("Editar", c);
            } catch (System.Exception error)
            {
                TempData["MsgError"] = error.Message;
                return RedirectToAction("Index");
            }
        }
    }
}
