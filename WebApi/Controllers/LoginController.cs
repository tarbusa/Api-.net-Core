using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capa.BE;
using Capa.BE.Transporte.Request;
using Capa.BE.Transporte.Response;
using Capa.BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        LoginBL logBL = new LoginBL();

        private readonly IConfiguration _config;

        public LoginController(IConfiguration config)
        {
            _config = config;
        }

        // GET: api/Login
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Login/5
        [HttpGet("{id}", Name = "Geth")]
        public string Geth(int id)
        {
            return "value";
        }

        // POST: api/Login
        [HttpPost]
        public IActionResult autenticar([FromBody] UsuarioRequest userRequest)
        {
            string cnn = _config.GetConnectionString("cnn");
            UsuarioResponse respuesta = logBL.Autenticar(userRequest, cnn);
            //List<ProductoBE> respuesta = logBL.goo(userRequest, cnn);
            return Ok(respuesta);
        }

        // PUT: api/Login/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
