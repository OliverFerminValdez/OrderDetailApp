﻿using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using OrderDetailApp.DAL;
using OrderDetailApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OrderDetailApp.BLL
{
    public class OrdenesBLL
    {
        public static bool Guardar(Ordenes ordenes)
        {
            if (!Existe(ordenes.OrderId))
                return Insertar(ordenes);
            else
                return Modificar(ordenes);
        }

        public static bool Insertar(Ordenes ordenes)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {

                contexto.Ordenes.Add(ordenes);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static bool Modificar(Ordenes ordenes)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            var anterior = Buscar(ordenes.OrderId);

            try
            {
                
                foreach (var item in anterior.OrderDetail)
                {
                    if(!ordenes.OrderDetail.Exists(o => o.Id == item.Id))
                    {
                         contexto.Entry(item).State = EntityState.Deleted;
                    }
                    
                }

                foreach (var item in ordenes.OrderDetail)
                {
                    if(item.Id == 0)
                    {
                        contexto.Entry(item).State = EntityState.Added;
                    }
                    else
                    {
                        contexto.Entry(item).State = EntityState.Modified;
                    }
                }
                contexto.Entry(ordenes).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var ordenes = contexto.Ordenes.Find(id);

                if (ordenes != null)
                {
                    contexto.Ordenes.Remove(ordenes);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }
        public static Ordenes Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Ordenes ordenes;

            try
            {
                ordenes = contexto.Ordenes
                    .Where(e => e.OrderId == id)
                    .Include(e => e.OrderDetail)
                    .FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return ordenes;
        }

        public static List<Ordenes> GetList(Expression<Func<Ordenes, bool>> criterio)
        {
            List<Ordenes> lista = new List<Ordenes>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Ordenes.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Ordenes.Any(e => e.OrderId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }

        public static List<Ordenes> Getordenes()
        {
            List<Ordenes> lista = new List<Ordenes>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Ordenes.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
    }
}
