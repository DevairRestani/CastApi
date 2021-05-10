using CastApi.Interfaces;
using CastApi.Models;
using CastApi.Services.Communication;
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
        /// <returns>Retorna um erro quando houver.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurso(int id, Curso curso)
        {
            CursoResponse response = await _sCurso.AtualizarCursoAsync(id, curso);

            if (!response.Success)
            {
                return BadRequest(response.Message);
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
                CursoResponse response = await _sCurso.CriarCursoAsync(curso);

            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return curso;
        }

        /// <summary>
        /// Daleta um curso
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna um erro quando houver</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurso(int id)
        {
            CursoResponse response = await _sCurso.DeletarCursoAsync(id);

            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return NoContent();
        }
    }
}
