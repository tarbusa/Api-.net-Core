using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Capa.BE;

namespace Capa.DAO
{
    public class RegisterDAO
    {
        public RegisterDAO() { } //CONSTRUCTOR

        #region Singleton
        private static RegisterDAO _instance = null;

        public static RegisterDAO GetInstance()
        {
            if (_instance == null)
            {
                _instance = new RegisterDAO();
            }
            return _instance;
        }
        #endregion

        public bool CreateUser(UsuarioBE usuario, string cnn)
        {
            bool ok = false;
            try
            {
                using (SqlConnection objConection = new SqlConnection(cnn))
                {
                    using (SqlCommand objCommand = new SqlCommand("PA_CREATE_NEW_USER", objConection))
                    {
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.Add(new SqlParameter("@pi_firstName", SqlDbType.VarChar, 150) { Value = usuario.firstName });
                        objCommand.Parameters.Add(new SqlParameter("@pi_lastName", SqlDbType.VarChar, 150) { Value = usuario.lastName });
                        objCommand.Parameters.Add(new SqlParameter("@pi_userName", SqlDbType.VarChar, 150) { Value = usuario.userName });
                        objCommand.Parameters.Add(new SqlParameter("@pi_email", SqlDbType.VarChar, 150) { Value = usuario.email });
                        objCommand.Parameters.Add(new SqlParameter("@pi_pass", SqlDbType.VarChar, 256) { Value = usuario.pass });
                        objCommand.Connection.Open();
                        objCommand.ExecuteNonQuery();
                        ok = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ok;
        }
    }
}
