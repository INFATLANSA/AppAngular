﻿using AppAngular.Server.Context;
using AppAngular.Server.Entities;
using AppAngular.Server.Repositorio;
using Microsoft.Data.SqlClient;

namespace AppAngular.Server.RepositorioImp
{
    //Consultas para la tabla de Parametro. Para exponerlo por una interface IRepositorioParametro.
    public class RepositorioParametroImp : IRepositorioParametro
    {
        //Inyectar el contexto de la db en el constructor de la clase.
        private readonly SirmDbContext _context;

        public RepositorioParametroImp(SirmDbContext context)
        {
            _context = context;
        }

        //Consulta de Parametro. Todas las excepciones relacionadas con la base de datos se deben programar aquí.
        public List<Parametro> GetParametroList() 
        {
            try
            {
                return _context.Parametro.ToList();
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
