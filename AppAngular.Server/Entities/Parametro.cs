using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppAngular.Server.Entities
{
    [Table("Parametro")]
    public class Parametro
    {
        [Key]
        public long IdParametro { get; set; }
        public string? Codigo { get; set; }
        public string Valor { get; set; }
        public string? Descripcion { get; set; }
        public int Estado { get; set; }
        public string? TipoParametro { get; set; }
    }
}
