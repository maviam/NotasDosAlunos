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
        public int Codigo { get; set; }
        public string Denominacao { get; set; }
        public int Duracao { get; set; }
        public ComponenteEnum Componente { get; set; }
        public long FormadorNif { get; set; }
        [ForeignKey(nameof(FormadorNif))]
        public virtual FormadorModel Formador { get; set; }
    }
}
