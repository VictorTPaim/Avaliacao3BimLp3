using AvaliacaoLP3Bi3.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AvaliacaoLP3Bi3.Controllers;

public class LojaController : Controller
{
    private static List<LojaViewModel> lojas = new List<LojaViewModel>
    {
        new LojaViewModel(1, "Piso 3", "ToPets", "Peruca para Animais", "Loja", "topets@email.com"),
        new LojaViewModel(2, "Piso 2", "Milk Shakespere", "De livro à sorvete", "Quiosque", "milkshakespere@email.com"),
        new LojaViewModel(3, "Piso 1", "Perucas Cabeludas", "Uma loja para te deixar de cabelo em pé", "Loja", "perucascabeludas@email.com")
    };

    public IActionResult Index()
    {
        return View(lojas);
    }
    public IActionResult Show(int id)
    {
        return View(lojas[id - 1]);
    }
    public IActionResult Admin()
    {
        return View(lojas);
    }

    public IActionResult Cadastrar()
    {
        return View();
    }

    public IActionResult ExcluirLoja(int id)
    {
        lojas.RemoveAt(id - 1);

        for(int i = id; i < lojas.Count; i++)
        {
            lojas[i].Id = id - 1;
        }

        return RedirectToAction("LojaExcluida");
    }
    public IActionResult LojaExcluida()
    {
        return View();
    }

    public IActionResult CadastrarLoja(int id, string piso, string nome, string descricao, string tipo,  string email)
    {
        foreach(var loja in lojas)
        {
            if(nome == loja.Nome)
            {
                return RedirectToAction("NomeIndisponivel");
            }
        }
            id = 1 + lojas.Count;
            lojas.Add(new LojaViewModel(id, piso, nome, descricao, tipo, email));
            
            return RedirectToAction("Admin");
    }

    public IActionResult NomeIndisponivel()
    {
        return View();
    }
}