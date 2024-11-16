using AppAngular.Server.Entities;

namespace AppAngular.Server.Repositorio
{
    //Exponer todos los metodos mediante esta interface, para que sea consumido por las demas capas. 
    public interface IRepositorioParametro
    {        
        List<Parametro> GetParametroList();

    }
}
