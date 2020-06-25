using OrderDetailApp.BLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using OrderDetailApp.Models;

namespace OrderDetailApp.BLL.Tests
{
    [TestClass()]
    public class OrdenesBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Ordenes order = new Ordenes();
            order.Fecha = DateTime.Now;
            order.SuplidorId = 1;
            order.OrderDetail = new List<OrdenesDetalle>();
            order.Monto = 0;
            bool guardado = OrdenesBLL.Guardar(order);
            Assert.IsTrue(guardado);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            Ordenes ordenes = OrdenesBLL.Buscar(2);

            ordenes.SuplidorId = 2;

            bool modifico = OrdenesBLL.Modificar(ordenes);

            Assert.IsTrue(modifico);
        }

        [TestMethod()]
        public void EliminarTest()
        {

            bool Eliminado = OrdenesBLL.Eliminar(2);
            Assert.IsTrue(Eliminado);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Ordenes order = OrdenesBLL.Buscar(2);
            Assert.IsNotNull(order);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            bool existe = OrdenesBLL.Existe(1);
            Assert.IsTrue(existe);
        }

        [TestMethod()]
        public void GetordenesTest()
        {
            List<Ordenes> lista = OrdenesBLL.Getordenes();
            Assert.IsNotNull(lista);
        }
    }
}