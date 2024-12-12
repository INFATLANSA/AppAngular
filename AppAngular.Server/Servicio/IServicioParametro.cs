using AppAngular.Server.Entities;
using AppAngular.Server.Utils;

namespace AppAngular.Server.Servicio
{
    public interface IServicioParametro
    {
        public GeneralResponse listaParametros();

        public GeneralResponse guardarParametro(Parametro parametro);
    }
}
