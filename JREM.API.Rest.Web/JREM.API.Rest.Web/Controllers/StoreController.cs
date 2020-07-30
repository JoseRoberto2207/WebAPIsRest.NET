using System;
using System.Web.Http;
using System.Web.Routing;
using JREM.API.Rest.Core;
using JREM.API.Rest.Models;
using JREM.API.Rest.Logic;
using System.Collections.Generic;

namespace JREM.API.Rest.Web.Controllers
{    
    public class StoreController : ApiController
    {   
        [Route("Api/Store/GetAllProducts")]
        public MethodResponse<List<Product>> GetAllProducts()
        {
            var response = new MethodResponse<List<Product>>();
            try
            {
                var logicEngine = new LogicEngine();
                var logic = logicEngine.GetProducts();

                if (int.Parse(logic.Code.ToString()) != 0)
                {
                    return new MethodResponse<List<Product>>() { Code = logic.Code, Message = logic.Message };
                }

                response.Code = 0;
                response.Result = logic.Result;

                return response;
            }
            catch (Exception ex)
            {
                return new MethodResponse<List<Product>>() { Code = -1, Message = "Ocurrio un error al extraer los productos: " + ex.Message };
            }            
        }
        
        [Route("Api/Store/GetProductByName/{Nombre}")]
        public MethodResponse<Product> GetProductByName(string Nombre)
        {
            var response = new MethodResponse<Product>();
            try
            {
                var logic = new LogicEngine();
                var res = logic.GetProductByName(Nombre);

                if(int.Parse(res.Code.ToString()) != 0)
                {
                    return new MethodResponse<Product>() { Code = res.Code, Message = res.Message };
                }
                response = res;

                return response;
            }
            catch (Exception ex)
            {
                return new MethodResponse<Product>() { Code = -1, Message = "Ocurrio un error al extraer el producto: " + ex.Message };
            }
        }
        
        [Route("Api/Store/InsProduct")]
        public MethodResponse<string> PostProduct(object infoProduct)
        {
            var response = new MethodResponse<string>();
            try
            {
                var logic = new LogicEngine();
                var res = logic.InsProduct(infoProduct);

                if (int.Parse(res.Code.ToString()) != 0)
                {
                    return new MethodResponse<string>() { Code = res.Code, Message = res.Message };
                }
                response = res;

                return response;
            }
            catch (Exception ex)
            {
                return new MethodResponse<string>() { Code = -1, Message = "Ocurrio un error al insertar los productos: " + ex.Message };
            }
        }
        
        [Route("Api/Store/UpdateProduct")]
        public MethodResponse<string> PutProduct(object infoProduct)
        {
            var response = new MethodResponse<string>();
            try
            {
                var logic = new LogicEngine();
                var res = logic.UpdateProduct(infoProduct);

                if (int.Parse(res.Code.ToString()) != 0)
                {
                    return new MethodResponse<string>() { Code = res.Code, Message = res.Message };
                }
                response = res;

                return response;
            }
            catch (Exception ex)
            {
                return new MethodResponse<string>() { Code = -1, Message = "Ocurrio un error al actualizar los productos: " + ex.Message };
            }
        }
        
        [Route("Api/Store/DeleteProduct")]
        public MethodResponse<string> DeleteProduct(object infoProduct)
        {
            var response = new MethodResponse<string>();
            try
            {
                var logic = new LogicEngine();
                var res = logic.DeleteProduct(infoProduct);

                if (int.Parse(res.Code.ToString()) != 0)
                {
                    return new MethodResponse<string>() { Code = res.Code, Message = res.Message };
                }
                response = res;

                return response;
            }
            catch (Exception ex)
            {
                return new MethodResponse<string>() { Code = -1, Message = "Ocurrio un error al eliminar los productos: " + ex.Message };
            }
        }

    }
}
