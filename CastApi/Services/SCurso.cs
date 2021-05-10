using CastApi.Data;
using CastApi.Interfaces;
using CastApi.Models;
using CastApi.Services.Communication;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CastApi.Services
{
    public class SCurso : ISCurso
    {
        private readonly DataContext _context;

        /// <summary>
        /// Contem métodos para a entidade Cursos. Dispara uma exeption quando houver inconsistencia com os dados.
        /// </summary>
        /// <param name="context"></param>
        public SCurso(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Busca no banco de dados, em Cursos, conflitos entra as datas já agendadas e as que serão salvas.
        /// </summary>
        /// <param name="curso"></param>
        /// <returns>Retorna a quantidade de conflitos entre as datas.</returns>
        private async Task<int> ConflitosEntreDatasAsync(Curso curso)
        {
            return await _context.Cursos.CountAsync(
                c => c.DataInicio <= curso.DataInicio && c.DataTermino >= curso.DataTermino ||
                c.DataInicio <= curso.DataTermino && c.DataTermino >= curso.DataTermino ||
                c.DataInicio >= curso.DataInicio && c.DataTermino <= curso.DataTermino);
        }

        /// <summary>
        /// Lista todos os cursos
        /// </summary>
        /// <returns>Lista dos Cursos</returns>
        public async Task<List<Curso>> ListarCursosAsync()
        {
            return await _context.Cursos.ToListAsync();
        }

        /// <summary>
        /// Cadastra um curso no banco de dados.
        /// </summary>
        /// <param name="curso"></param>
        /// <returns>Retorna o Curso Cadastrado.</returns>
        public async Task<CursoResponse> CriarCursoAsync(Curso curso)
        {
            if (curso is null)
            {
                return new CursoResponse("Curso inválido");
            }

            int qtdConflitos = await ConflitosEntreDatasAsync(curso);

            if (qtdConflitos > 0)
            {
                return new CursoResponse("Existe(m) curso(s) planejados(s) dentro do período informado.");
            }

            if (curso.DataInicio < DateTime.Now)
            {
                return new CursoResponse("A data de incío do curso não pode ser menor que a data de hoje.");
            }

            _context.Cursos.Add(curso);
            await _context.SaveChangesAsync();

            return new CursoResponse(curso);
        }

        /// <summary>
        /// Atualiza um curso no banco de dados utilizando o Id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="curso"></param>
        /// <returns>Não tem retorno.</returns>
        public async Task<CursoResponse> AtualizarCursoAsync(int id, Curso curso)
        {
            if (id != curso.CursoId)
            {
                return new CursoResponse("Id Inválido");
            }

            int qtdConflitos = await ConflitosEntreDatasAsync(curso);

            if (qtdConflitos > 0)
            {
                return new CursoResponse("Existe(m) curso(s) planejados(s) dentro do período informado.");
            }

            _context.Entry(curso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (! await CursoExisteAsync(id))
                {
                    return new CursoResponse("Este curso não existe");
                }

                throw;
            }

            return new CursoResponse(curso);
        }

        /// <summary>
        /// valida a existencia de um curso
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna um objeto Curso contendo ou não o curso</returns>
        public async Task<bool> CursoExisteAsync(int id)
        {
            return await _context.Cursos.AnyAsync(e => e.CursoId == id);
        }

        /// <summary>
        /// Busca um curso pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna um Curso</returns>
        public async Task<Curso> BuscarCursoAsync(int id)
        {
            return await _context.Cursos.FindAsync(id);

        }

        /// <summary>
        /// Daleta um curso
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Não tem retorno</returns>
        public async Task<CursoResponse> DeletarCursoAsync(int id)
        {
            Curso curso = await _context.Cursos.FindAsync(id);

            if (curso == null)
            {
                return new CursoResponse("Ocorreu um erro ao deletar o curso");
            }

            _context.Cursos.Remove(curso);
            await _context.SaveChangesAsync();

            return new CursoResponse(curso);
        }
    }
}
