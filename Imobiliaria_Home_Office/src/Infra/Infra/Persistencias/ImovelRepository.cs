using Dominio.Entidades;
using Dominio.IRepositories;
using Infra.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Persistencias
{
    public class ImovelRepository : IImovelRepository
    {
        private readonly DataContext _dataContext;
        public ImovelRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task Criar(Imovel imovel)
        {
            _dataContext.Imoveis.Add(imovel);
            await _dataContext.SaveChangesAsync();
        }
        public async Task Alterar(Imovel imovel)
        {
            _dataContext.Update(imovel);
            await _dataContext.SaveChangesAsync();
        }
        public async Task Excluir(Imovel imovel)
        {
            _dataContext.Remove(imovel);
            await _dataContext.SaveChangesAsync();
        }
        public async Task<Imovel> BuscaPorId(int id)
        {
            var imovel = await _dataContext.Imoveis.FirstOrDefaultAsync(x => x.Id == id);
            return imovel;
        }
        public async Task<IEnumerable<Imovel>> ListarTodosImoveis()
        {
            return await _dataContext.Imoveis.AsNoTracking().ToListAsync();
        }
    }
}
