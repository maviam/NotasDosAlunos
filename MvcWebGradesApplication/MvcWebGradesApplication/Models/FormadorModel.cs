using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcWebGradesApplication.Models
{
    [Table("Formadores")]
    public class FormadorModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Nif { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telemovel { get; set; }
    }
}
