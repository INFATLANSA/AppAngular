using AppAngular.Server.Entities;
using AppAngular.Server.Utils;

namespace AppAngular.Server.Servicio
{
    public interface IServicioCatalogo
    {
        public GeneralResponse listaCatalogos();
        public GeneralResponse guardarCatalogo(Catalogo catalogo);
        public GeneralResponse actualizarCatalogo(string idCatalogo, Catalogo catalogo);
        public GeneralResponse eliminarCatalogo(string idCatalogo);
    }
}
