using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CastApi.Models
{
    public class Curso
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CursoId { get; set; }

        [Required(ErrorMessage = "O Campo Descrição é obrigatório")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O Campo Data de Inicío é obrigatório")]
        public DateTime DataInicio { get; set; }

        [Required(ErrorMessage = "O Campo Data de Término é obrigatório")]
        public DateTime DataTermino { get; set; }

        public int QtdAlunos { get; set; }

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}