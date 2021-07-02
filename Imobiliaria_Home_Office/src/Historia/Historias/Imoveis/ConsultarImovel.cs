using Dominio.Entidades;
using Dominio.IRepositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Historias.Imoveis
{
    public class ConsultarImovel
    {
        private readonly IImovelRepository _imovelRepository;
        public ConsultarImovel(IImovelRepository imovelRepository)
        {
            _imovelRepository = imovelRepository;
        }
        public async Task<Imovel>BuscaPeloId(int id)
        {
            return await _imovelRepository.BuscaPorId(id);
        }
        public async Task<IEnumerable<Imovel>> ListarTodosImoveis()
        {
            return await _imovelRepository.ListarTodosImoveis();
        }
    }
}
