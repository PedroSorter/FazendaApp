using System.Linq;
using FazendaApp.Domain.Service;
using Microsoft.AspNetCore.Mvc;

namespace FazendaApp.WebApp.Controllers
{
  public class CategoriaOficialController : Controller
  {
    private readonly ICategoriaOficialService categoriaOficialService;

    public CategoriaOficialController(ICategoriaOficialService categoriaOficialService)
    {
      this.categoriaOficialService = categoriaOficialService;
    }
    // GET: CategoriaOficial
    [Route("categoriaoficial")]
    public ActionResult Index()
    {
      var lista = categoriaOficialService.GetAsync();

      return View(lista.Result.ToList());
    }

    // GET: CategoriaOficial/Details/5
    [Route("categoriaoficial/detalhes/{id}")]
    public ActionResult Detalhes(string ID)
    {
      var lista = categoriaOficialService.GetAsync();

      var categoria = lista.Result.FirstOrDefault(a => a.ID == ID);
      return View(categoria);
    }
  }
}