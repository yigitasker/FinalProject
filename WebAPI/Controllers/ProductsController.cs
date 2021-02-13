using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]                        // => Attribute
    public class ProductsController : ControllerBase
    {
        // Gevşek bağlılık = bir bağımlılık var ama soyuta bağımlılık var.
        // naming convention  somut referans gerekli
        // IoC Container -- Inversion of control => bellekteki bir yer ve buraya bir tane new ProductManager, EfProductDal gibi referanslar koyayım ve ihtiyaç anında bunlar kullanılsın demek.
        IProductService _productService;

        public ProductsController(IProductService productService)                   // ProductsController new lendiğinde IProductService implemenent i vericez.
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
        
            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }


        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {

            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }




        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }



    }
}
