using System;
using System.Collections.Generic;
using System.Text;
using Capa.BE;
using Capa.BE.Transporte.Request;
using Capa.BE.Transporte.Response;
using Capa.DAO;

namespace Capa.BL
{
    public class LoginBL
    {
        LoginDAO _instance = LoginDAO.GetInstance();

        public UsuarioResponse Autenticar(UsuarioRequest userRequest, string cnn)
        {
            return _instance.autenticar(userRequest, cnn);
        }
        /*public List<ProductoBE> goo(UsuarioRequest userRequest, string cnn)
        {
            return _instance.AddProductInUser(userRequest, cnn);
        }*/
    }
}
