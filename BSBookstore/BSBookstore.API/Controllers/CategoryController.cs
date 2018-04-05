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
    public class CategoryController : ControllerBase
    {
        #region Attributes

        private readonly ICategoryService _service;

        #endregion

        #region Constructors

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Lista todas as categorias
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            var models = _service.GetAll();

            return new ObjectResult(models);
        }

        /// <summary>
        /// Busca uma categoria pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Cria ou atualiza uma categoria
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Save([FromBody] Category model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            _service.Insert(model);

            return Ok();
        }

        /// <summary>
        /// Exclui uma categoria
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _service.Delete(new Guid(id));

            return Ok();
        }

        #endregion
    }
}
