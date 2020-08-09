using System;
using System.Data;
using JREM.API.Rest.Core;
using JREM.API.Rest.Models;
using JREM.API.Rest.Data;
using System.Collections.Generic;

namespace JREM.API.Rest.Logic
{
    public class LogicEngine
    {
        public MethodResponse<List<Product>> GetProducts()
        {
            var listProducts = new List<Product>();
            var response = new MethodResponse<List<Product>>();
            try
            {
                var data = new DataEngine();
                var dataSet = (DataSet)data.GetProducts().Result;
                
                foreach (DataTable table in dataSet.Tables)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        var products = new Product()
                        {
                            Nombre = dr["Nombre"].ToString(),
                            Descripcion = dr["Descripcion"].ToString(),
                            Marca = dr["Marca"].ToString(),
                            Precio = double.Parse(dr["Precio"].ToString()),
                            Stock = int.Parse(dr["Stock"].ToString())
                        };
                        listProducts.Add(products);
                    }
                }
                response.Code = 0;
                response.Result = listProducts;

                return response;
            }
            catch (Exception ex)
            {
                return new MethodResponse<List<Product>>() { Code = -1, Message = "Error al procesar los datos: " + ex.Message };
            }            
        }

        public MethodResponse<Product> GetProductByName(string nombre)
        {
            var lstproduct = new List<Product>();
            var response = new MethodResponse<Product>();
            try
            {
                var data = new DataEngine();
                var dataset = (DataSet)data.GetProducts().Result;

                foreach (DataTable table in dataset.Tables)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        var product = new Product()
                        {
                            Nombre = row["Nombre"].ToString(),
                            Descripcion = row["Descripcion"].ToString(),
                            Marca = row["Marca"].ToString(),
                            Precio = double.Parse(row["Precio"].ToString()),
                            Stock = int.Parse(row["Stock"].ToString())
                        };                    

                        if(product.Nombre == nombre)
                        {
                            lstproduct.Add(product);
                        }
                    }
                }
                if (lstproduct.Count == 0)
                {
                    return new MethodResponse<Product>() { Code = -1, Message = "No existe el producto con ese nombre" };
                }
                response.Code = 0;
                response.Result = lstproduct;

                return response;
            }
            catch (Exception ex)
            {
                return new MethodResponse<Product>() { Code = -1, Message = "Error al procesar los datos: " + ex.Message };
            }
        }

        public MethodResponse<string> InsProduct(object infoProduct)
        {
            var response = new MethodResponse<string>();
            try
            {
                var data = new DataEngine();             

                if (infoProduct != null)
                {             
                    var res = data.InsProduct(infoProduct);

                    if ((int)res.Code != 0 && (bool)res.Result == false)
                    {
                        return new MethodResponse<string>() { Code = res.Code, Message = res.Message };
                    }
                }
                response.Code = 0;
                response.Message = "Se inserto correctamente el producto";

                return response;
            }
            catch (Exception ex)
            {
                return new MethodResponse<string>() { Code = -1, Message = "Error al procesar los datos: " + ex.Message};
            }
        }

        public MethodResponse<string> UpdateProduct(object infoProduct)
        {
            var response = new MethodResponse<string>();
            try
            {
                var dataEngine = new DataEngine();
                var res = dataEngine.UpdateProduct(infoProduct);

                if (int.Parse(res.Code.ToString()) != 0 && (bool)res.Result == false)
                {
                    return new MethodResponse<string>() { Code = res.Code, Message = res.Message };
                }
                response.Code = 0;
                response.Message = "Se actualizo correctamente el producto";

                return response;
            }
            catch (Exception ex)
            {
                return new MethodResponse<string>() { Code = -1, Message = "Error al procesar los datos: " + ex.Message };
            }
        }

        public MethodResponse<string> DeleteProduct(object infoProduct)
        {
            var response = new MethodResponse<string>();
            try
            {
                var dataEngine = new DataEngine();
                var res = dataEngine.DeleteProduct(infoProduct);

                if (int.Parse(res.Code.ToString()) != 0 && (bool)res.Result == false)
                {
                    return new MethodResponse<string>() { Code = res.Code, Message = res.Message };
                }
                response.Code = 0;
                response.Message = "Se elimino correctamente el producto";

                return response;
            }
            catch (Exception ex)
            {
                return new MethodResponse<string>() { Code = -1, Message = "Error al procesar los datos: " + ex.Message };
            }
        }
    }
}
