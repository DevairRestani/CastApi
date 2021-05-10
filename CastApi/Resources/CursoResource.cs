using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CastApi.Resources
{
    public class CursoResource
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
        public int QtdAlunos { get; set; }
        public int CategoriaId { get; set; }
    }
}
