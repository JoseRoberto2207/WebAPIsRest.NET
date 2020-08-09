using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JREM.API.Rest.Web;
using JREM.API.Rest.Web.Controllers;
using System.Web.UI.WebControls;
using JREM.API.Rest.Models;

namespace JREM.API.Rest.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void GetAllProducts()
        {
            // Disponer
            StoreController controller = new StoreController();
            // Actuar

            //AGetAllProducts
            //var res = controller.GetAllProducts();

            var product = new Product()
            {
                Nombre = "Carlos V",
                Descripcion = "Chocolate",
                Marca = "Carlos Quinto",
                Precio = 20.00,
                Stock = 50,
                Id = 7
            };
            //PostProduct
            var res = controller.PostProduct(product);

            //PutProduct
            //var res = controller.PutProduct(product);

            //DeleteProduct
            //var res = controller.DeleteProduct(product);
        }


        //[TestMethod]
        //public void Index()
        //{
        //    // Disponer
        //    HomeController controller = new HomeController();

        //    // Actuar
        //    ViewResult result = controller.Index() as ViewResult;

        //    // Declarar
        //    Assert.IsNotNull(result);
        //    Assert.AreEqual("Home Page", result.ViewBag.Title);
        //}
    }
}
