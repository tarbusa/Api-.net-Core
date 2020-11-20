using System;
using System.Collections.Generic;
using System.Text;
using Capa.BE;
using Capa.DAO;

namespace Capa.BL
{
    public class ProductoBL
    {
        ProductoDAO _instance = ProductoDAO.GetInstance();

        public List<ProductoBE> getProductoID(string tipoCategoria, string cnn)
        {
            return _instance.getProductoID(tipoCategoria, cnn);
        }
    }
}
