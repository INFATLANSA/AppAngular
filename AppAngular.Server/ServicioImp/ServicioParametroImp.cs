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
                    generalResponse = GeneralResponseFn.responseGeneral( Constantes.CODIGO_EXITO , Constantes.MENSAJE_OK , list );
                }
                else 
                {
                    generalResponse = GeneralResponseFn.responseGeneral( Constantes.CODIGO_NO_DATA , Constantes.MENSAJE_NO_DATA , list );
                }
            }
            catch (Exception) 
            {
                generalResponse = GeneralResponseFn.responseGeneral( Constantes.CODIGO_ERROR, Constantes.getMensaje("") , null );                
            }
            return generalResponse;    
        }

        public GeneralResponse guardarParametro(Parametro parametro)
        {
            try
            {
                _repositorioParametro.guardarParametros(parametro );
                generalResponse = GeneralResponseFn.responseGeneral(Constantes.CODIGO_EXITO,Constantes.MENSAJE_OK, null ); 

            }
            catch (Exception ex)
            {
                generalResponse = GeneralResponseFn.responseGeneral(Constantes.CODIGO_ERROR, Constantes.getMensaje(ex.Message), null);
            }

            return generalResponse;
        }
    }
}
