using OrderDetailApp.DAL;
using OrderDetailApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderDetailApp.BLL
{
    public class ProductosBLL
    {
        public static Productos Buscar(int id)
        {
            Contexto db = new Contexto();
            Productos p = new Productos();
            try
            {
                p = db.Productos.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return p;
        }
        public static List<Productos> GetProductos()
        {
            Contexto contexto = new Contexto();
            List<Productos> productos = new List<Productos>();
            try
            {
                productos = contexto.Productos.ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return productos;
        }
    }
}
