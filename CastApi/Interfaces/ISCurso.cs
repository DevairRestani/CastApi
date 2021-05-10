using CastApi.Models;
using CastApi.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CastApi.Interfaces
{
    public interface ISCurso
    {
        Task<List<Curso>> ListarCursosAsync();
        Task<CursoResponse> CriarCursoAsync(Curso curso);
        Task<CursoResponse> AtualizarCursoAsync(int id, Curso curso);
        Task<bool> CursoExisteAsync(int id);
        Task<Curso> BuscarCursoAsync(int id);
        Task<CursoResponse> DeletarCursoAsync(int id);
    }
}
