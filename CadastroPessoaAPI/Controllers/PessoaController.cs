using Microsoft.AspNetCore.Mvc;
using CadastroPessoaAPI.Models;
using CadastroPessoaAPI.Services;

namespace CadastroPessoaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly PessoaService _pessoaService;

        public PessoaController(PessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pessoa>>> GetPessoas()
        {
            var pessoas = await _pessoaService.GetPessoas();
            return Ok(pessoas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pessoa>> GetPessoaById(int id)
        {
            try
            {
                var pessoa = await _pessoaService.GetPessoaById(id);
                return Ok(pessoa);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Pessoa>> CreatePessoa(Pessoa pessoa)
        {
            try
            {
                await _pessoaService.CreatePessoa(pessoa);
                return CreatedAtAction(nameof(GetPessoaById), new { id = pessoa.Id }, pessoa);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePessoa(int id, Pessoa pessoa)
        {
            if (id != pessoa.Id)
            {
                return BadRequest("ID inválido.");
            }

            try
            {
                await _pessoaService.UpdatePessoa(pessoa);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePessoa(int id)
        {
            try
            {
                await _pessoaService.DeletePessoa(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}