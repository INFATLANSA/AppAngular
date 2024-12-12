using AppAngular.Server.Entities;

namespace AppAngular.Server.Repositorio
{
    //Interfaz para exponer los metodos del repositorio a las demas capas de la aplicación. 
    public interface IRepositorioCatalogo
    {
        List<Catalogo> GetCatalogos();
        void SaveCatalogo(Catalogo catalogo);
        void UpdateCatalogo(string idCatalogo, Catalogo catalogo); 
        void DeleteCatalogo(string idCatalogo);
    }
}
