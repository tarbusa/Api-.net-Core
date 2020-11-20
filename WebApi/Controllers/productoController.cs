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
    public class productoController : ControllerBase
    {
        ProductoBL proBL = new ProductoBL();

        private readonly IConfiguration _config;

        public productoController(IConfiguration config)
        {
            _config = config;
        }

        // GET: api/producto
        [HttpGet]
        public IActionResult Get()
        {
            string cnn = _config.GetConnectionString("cnn");
            List<ProductoBE> lista = proBL.getProductoID("", cnn);
            return Ok(lista);
        }

        // GET: api/producto/5
        [HttpGet("{tipoCategoria}", Name = "GetCategoria")]
        public IActionResult GetCategoria(string tipoCategoria="")
        {
            string cnn = _config.GetConnectionString("cnn");
            List<ProductoBE> lista = proBL.getProductoID(tipoCategoria, cnn);
            return Ok(lista);
        }

        // POST: api/producto
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT: api/producto/5
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
