using Microsoft.EntityFrameworkCore;
using CadastroPessoaAPI.Models;

namespace CadastroPessoaAPI.Context
{
    public class CadastroPessoaContext : DbContext
    {
        public CadastroPessoaContext(DbContextOptions<CadastroPessoaContext> options) : base(options)
        {
        }

        public DbSet<Pessoa> Pessoas { get; set; }
    }
}