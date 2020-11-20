using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Capa.BE;
using Capa.BE.Transporte.Request;
using Capa.BE.Transporte.Response;

namespace Capa.DAO
{
    public class LoginDAO
    {
        //CONSTRUCTOR
        public LoginDAO() { }

        #region SINGLETON
        private static LoginDAO _instance = null;

        public static LoginDAO GetInstance()
        {
            if (_instance == null)
            {
                _instance = new LoginDAO();
            }
            return _instance;
        }
        #endregion

        #region CRUD
        public UsuarioResponse autenticar(UsuarioRequest userRequest, string cnn)
        {
            List<ProductoBE> lista = new List<ProductoBE>();
            UsuarioResponse u = null;
            try
            {
                using (SqlConnection objConection = new SqlConnection(cnn))
                {
                    using (SqlCommand objCommand = new SqlCommand("PA_GET_USER_AUTHENTICATION", objConection))
                    {
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.Add(new SqlParameter("@pi_user", SqlDbType.VarChar) { Value = userRequest.User });
                        objCommand.Parameters.Add(new SqlParameter("@pi_pass", SqlDbType.VarChar) { Value = userRequest.Pass });
                        objCommand.Connection.Open();
                        using (IDataReader dr = objCommand.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                //UsuarioResponse u = new UsuarioResponse();
                                u = new UsuarioResponse();
                                u.IdUsuario = dr.GetInt32(dr.GetOrdinal("IdUsuario"));
                                u.FirstName = dr.GetString(dr.GetOrdinal("FirstName"));
                                u.LastName = dr.GetString(dr.GetOrdinal("LastName"));
                                u.UserName = dr.GetString(dr.GetOrdinal("UserName"));
                                u.Email = dr.GetString(dr.GetOrdinal("Email"));
                                u.Productos = new List<ProductoBE>();
                                u.Productos.AddRange(AddProductInUser(userRequest, cnn));
                                //lista.Add(u);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return u;
        }
        private List<ProductoBE> AddProductInUser(UsuarioRequest userRequest, string cnn)
        {
            List<ProductoBE> lista = new List<ProductoBE>();
            try
            {
                using (SqlConnection objConection = new SqlConnection(cnn))
                {
                    using (SqlCommand objCommand = new SqlCommand("PA_GET_PRODUCTS_OF_USER", objConection))
                    {
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.Add(new SqlParameter("@pi_user", SqlDbType.VarChar) { Value = userRequest.User });
                        objCommand.Parameters.Add(new SqlParameter("@pi_pass", SqlDbType.VarChar) { Value = userRequest.Pass });
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
