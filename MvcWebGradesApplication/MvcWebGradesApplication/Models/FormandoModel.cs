using MvcWebGradesApplication.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcWebGradesApplication.Models
{
    [Table("Formandos")]
    public class FormandoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telemovel { get; set; }
        public SexoEnum Sexo { get; set; }
    }
}
