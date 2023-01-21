using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcWebGradesApplication.Models
{
    [Table("Notas")]
    public class NotaModel
    {
        public int CodigoUfcd { get; set; }
        [ForeignKey(nameof(CodigoUfcd))]
        public virtual UfcdModel Ufcd { get; set; }
        public int FormandoId { get; set; }
        [ForeignKey(nameof(FormandoId))]
        public virtual FormandoModel Formando { get; set; }
        public DateTime DataLancamentoNota { get; set; }
        public double Nota { get; set; }
    }
}
