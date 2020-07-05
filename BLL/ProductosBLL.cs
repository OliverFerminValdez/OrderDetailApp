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
          public static bool Existe(int id)
        {
            Contexto db = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = db.Productos.Any(a => a.ProductoId == id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return encontrado;
        }
        public static bool Insertar(Productos Productos)
        {
            Contexto db = new Contexto();
            bool paso = false;

            try
            {
                db.Productos.Add(Productos);
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }
        public static bool Modificar(Productos Productos)
        {

            Contexto db = new Contexto();
            bool paso = false;

            try
            {
                db.Entry(Productos).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }
        public static bool Guardar(Productos Productos)
        {
            if (!Existe(Productos.ProductoId))
                return Insertar(Productos);
            else
                return Modificar(Productos);
        }
       
        public static bool Eliminar(int id)
        {

            Contexto db = new Contexto();
            bool paso = false;

            try
            {
                var encontrado = db.Productos.Find(id);
                db.Productos.Remove(encontrado);
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }
       
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
