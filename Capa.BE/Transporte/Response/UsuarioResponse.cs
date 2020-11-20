using System;
using System.Collections.Generic;
using System.Text;

namespace Capa.BE.Transporte.Response
{
    public class UsuarioResponse
    {
        public int IdUsuario { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public List<ProductoBE> Productos { get; set; }
    }
}
