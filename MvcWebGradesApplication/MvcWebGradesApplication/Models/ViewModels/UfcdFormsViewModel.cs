namespace MvcWebGradesApplication.Models.ViewModels
{
    public class UfcdFormsViewModel
    {
        public UfcdModel Ufcd { get; set; }
        public IEnumerable<FormadorModel> Formadores { get; set; }
    }
}
