using CoreTest.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreTest.Controllers
{
    [Route("api/[Controller]")]
    public class ProductsController : Controller
    {
        private readonly ICoreRepository _repository;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ICoreRepository repository, 
            ILogger<ProductsController> logger )
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_repository.GetAllProducts());
            }
            catch(Exception ex)
            {
                _logger.LogError($"Failed to get error {ex}");
                return BadRequest("Failed to get Products");
            }

        }
    }
}
