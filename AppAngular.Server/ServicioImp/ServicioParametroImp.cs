using AppAngular.Server.Servicio;
using AppAngular.Server.Repositorio;
using AppAngular.Server.Entities;
using AppAngular.Server.Utils;

namespace AppAngular.Server.ServicioImp
{
    //Consultar la capa de Repositorio. Debemos consultar la Interface
    public class ServicioParametroImp : IServicioParametro
    {
        private readonly IRepositorioParametro _repositorioParametro;

        private GeneralResponse generalResponse = new GeneralResponse();

        public ServicioParametroImp(IRepositorioParametro repositorioParametro) 
        {
            _repositorioParametro = repositorioParametro;
        }

        // Aquí vamos a crear nuevos metodos a que consumen de la interfaz 
        // La finalidad de personalizar y controlar excepciones. Ya que el usuario no debe conocer que tipo de error sucedió en el backend.
        public GeneralResponse listaParametros()
        {
            try
            {
                List<Parametro> list = _repositorioParametro.GetParametroList();
                if (list.Count() > 0)
                {
                    generalResponse = GeneralResponseFn.responseGeneral( 200 , "Hay data" , list );
                }
                else 
                {
                    generalResponse = GeneralResponseFn.responseGeneral( 400 , "No hay data" , list );
                }
            }
            catch (Exception) 
            {
                generalResponse = GeneralResponseFn.responseGeneral( 500, "Ocurrió un error Server" , null );                
            }
            return generalResponse;    
        }
    }
}
