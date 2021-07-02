using Dominio.IRepositories;
using Historias.Imoveis;
using Imobiliaria_HomeOffice.Factories;
using Imobiliaria_HomeOffice.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Imobiliaria_HomeOffice.Controllers
{
    public class ImovelController : Controller
    {
        private readonly CriarImovel _criarImovel;
        private readonly AlterarImovel _alterarImovel;
        private readonly ExcluirImovel _excluirImovel;
        private readonly ConsultarImovel _consultarImovel;
        public ImovelController(IImovelRepository imovelRepository)
        {
            _criarImovel = new CriarImovel(imovelRepository);
            _alterarImovel = new AlterarImovel(imovelRepository);
            _excluirImovel = new ExcluirImovel(imovelRepository);
            _consultarImovel = new ConsultarImovel(imovelRepository);
        }
        public async Task<IActionResult> Index()
        {
            var listaImoveis = await _consultarImovel.ListarTodosImoveis();
            var listaImoveisViewModel = ImovelFactory.MapearListaImovelViewModel(listaImoveis);
            return View(listaImoveisViewModel);
        }
        public IActionResult Novo()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Novo(ImovelViewModel imovelViewModel)
        {
            if (ModelState.IsValid)
            {
                var imovel = ImovelFactory.MapearImovel(imovelViewModel);
                await _criarImovel.Executar(imovel);
                return RedirectToAction("Index");
            }
            return View(imovelViewModel);
        }
        public async Task<IActionResult> Alterar(int id)
        {
            var imovel = await _consultarImovel.BuscaPeloId(id);
            if(imovel == null)
            {
                return RedirectToAction("Index");
            }
            var imovelViewModel = ImovelFactory.MapearImovelViewModel(imovel);
            return View(imovelViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Alterar(int id, ImovelViewModel imovelViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(imovelViewModel);
            }
            var imovel = ImovelFactory.MapearImovel(imovelViewModel);
            await _alterarImovel.Executar(id, imovel);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Detalhar (int id)
        {
            var imovel = await _consultarImovel.BuscaPeloId(id);
            if(imovel == null)
            {
                return RedirectToAction("Index");
            }
            var imovelViewModel = ImovelFactory.MapearImovelViewModel(imovel);
            return View(imovelViewModel);
        }
        public async Task<IActionResult> Excluir(int id)
        {
            var imovel = await _consultarImovel.BuscaPeloId(id);
            if(imovel == null)
            {
                return RedirectToAction("Index");
            }
            await _excluirImovel.Executar(imovel);
            return RedirectToAction("Index");
        }
    }
}
