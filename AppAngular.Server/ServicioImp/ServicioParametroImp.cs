using AppAngular.Server.Servicio;
using AppAngular.Server.Repositorio;
using AppAngular.Server.Entities;

namespace AppAngular.Server.ServicioImp
{
    //Consultar la capa de Repositorio. Debemos consultar la Interface
    public class ServicioParametroImp : IServicioParametro
    {
        private readonly IRepositorioParametro _repositorioParametro;
        public ServicioParametroImp(IRepositorioParametro repositorioParametro) 
        {
            _repositorioParametro = repositorioParametro;
        }

        // Aquí vamos a crear nuevos metodos a que consumen de la interfaz 
        // La finalidad de personalizar y controlar excepciones. Ya que el usuario no debe conocer que tipo de error sucedió en el backend.
        public List<Parametro> listaParametros()
        {
            try
            {
                List<Parametro> list = _repositorioParametro.GetParametroList();
                if (list.Count() > 0)
                {
                    return list;
                }
                else 
                {
                    return null;
                }
            }
            catch (Exception ex) 
            {
                throw new Exception("Ocurrió un error en la consulta...");
                
            }
        }
    }
}
