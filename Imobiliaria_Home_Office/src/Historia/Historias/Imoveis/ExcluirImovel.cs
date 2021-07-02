using Dominio.Entidades;
using Dominio.IRepositories;
using System.Threading.Tasks;

namespace Historias.Imoveis
{
    public class ExcluirImovel
    {
        private readonly IImovelRepository _imovelRepository;

        public ExcluirImovel(IImovelRepository imovelRepository)
        {
            _imovelRepository = imovelRepository;
        }
        public async Task Executar(Imovel imovel)
        {
            await _imovelRepository.Excluir(imovel);
        }
    }
}
