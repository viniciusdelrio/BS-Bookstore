using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSBookstore.Domain.Contract;
using BSBookstore.Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace BSBookstore.API.Controllers
{
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        #region Attributes

        private readonly IBookService _service;

        #endregion

        #region Constructors

        public BookController(IBookService service)
        {
            _service = service;
        }

        #endregion

        #region Methods

        [HttpGet]
        public IActionResult GetAll()
        {
            var models = _service.GetAll();

            return new ObjectResult(models);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var model = _service.Get(new Guid(id));

            if (model == null)
            {
                return NotFound();
            }

            return new ObjectResult(model);
        }

        [HttpPost]
        public IActionResult Save([FromBody] Book model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            _service.Insert(model);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _service.Delete(new Guid(id));

            return Ok();
        }

        #endregion
    }
}
