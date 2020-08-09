using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using JREM.API.Rest.Core;
using JREM.API.Rest.Models;

namespace JREM.API.Rest.Data
{
    public class DataEngine
    {
        public MethodResponse<DataSet> GetProducts()
        {
            var data = new DataSet();
            var response = new MethodResponse<DataSet>();
            try
            {
                //using (var Conn = new SqlConnection("Data Source=LAPTOP-3NQVU8F1\\SQLEXPRESS;Initial Catalog=Store;Integrated Security=True;"))
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    conn.Open();

                    using (var sqlCmmnd = new SqlCommand("dbo.spGetProducts", conn))
                    {
                        var dataAdapter = new SqlDataAdapter();
                        dataAdapter.SelectCommand = sqlCmmnd;
                        dataAdapter.Fill(data);

                        response.Code = 0;
                        response.Result = data;
                    }
                }
                return response;
            }
            catch (Exception ex)
            {
                return new MethodResponse<DataSet>() { Code = -1, Message = "Error al extraer los datos: " + ex.Message };
            }         
        }

        public MethodResponse<bool> InsProduct(object product)
        {
            var response = new MethodResponse<bool>();
            try
            {
                var data = (Product)product;

                using (var Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    Conn.Open();
                    
                    using (var sqlCmnd = new SqlCommand("dbo.spInsProducts", Conn))
                    {
                        sqlCmnd.CommandType = CommandType.StoredProcedure;

                        sqlCmnd.Parameters.AddWithValue("@nombre", data.Nombre);
                        sqlCmnd.Parameters.AddWithValue("@descrip", data.Descripcion);
                        sqlCmnd.Parameters.AddWithValue("@marca", data.Marca);
                        sqlCmnd.Parameters.AddWithValue("@precio", data.Precio);
                        sqlCmnd.Parameters.AddWithValue("@stock", data.Stock);

                        sqlCmnd.ExecuteNonQuery();

                        sqlCmnd.Parameters.Clear();
                    }
                }
                response.Code = 0;
                response.Result = true;

                return response;
            }
            catch (Exception ex)
            {
                return new MethodResponse<bool>() { Code = -1, Message = "Error al insertar los datos: " + ex.Message, Result = false};
            }
        }

        public MethodResponse<bool> UpdateProduct(object product)
        {
            var response = new MethodResponse<bool>();
            try
            {
                var data = (Product)product;

                using (var Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    Conn.Open();

                    using (var sqlCmnd = new SqlCommand("dbo.spUpdateProducts", Conn))
                    {
                        sqlCmnd.CommandType = CommandType.StoredProcedure;

                        sqlCmnd.Parameters.AddWithValue("@nombre", data.Nombre);
                        sqlCmnd.Parameters.AddWithValue("@descrip", data.Descripcion);
                        sqlCmnd.Parameters.AddWithValue("@marca", data.Marca);
                        sqlCmnd.Parameters.AddWithValue("@precio", data.Precio);
                        sqlCmnd.Parameters.AddWithValue("@stock", data.Stock);
                        sqlCmnd.Parameters.AddWithValue("@id", data.Id);

                        sqlCmnd.ExecuteNonQuery();

                        sqlCmnd.Parameters.Clear();
                    }
                }
                response.Code = 0;
                response.Result = true;

                return response;
            }
            catch (Exception ex)
            {
                return new MethodResponse<bool>() { Code = -1, Message = "Error al actualizar los datos: " + ex.Message, Result = false };
            }
        }

        public MethodResponse<bool> DeleteProduct (object product)
        {
            var response = new MethodResponse<bool>();
            try
            {
                var data = (Product)product;

                using (var Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    Conn.Open();

                    using (var sqlCmnd = new SqlCommand("dbo.spDeleteProducts", Conn))
                    {
                        sqlCmnd.CommandType = CommandType.StoredProcedure;

                        sqlCmnd.Parameters.AddWithValue("@idpro", data.Id);

                        sqlCmnd.ExecuteNonQuery();

                        sqlCmnd.Parameters.Clear();
                    }
                }
                response.Code = 0;
                response.Result = true;

                return response;
            }
            catch (Exception ex)
            {
                return new MethodResponse<bool>() { Code = -1, Message = "Error al eliminar los datos: " + ex.Message, Result = false };
            }
        }


    }
}
