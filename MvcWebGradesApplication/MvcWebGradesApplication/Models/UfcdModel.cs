using MvcWebGradesApplication.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcWebGradesApplication.Models
{
    [Table("Ufcds")]
    public class UfcdModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Display(Name = "Código da Ufcd")]
        [DisplayFormat(DataFormatString = "{0:0000}")]
		public int Codigo { get; set; }

		[Display(Name = "Ufcd")]
		public string Denominacao { get; set; }

		[Display(Name = "Duração (em horas)")]
		public int Duracao { get; set; }
        public ComponenteEnum Componente { get; set; }

		[Display(Name = "Formador")]
		public long FormadorNif { get; set; }
        [ForeignKey(nameof(FormadorNif))]
        public virtual FormadorModel Formador { get; set; }
    }
}
