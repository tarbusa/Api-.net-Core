using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Capa.BE;

namespace Capa.DAO
{
    public class ProductoDAO
    {
        public ProductoDAO() { }

        #region SINGLETON
        private static ProductoDAO _instance = null;

        public static ProductoDAO GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ProductoDAO();
            }
            return _instance;
        }
        #endregion

        #region CRUD
        public List<ProductoBE> getProductoID(string tipoCategoria, string cnn)
        {
            List<ProductoBE> lista = new List<ProductoBE>();
            try
            {
                using (SqlConnection objConection = new SqlConnection(cnn))
                {
                    using (SqlCommand objCommand = new SqlCommand("PA_GET_PRODUCTOS_FILTER", objConection))
                    {
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.Add(new SqlParameter("@pi_tipo", SqlDbType.VarChar) { Value = tipoCategoria });
                        objCommand.Connection.Open();
                        using (IDataReader dr = objCommand.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                ProductoBE u = new ProductoBE();
                                u.IdProducto = dr.GetInt32(dr.GetOrdinal("IdProducto"));
                                u.Nombre = dr.GetString(dr.GetOrdinal("Producto"));
                                u.Modelo = dr.GetString(dr.GetOrdinal("Modelo"));
                                u.Precio = dr.GetInt32(dr.GetOrdinal("Precio"));
                                u.Imagen = dr.GetString(dr.GetOrdinal("Imagen"));
                                lista.Add(u);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }
        #endregion

    }
}
