using System.ComponentModel.DataAnnotations;

namespace Porto.API.ViewModels{
    public class CreateMovementViewModel{
        [Required(ErrorMessage ="Não pode ser vazio")]
        [MinLength(6, ErrorMessage = "O tipo de movimentação deve ter no mínimo 6 caracteres.")]
        [MaxLength(16, ErrorMessage = "O tipo de movimentação deve ter no máximo 16 caracteres.")]
        public string TypeMovement { get; set; } //embarque, descarga, gate in, gate out, reposicionamento, pesagem e scanner
        
        [RegularExpression(@"(\d{2})[-.\/](\d{2})[-.\/](\d{4})", ErrorMessage = "formato deve ser xx/xx/xxxx")]
        [Required(ErrorMessage ="Não pode ser vazio")]
        [MinLength(10, ErrorMessage = "A data incial de movimentação deve ter no mínimo 10 caracteres.")]
        [MaxLength(10, ErrorMessage = "A data incial de movimentação deve ter no máximo 10 caracteres.")]
        public string DateInitial { get; set; } //data do inicio
        
        [Required(ErrorMessage ="Não pode ser vazio")]
        [MinLength(5, ErrorMessage = "A hora incial de movimentação deve ter no mínimo 5 caracteres.")]
        [MaxLength(5, ErrorMessage = "A hora incial de movimentação deve ter no máximo 5 caracteres.")]
        [RegularExpression(@"(\d{2})[-.\:](\d{2})", ErrorMessage = "formato deve ser xx:xx")]
        public string HourInitial { get; set; } //hora do inicio
        
        [Required(ErrorMessage ="Não pode ser vazio")]
        [MinLength(10, ErrorMessage = "A data final de movimentação deve ter no mínimo 10 caracteres.")]
        [MaxLength(10, ErrorMessage = "A data final de movimentação deve ter no máximo 10 caracteres.")]
        [RegularExpression(@"(\d{2})[-.\/](\d{2})[-.\/](\d{4})", ErrorMessage = "formato deve ser xx/xx/xxxx")]
        public string DateFinish { get; set; } //data do fim
        
        [Required(ErrorMessage ="Não pode ser vazio")]
        [MinLength(5, ErrorMessage = "A hora final de movimentação deve ter no mínimo 5 caracteres.")]
        [MaxLength(5, ErrorMessage = "A hora final de movimentação deve ter no máximo 5 caracteres.")]
        [RegularExpression(@"(\d{2})[-.\:](\d{2})", ErrorMessage = "formato deve ser xx:xx")]
        public string HourFinish { get; set; } //hora do fim
    }
}