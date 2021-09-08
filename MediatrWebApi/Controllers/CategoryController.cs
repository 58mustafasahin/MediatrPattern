using MediatR;
using MediatrBusiness.MediatR.Command.Category;
using MediatrBusiness.MediatR.Query.Category;
using MediatrEntity.Dto.Category;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MediatrWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("GetCategoryList")]
        public async Task<ActionResult> GetCategoryList()
        {
            try
            {
                var query = new GetCategoryListQuery();
                var result = await _mediator.Send(query);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetCategoryById/{categoryId:int}")]
        public async Task<ActionResult> GetCategoryById(int categoryId)
        {
            try
            {
                var query = new GetCategoryByIdQuery(categoryId);
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
        [Route("AddCategory")]
        public async Task<ActionResult> AddCategory(AddCategoryDto categoryDto)
        {
            try
            {
                var command = new AddCategoryCommand(categoryDto);
                var result = await _mediator.Send(command);
                return Ok(new { code = result.ResultCode, message = result.Message, type = result.ResultType });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateCategory")]
        public async Task<ActionResult> UpdateCategory(UpdateCategoryDto categoryDto)
        {
            try
            {
                var command = new UpdateCategoryCommand(categoryDto);
                var result = await _mediator.Send(command);
                return Ok(new { code = result.ResultCode, message = result.Message, type = result.ResultType });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteCategory/{categoryId:int}")]
        public async Task<ActionResult> DeleteCategory(int categoryId)
        {
            try
            {
                var command = new DeleteCategoryCommand(categoryId);
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
