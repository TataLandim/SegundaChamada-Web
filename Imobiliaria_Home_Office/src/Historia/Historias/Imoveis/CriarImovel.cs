using Dominio.Entidades;
using Dominio.IRepositories;
using System.Threading.Tasks;

namespace Historias.Imoveis
{
    public class CriarImovel
    {
        private readonly IImovelRepository _imovelRepository;

        public CriarImovel(IImovelRepository imovelRepository)
        {
            _imovelRepository = imovelRepository;
        }
        public async Task Executar(Imovel imovel)
        {
            await _imovelRepository.Criar(imovel);
        }
    }
}
