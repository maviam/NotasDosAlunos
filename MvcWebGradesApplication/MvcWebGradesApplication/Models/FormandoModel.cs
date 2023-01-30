using MvcWebGradesApplication.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcWebGradesApplication.Models
{
    [Table("Formandos")]
    public class FormandoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set; }

		[Display(Name = "Telemóvel")]
		public string Telemovel { get; set; }
        public SexoEnum Sexo { get; set; }
    }
}
