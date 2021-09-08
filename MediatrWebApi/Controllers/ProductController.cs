using MediatR;
using MediatrBusiness.MediatR.Command.Product;
using MediatrBusiness.MediatR.Query.Product;
using MediatrEntity.Dto.Product;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MediatrWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("GetProductList")]
        public async Task<ActionResult> GetProductList()
        {
            try
            {
                var query = new GetProductListQuery();
                var result = await _mediator.Send(query);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetProductById/{productId:int}")]
        public async Task<ActionResult> GetProductById(int productId)
        {
            try
            {
                var query = new GetProductByIdQuery(productId);
                var result = await _mediator.Send(query);
                if (result.Message != null)
                    return Ok(new { code = result.ResultCode, message = result.Message, type = result.ResultType });

                return Ok(new { code = result.ResultCode, result = result.Result, type = result.ResultType });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("AddProduct")]
        public async Task<ActionResult> AddProduct(AddProductDto productDto)
        {
            try
            {
                var command = new AddProductCommand(productDto);
                var result = await _mediator.Send(command);
                return Ok(new { code = result.ResultCode, message = result.Message, type = result.ResultType });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateProduct")]
        public async Task<ActionResult> UpdateProduct(UpdateProductDto productDto)
        {
            try
            {
                var command = new UpdateProductCommand(productDto);
                var result = await _mediator.Send(command);
                return Ok(new { code = result.ResultCode, message = result.Message, type = result.ResultType });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteProduct/{productId:int}")]
        public async Task<ActionResult> DeleteProduct(int productId)
        {
            try
            {
                var command = new DeleteProductCommand(productId);
                var result = await _mediator.Send(command);
                return Ok(new { code = result.ResultCode, message = result.Message, type = result.ResultType });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
