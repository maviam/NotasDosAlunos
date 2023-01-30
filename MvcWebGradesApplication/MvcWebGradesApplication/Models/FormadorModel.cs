using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcWebGradesApplication.Models
{
    [Table("Formadores")]
    public class FormadorModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
		[RegularExpression(@"^\d{9}$", ErrorMessage = "O Nif deve ser composto de 9 algarismos")]
		[Required(ErrorMessage = "Nif é de preenchimento obrigatório")]
		public long Nif { get; set; }

		[Required(ErrorMessage = "{0} é de preenchimento obrigatório")]
		public string Nome { get; set; }

		[Required(ErrorMessage = "{0} é de preenchimento obrigatório")]
		[DataType(DataType.EmailAddress, ErrorMessage = "O {0} inserido não é válido.")]
		public string Email { get; set; }

		[Required(ErrorMessage = "{0} é de preenchimento obrigatório")]
		[RegularExpression(@"^\d{9}$", ErrorMessage = "O {0} deve ser composto de 9 algarismos")]		
		[Display(Name = "Telemóvel")]
		public string Telemovel { get; set; }
    }
}
