using Dominio.IRepositories;
using Historias.Imoveis;
using Imobiliaria_HomeOffice.Factories;
using Imobiliaria_HomeOffice.Models;
using Infra.Contexto;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Imobiliaria_HomeOffice.Controllers
{
    public class HomeController : Controller
    {
        private readonly AlterarImovel _alterarImovel;
        private readonly ExcluirImovel _excluirImovel;
        private readonly ConsultarImovel _consultarImovel;
        private readonly DataContext _dataContext;

        public HomeController(IImovelRepository imovelRepository, DataContext dataContext)
        {
            _alterarImovel = new AlterarImovel(imovelRepository);
            _excluirImovel = new ExcluirImovel(imovelRepository);
            _consultarImovel = new ConsultarImovel(imovelRepository);

            _dataContext = dataContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> PesquisaPorCidade(string SearchString1)
        {
            var imoveis = from cidade in _dataContext.Imoveis select cidade;
            if (!string.IsNullOrEmpty(SearchString1))
            {
                imoveis = imoveis.Where(x => x.Cidade.Contains(SearchString1));
            }
            var listaImoveisViewModel = ImovelFactory.MapearListaImovelViewModel(imoveis);
            return View(listaImoveisViewModel);
        }
        public async Task<IActionResult> PesquisaPorBairro(string SearchString2)
        {
            var imoveis = from bairro in _dataContext.Imoveis select bairro;
            if (!string.IsNullOrEmpty(SearchString2))
            {
                imoveis = imoveis.Where(x => x.Bairro.Contains(SearchString2));
            }
            var listaImoveisViewModel = ImovelFactory.MapearListaImovelViewModel(imoveis);
            return View(listaImoveisViewModel);
        }
        public async Task<IActionResult> Alterar(int id)
        {
            var imovel = await _consultarImovel.BuscaPeloId(id);
            if (imovel == null)
            {
                return RedirectToAction("Index");
            }
            var imovelViewmodel = ImovelFactory.MapearImovelViewModel(imovel);
            return View(imovelViewmodel);
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
        public async Task<IActionResult> Detalhar(int id)
        {
            var imovel = await _consultarImovel.BuscaPeloId(id);
            if (imovel == null)
            {
                return RedirectToAction("Index");
            }
            var imovelViewModel = ImovelFactory.MapearImovelViewModel(imovel);
            return View(imovelViewModel);
        }
        public async Task<IActionResult> Excluir(int id)
        {
            var imovel = await _consultarImovel.BuscaPeloId(id);
            if (imovel == null)
            {
                return RedirectToAction("Index");
            }
            await _excluirImovel.Executar(imovel);
            return RedirectToAction("Index");
        }
    }
}
