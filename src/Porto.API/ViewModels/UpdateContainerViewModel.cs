using System.ComponentModel.DataAnnotations;

namespace Porto.API.ViewModels{
    public class UpdateContainerViewModel{
        [Required(ErrorMessage = "O Id não pode ser vazio.")]
        [Range(1, int.MaxValue, ErrorMessage = "O id não pode ser menor que 1.")]
        public long Id { get; set; }

        [Required(ErrorMessage = "Não pode ser vazio")]
        [MinLength(3, ErrorMessage = "O cliente deve ter no mínimo 3 caracteres.")]
        [MaxLength(80, ErrorMessage = "O cliente deve ter no máximo 80 caracteres.")]
        public string ClientContainer { get; set; }
        [Required(ErrorMessage = "Não pode ser vazio")]
        [RegularExpression(@"([A-Z]{4})([0-9]{7})", ErrorMessage = "Deve conter 4 letras maiusculas e 7 numeros")]
        [MinLength(11, ErrorMessage = "O número do container deve ter no mínimo 11 caracteres.")]
        [MaxLength(11, ErrorMessage = "O número do container deve ter no máximo 11 caracteres.")]
        public string NumContainer { get; set; } //4 letras 7 numeros
        [Required(ErrorMessage = "Não pode ser vazio")]
         [EnumDataType(typeof(TypeContainerOption), ErrorMessage="Tipo deve ser 20/40")]  
        public int TypeContainer { get; set; } // 20/40
        [Required(ErrorMessage = "Não pode ser vazio")]
        [MinLength(5, ErrorMessage = "O status do container deve ter no mínimo 5 caracteres.")]
        [MaxLength(5, ErrorMessage = "O status do container deve ter no máximo 5 caracteres.")]
        public string StatusContainer { get; set; } // cheio/vazio
        [Required(ErrorMessage = "Não pode ser vazio")]
        [MinLength(10, ErrorMessage = "A categoria do container deve ter no mínimo 10 caracteres.")]
        [MaxLength(10, ErrorMessage = "A categoria do container deve ter no máximo 10 caracteres.")]
        public string CategoryContainer { get; set; } //importação/exportação
    }
}