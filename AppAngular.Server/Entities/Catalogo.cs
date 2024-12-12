using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppAngular.Server.Entities
{
    [Table("Catalogo")]
    public class Catalogo
    {
        [Key]
        [Required(ErrorMessage = "El IdCatalogo es requerido")]
        [StringLength(3, ErrorMessage = "El codigo debe tener maximo tres caracteres")]
        public string IdCatalogo { get; set; }

        [Required(ErrorMessage = "La Descripcion es requerida")]
        [StringLength(20, ErrorMessage = "La Descripcion debe tener maximo 20 caracteres")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "El Estado es requerido")]
        [Range(0, int.MaxValue, ErrorMessage = "El valor debe ser 0 o un número entero positivo.")]
        public int? Estado { get; set; }
    }
}
