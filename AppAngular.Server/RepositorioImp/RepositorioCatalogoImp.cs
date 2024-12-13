using AppAngular.Server.Context;
using AppAngular.Server.Entities;
using Microsoft.Data.SqlClient;
using AppAngular.Server.Utils;
using AppAngular.Server.Repositorio;

namespace AppAngular.Server.RepositorioImp
{
    public class RepositorioCatalogoImp : IRepositorioCatalogo
    {
        private readonly SirmDbContext _context;
        public RepositorioCatalogoImp(SirmDbContext context)
        {
            _context = context;
        }

        //Get 
        public List<Catalogo> GetCatalogos()
        {
            try
            {
                return _context.Catalogo.ToList();
            }
            catch (SqlException ex)
            {
                throw new Exception(Constantes.getMensaje(ex.Message));
            }
            catch (Exception ex)
            {
                throw new Exception(Constantes.getMensaje(ex.Message));
            }
        }

        //Post
        public void SaveCatalogo(Catalogo catalogo) 
        {
            try
            {
                _context.Catalogo.Add(catalogo);
                _context.SaveChanges();
            }
            catch (SqlException ex)
            {
                throw new Exception(Constantes.getMensaje(ex.Message));
            }
            catch (Exception ex)
            {
                throw new Exception(Constantes.getMensaje(ex.Message));
            }
        }

        //Put
        public void UpdateCatalogo(string idCatalogo,Catalogo catalogo)
        {
            try
            {
                var updateCatalogo = _context.Catalogo.Find(idCatalogo);
                if (updateCatalogo != null)
                {
                    updateCatalogo.Descripcion = catalogo.Descripcion; 
                    updateCatalogo.Estado = catalogo.Estado;
                    _context.Catalogo.Update(updateCatalogo);
                    _context.SaveChanges();
                }                
            }
            catch (SqlException ex)
            {
                throw new Exception(Constantes.getMensaje(ex.Message));
            }
            catch (Exception ex)
            {
                throw new Exception(Constantes.getMensaje(ex.Message));
            }
        }

        //Delete
        public void DeleteCatalogo(string idCatalogo)
        {
            try
            {
                var catalogoRemove = _context.Catalogo.Find(idCatalogo);

                if (catalogoRemove != null)
                {
                    _context.Catalogo.Remove(catalogoRemove);
                    _context.SaveChanges();
                }                
            }
            catch (SqlException ex)
            {
                throw new Exception(Constantes.getMensaje(ex.Message));
            }
            catch (Exception ex)
            {
                throw new Exception(Constantes.getMensaje(ex.Message));
            }
        }

    }
}
