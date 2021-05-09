using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CastApi.Models
{
    public class Categoria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "O campo descrição é obrigatório")]
        public string Descricao { get; set; }

        public List<Curso> Cursos { get; set; }
    }
}