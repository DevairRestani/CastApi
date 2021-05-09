using CastApi.Interfaces;
using CastApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CastApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursosController : ControllerBase
    {
        private readonly ISCurso _sCurso;

        public CursosController(ISCurso sCurso)
        {
            _sCurso = sCurso;
        }

        /// <summary>
        /// Lista todos os cursos
        /// </summary>
        /// <returns>Lista dos Cursos</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Curso>), 200)]
        public async Task<IEnumerable<Curso>> GetCursos()
        {
            return await _sCurso.ListarCursosAsync();
        }

        /// <summary>
        /// Busca um curso pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna um Curso</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Curso>> GetCurso(int id)
        {
            Curso curso = await _sCurso.BuscarCursoAsync(id);

            if (curso == null)
            {
                return NotFound();
            }

            return curso;
        }

        /// <summary>
        /// Atualiza um curso pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="curso"></param>
        /// <returns>Não tem retorno</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurso(int id, Curso curso)
        {
            try
            {
                await _sCurso.AtualizarCursoAsync(id, curso);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return NoContent();
        }

        /// <summary>
        /// Cadastra um curso
        /// </summary>
        /// <param name="curso"></param>
        /// <returns>Retorna o Curso Cadastrado</returns>
        [HttpPost]
        public async Task<ActionResult<Curso>> PostCurso(Curso curso)
        {
            try
            {
                await _sCurso.CriarCursoAsync(curso);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return curso;
        }

        /// <summary>
        /// Daleta um curso
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Não tem retorno</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurso(int id)
        {
            bool sucesso = await _sCurso.DeletarCursoAsync(id);

            if (!sucesso)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
