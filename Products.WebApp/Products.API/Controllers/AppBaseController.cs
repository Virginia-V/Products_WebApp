using Microsoft.AspNetCore.Mvc;
using Products.Common.Dtos;

namespace Products.API.Controllers
{
    [ApiController]
    public abstract class AppBaseController : ControllerBase
    {
        private readonly ILogger _logger;
        protected AppBaseController(ILogger logger)
        {
            _logger = logger;
        }

        protected async Task<IActionResult> HandleAsync<TResult>(Func<Task<TResult>> resultFunc)
        {
            try
            {
                var result = await resultFunc();
                return Ok(new ResponseDto<TResult> { Succeeded = true, Result = result });
            }
            catch (Exception ex)
            {
                return GeneralExceptionResult(ex);
            }
        }

        protected async Task<IActionResult> HandleAsync(Func<Task> resultFunc)
        {
            try
            {
                await resultFunc();
                return Ok(new ResponseDto<object> { Succeeded = true });
            }
            catch (Exception ex)
            {
                return GeneralExceptionResult(ex);
            }
        }

        private IActionResult GeneralExceptionResult(Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(500, "Something Went Wrong, pleasy try later!");
        }     
    }
}
