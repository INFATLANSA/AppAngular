using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppAngular.Server.Entities
{
    [Table("Catalogo")]
    public class Catalogo
    {
        [Key]
        public string IdCatalogo { get; set; }
        public string? Descripcion { get; set; }
        public int? Estado { get; set; }
    }
}
