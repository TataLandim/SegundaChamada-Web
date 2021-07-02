using Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dominio.IRepositories
{
    public interface IImovelRepository
    {
        Task Criar(Imovel imovel);
        Task Alterar(Imovel imovel);
        Task Excluir(Imovel imovel);
        Task<Imovel> BuscaPorId(int id);
        Task<IEnumerable<Imovel>> ListarTodosImoveis();
    }
}
