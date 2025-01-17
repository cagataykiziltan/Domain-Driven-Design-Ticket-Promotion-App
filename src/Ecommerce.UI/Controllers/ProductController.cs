﻿using Microsoft.AspNetCore.Mvc;
using Ecommence.Application.Common.Interfaces;
using Ecommence.Application.ProductServices;
using Ecommence.Infrastructure.Http;
using System.Net;
using System.Threading.Tasks;

namespace TicketTypePromotion.UI.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
      
        [HttpPost("CreateProduct")]
        [ProducesResponseType(typeof(HttpResponseObjectSuccess<ProductDto>), (int)HttpStatusCode.OK),
         ProducesResponseType(typeof(HttpResponseObjectError<ProductDto>), (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<HttpResponseObject<ProductDto>>> CreateProduct(HttpRequestObject<ProductDto> product)
        {
           var ticketTypeDto = await _productService.CreateProduct(product.Items.First());
           
            return Ok(ticketTypeDto);
        }

        [HttpGet("GetProductInfo/{ticketTypeName}")]
        [ProducesResponseType(typeof(HttpResponseObjectSuccess<ProductDto>), (int)HttpStatusCode.OK),
         ProducesResponseType(typeof(HttpResponseObjectError<ProductDto>), (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<HttpResponseObject<ProductDto>>> GetProductInfo(HttpRequestObject<string> productName)
        {
            var ticketDto = await _productService.GetProduct(productName.Items.First());

            return Ok(ticketDto);
        }

    }
}
