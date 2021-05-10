using CastApi.Models;

namespace CastApi.Services.Communication
{
    public class CursoResponse : BaseResponse<Curso>
    {
        /// <summary>
        /// Cria uma resposta de sucesso.
        /// </summary>
        /// <param name="curso">Response.</param>
        public CursoResponse(Curso curso) : base(curso) { }

        /// <summary>
        /// Cria uma resposta de erro.
        /// </summary>
        /// <param name="curso">Response.</param>
        public CursoResponse(string message) : base(message) { }
    }
}
