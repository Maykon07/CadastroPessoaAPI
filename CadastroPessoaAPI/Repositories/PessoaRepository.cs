using CadastroPessoaAPI.Context;
using CadastroPessoaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroPessoaAPI.Repositories
{
    public class PessoaRepository
    {
        private readonly CadastroPessoaContext _context;

        public PessoaRepository(CadastroPessoaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Pessoa>> GetPessoas()
        {
            return await _context.Pessoas.ToListAsync();
        }

        public async Task<Pessoa> GetPessoaById(int id)
        {
            return await _context.Pessoas.FindAsync(id);
        }

        public async Task CreatePessoa(Pessoa pessoa)
        {
            _context.Pessoas.Add(pessoa);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePessoa(Pessoa pessoa)
        {
            _context.Entry(pessoa).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeletePessoa(int id)
        {
            var pessoa = await _context.Pessoas.FindAsync(id);
            if (pessoa != null)
            {
                _context.Pessoas.Remove(pessoa);
                await _context.SaveChangesAsync();
            }
        }
    }
}