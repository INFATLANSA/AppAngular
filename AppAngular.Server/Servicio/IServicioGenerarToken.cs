namespace AppAngular.Server.Servicio
{
    public interface IServicioGenerarToken
    {
        public string GenerateJwtToken(string username);
    }
}
