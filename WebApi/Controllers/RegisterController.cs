using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capa.BE;
using Capa.BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        RegisterBL registerBL = new RegisterBL();

        private readonly IConfiguration _config;

        public RegisterController(IConfiguration config)
        {
            _config = config;
        }

        // GET: api/Register
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Register/5
        [HttpGet("{id}", Name = "Gett")]
        public string Gett(int id)
        {
            return "value";
        }

        // POST: api/Register
        [HttpPost]
        public IActionResult Usuario([FromBody] UsuarioBE usuario)
        {
            string cnn = _config.GetConnectionString("cnn");
            bool ok = registerBL.CreateUser(usuario, cnn);
            if (ok){
                registerBL.enviarCorreo(usuario);
            }
            return Ok(ok);
        }

        // PUT: api/Register/5
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
