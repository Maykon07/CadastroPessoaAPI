using CadastroPessoaAPI.Models;
using CadastroPessoaAPI.Repositories;

namespace CadastroPessoaAPI.Services
{
    public class PessoaService
    {
        private readonly PessoaRepository _pessoaRepository;

        public PessoaService(PessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public async Task<IEnumerable<Pessoa>> GetPessoas()
        {
            return await _pessoaRepository.GetPessoas();
        }

        public async Task<Pessoa> GetPessoaById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID inválido.");
            }

            var pessoa = await _pessoaRepository.GetPessoaById(id);
            if (pessoa == null)
            {
                throw new KeyNotFoundException("Pessoa não encontrada.");
            }

            return pessoa;
        }

        public async Task CreatePessoa(Pessoa pessoa)
        {
            if (string.IsNullOrWhiteSpace(pessoa.Nome))
            {
                throw new ArgumentException("O nome é obrigatório.");
            }

            if (pessoa.Idade <= 0)
            {
                throw new ArgumentException("A idade deve ser maior que zero.");
            }

            if (string.IsNullOrWhiteSpace(pessoa.Sexo))
            {
                throw new ArgumentException("O sexo é obrigatório.");
            }

            await _pessoaRepository.CreatePessoa(pessoa);
        }

        public async Task UpdatePessoa(Pessoa pessoa)
        {
            if (pessoa.Id <= 0)
            {
                throw new ArgumentException("ID inválido.");
            }

            if (string.IsNullOrWhiteSpace(pessoa.Nome))
            {
                throw new ArgumentException("O nome é obrigatório.");
            }

            if (pessoa.Idade <= 0)
            {
                throw new ArgumentException("A idade deve ser maior que zero.");
            }

            if (string.IsNullOrWhiteSpace(pessoa.Sexo))
            {
                throw new ArgumentException("O sexo é obrigatório.");
            }

            await _pessoaRepository.UpdatePessoa(pessoa);
        }

        public async Task DeletePessoa(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID inválido.");
            }

            await _pessoaRepository.DeletePessoa(id);
        }
    }
}