using CastApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CastApi.Interfaces
{
    public interface ISCurso
    {
        Task<List<Curso>> ListarCursosAsync();
        Task<Curso> CriarCursoAsync(Curso curso);
        Task<Curso> AtualizarCursoAsync(int id, Curso curso);
        Task<bool> CursoExisteAsync(int id);
        Task<Curso> BuscarCursoAsync(int id);
        Task<bool> DeletarCursoAsync(int id);
    }
}
