using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppAngular.Server.Entities
{
    [Table("Parametro")]
    public class Parametro
    {
        [Key]
        public long IdParametro { get; set; }
        [Required(ErrorMessage = "El codigo es requerido")]
        [StringLength(3, ErrorMessage = "El codigo debe tener maximo tres caracteres")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "El Valor es requerido")]
        [StringLength(400, ErrorMessage = "El codigo debe tener maximo 400 caracteres")]
        public string Valor { get; set; }

        [Required(ErrorMessage = "La Descricrpcion es requerido")]
        [StringLength(400, ErrorMessage = "La descripcion debe tener maximo 400 caracteres")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "El estado es requerido")]
        public int Estado { get; set; }

        [StringLength(10, ErrorMessage = "El codigo debe tener maximo diez caracteres")]
        public string? TipoParametro { get; set; }
    }
}
