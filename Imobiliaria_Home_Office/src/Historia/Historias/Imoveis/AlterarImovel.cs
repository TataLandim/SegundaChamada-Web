using Dominio.Entidades;
using Dominio.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Historias.Imoveis
{
    public class AlterarImovel
    {
        private readonly IImovelRepository _imovelRepository;
        public AlterarImovel(IImovelRepository imovelRepository)
        {
            _imovelRepository = imovelRepository;
        }
        public async Task Executar(int id, Imovel imovel)
        {
            var dadosDoImovel = await _imovelRepository.BuscaPorId(id);
            dadosDoImovel.AtualizarImovel(imovel.Cidade, imovel.Bairro, imovel.QtdDeQuartos, imovel.ValorDoAluguel);
            await _imovelRepository.Alterar(dadosDoImovel);
        }
    }
}
