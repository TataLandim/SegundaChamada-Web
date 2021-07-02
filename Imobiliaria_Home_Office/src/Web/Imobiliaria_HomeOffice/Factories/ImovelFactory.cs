using Dominio.Entidades;
using Imobiliaria_HomeOffice.Models;
using System.Collections.Generic;

namespace Imobiliaria_HomeOffice.Factories
{
    public class ImovelFactory
    {
        public static ImovelViewModel MapearImovelViewModel(Imovel imovel)
        {
            var imovelViewModel = new ImovelViewModel
            {
                Id = imovel.Id,
                Cidade = imovel.Cidade,
                Bairro = imovel.Bairro,
                QtdDeQuartos = imovel.QtdDeQuartos,
                ValorDoAluguel = imovel.ValorDoAluguel,
            };
            return imovelViewModel;
        }
        public static Imovel MapearImovel(ImovelViewModel imovelViewModel)
        {
            var imovel = new Imovel(
                imovelViewModel.Cidade,
                imovelViewModel.Bairro,
                imovelViewModel.QtdDeQuartos,
                imovelViewModel.ValorDoAluguel
                );
            return imovel;
        }
        public static IEnumerable<ImovelViewModel>MapearListaImovelViewModel(IEnumerable<Imovel> imoveis)
        {
            var lista = new List<ImovelViewModel>();
            foreach(var item in imoveis)
            {
                lista.Add(MapearImovelViewModel(item));
            }
            return lista;
        }
    }
}
