using OrderDetailApp.DAL;
using OrderDetailApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderDetailApp.BLL
{
    public class SuplidoresBLL
    {
        public static List<Suplidores> GetSuplidores()
        {
            Contexto contexto = new Contexto();
            List<Suplidores> suplidores = new List<Suplidores>();
            try
            {
                suplidores = contexto.Suplidores.ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return suplidores;
        }
    }
}
