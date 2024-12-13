using AppAngular.Server.Entities;
using AppAngular.Server.Repositorio;
using AppAngular.Server.Servicio;
using AppAngular.Server.Utils;

namespace AppAngular.Server.ServicioImp
{
    public class ServicioCatalogoImp : IServicioCatalogo
    {
        //inyectar el repositorio de catalogo
        private readonly IRepositorioCatalogo _repositorioCatalogo;

        GeneralResponse generalResponse = new GeneralResponse();    
        public ServicioCatalogoImp(IRepositorioCatalogo repositorioCatalogo)
        {
            _repositorioCatalogo = repositorioCatalogo;
        }
        // Aquí vamos a crear nuevos metodos a que consumen de la interfaz de repositorio
        // La finalidad de personalizar y controlar excepciones. Ya que el usuario no debe conocer que tipo de error sucedió en el backend.
        public GeneralResponse listaCatalogos()
        {
            try
            {
                List<Catalogo> list = _repositorioCatalogo.GetCatalogos();
                if (list.Count() > 0)
                {
                    generalResponse = GeneralResponseFn.responseGeneral(Constantes.CODIGO_EXITO, Constantes.MENSAJE_OK, list);
                }
                else
                {
                    generalResponse = GeneralResponseFn.responseGeneral(Constantes.CODIGO_NO_DATA, Constantes.MENSAJE_NO_DATA, null);
                }
            }
            catch (Exception)
            {
                generalResponse = GeneralResponseFn.responseGeneral(Constantes.CODIGO_ERROR, Constantes.getMensaje(""), null);
            }
            return generalResponse;
        }


        public GeneralResponse guardarCatalogo(Catalogo catalogo)
        {
            try
            {
                _repositorioCatalogo.SaveCatalogo(catalogo);
                generalResponse = GeneralResponseFn.responseGeneral(Constantes.CODIGO_EXITO, Constantes.MENSAJE_OK, null);

            }
            catch (Exception ex)
            {
                generalResponse = GeneralResponseFn.responseGeneral(Constantes.CODIGO_ERROR, Constantes.getMensaje(ex.Message), null);
            }

            return generalResponse;
        }

        public GeneralResponse actualizarCatalogo(string idCatalogo,Catalogo catalogo)
        {
            try
            {
                if (string.IsNullOrEmpty(idCatalogo))
                {
                    throw new Exception("El idCatalogo no es valido.");
                }
                _repositorioCatalogo.UpdateCatalogo(idCatalogo,catalogo);
                generalResponse = GeneralResponseFn.responseGeneral(Constantes.CODIGO_EXITO, Constantes.MENSAJE_OK, null);

            }
            catch (Exception ex)
            {
                generalResponse = GeneralResponseFn.responseGeneral(Constantes.CODIGO_ERROR, Constantes.getMensaje(ex.Message), null);
            }

            return generalResponse;
        }

        public GeneralResponse eliminarCatalogo(string idCatalogo)
        {
            try
            {
                if (string.IsNullOrEmpty(idCatalogo))
                {
                    throw new Exception("El idCatalogo no es valido.");
                }
                _repositorioCatalogo.DeleteCatalogo(idCatalogo);
                generalResponse = GeneralResponseFn.responseGeneral(Constantes.CODIGO_EXITO, Constantes.MENSAJE_OK, null);

            }
            catch (Exception ex)
            {
                generalResponse = GeneralResponseFn.responseGeneral(Constantes.CODIGO_ERROR, Constantes.getMensaje(ex.Message), null);
            }

            return generalResponse;
        }
    }
}
