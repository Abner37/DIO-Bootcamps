using ApiCatalogoJogos.Exceptions;
using ApiCatalogoJogos.Services;
using ApiCatalogoJogos.ViewModels;
using ApiCatalogoJogos.ViewModels.InputModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Controllers.V1
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        private readonly IJogoService _jogoService;


        public JogosController(IJogoService jogoService)
        {
            _jogoService = jogoService;
        }


        /// <summary>
        /// Busca todos os jogos de forma paginada.
        /// </summary>
        /// <remarks>
        /// Não é possível buscar os jogos sem paginação.
        /// </remarks>
        /// <param name="pagina">Indica qual página está sendo consultada. Mínimo 1.</param>
        /// <param name="quantidade">Indica a quantidade de registros por página. Mínimo 1 e máximo 50.</param>
        /// <response code="200">Retorna a lista de jogos.</response>
        /// <response code="204">Caso não haja jogos.</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JogoViewModel>>> Obter(
            [FromQuery, Range(1, int.MaxValue)] int pagina = 1, 
            [FromQuery, Range(1, 50)] int quantidade = 5)
        {
            var jogos = await _jogoService.Obter(pagina, quantidade);

            if (!jogos.Any())
                return NoContent();

            return Ok(jogos);
        }


        /// <summary>
        /// Busca um jogo pelo seu Id.
        /// </summary>
        /// <param name="idJogo">Id do jogo desejado.</param>
        /// <response code="200">Retorna o jogo encontrado.</response>
        /// <response code="204">Caso não haja um jogo com esse Id.</response>
        [HttpGet("{idJogo:guid}")]
        public async Task<ActionResult<JogoViewModel>> Obter([FromRoute] Guid idJogo)
        {
            var jogo = await _jogoService.Obter(idJogo);

            if (jogo == null)
                return NoContent();

            return Ok(jogo);
        }


        /// <summary>
        /// Cadastra um novo jogo.
        /// </summary>
        /// <param name="jogoInputModel">Dados do jogo a ser salvo.</param>
        /// <response code="200">Retorna o jogo salvo.</response>
        /// <response code="422">Caso já exista um jogo com este mesmo nome e produtora cadastrado.</response>
        [HttpPost]
        public async Task<ActionResult<JogoViewModel>> InserirJogo([FromBody] JogoInputModel jogoInputModel)
        {
            try
            {
                var jogo = await _jogoService.Inserir(jogoInputModel);

                return Ok(jogo);
            }
            catch (JogoJaCadastradoException)
            {
                return UnprocessableEntity("Já existe um jogo com este nome para esta produtora.");
            }
        }


        /// <summary>
        /// Atualiza os dados de um jogo cadastrado.
        /// </summary>
        /// <param name="idJogo">Id do jogo que deseja atualizar.</param>
        /// <param name="jogoInputModel">Novos dados do jogo que será atualizado.</param>
        /// <response code="200">Jogo atualizado com sucesso.</response>
        /// <response code="404">Jogo não cadastrado.</response>
        [HttpPut("{idJogo:guid}")]
        public async Task<ActionResult> AtualizarJogo([FromRoute] Guid idJogo, [FromBody] JogoInputModel jogoInputModel)
        {
            try
            {
                await _jogoService.Atualizar(idJogo, jogoInputModel);

                return Ok();
            }
            catch (JogoNaoCadastradoException)
            {
                return NotFound("Este jogo não está cadastrado.");
            }
        }


        /// <summary>
        /// Atualiza o preço de um jogo cadastrado.
        /// </summary>
        /// <param name="idJogo">Id do jogo desejado.</param>
        /// <param name="preco">Novo preço do jogo.</param>
        /// <response code="200">Preço atualizado com sucesso.</response>
        /// <response code="404">Jogo não cadastrado.</response>
        [HttpPatch("{idJogo:guid}/preco/{preco:double}")]
        public async Task<ActionResult> AtualizarJogo([FromRoute] Guid idJogo, [FromRoute] double preco)
        {
            try
            {
                await _jogoService.Atualizar(idJogo, preco);

                return Ok();
            }
            catch (JogoNaoCadastradoException)
            {
                return NotFound("Este jogo não está cadastrado.");
            }
        }


        /// <summary>
        /// Exclui um jogo cadastrado.
        /// </summary>
        /// <param name="idJogo">Id do jogo desejado.</param>
        /// <response code="200">Jogo excluído com sucesso.</response>
        /// <response code="404">Jogo não cadastrado.</response>
        [HttpDelete("{idJogo:guid}")]
        public async Task<ActionResult> ExcluirJogo([FromRoute] Guid idJogo)
        {
            try
            {
                await _jogoService.Remover(idJogo);

                return Ok();
            }
            catch (JogoNaoCadastradoException)
            {
                return NotFound("Este jogo não está cadastrado.");
            }
        }
    }
}
