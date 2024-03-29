using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.Extensions.DependencyInjection;


namespace API.Controllers
{
     [ApiController]
     [Route("api/[controller]")]

    public class BaseApiController : ControllerBase
    {
       //making mediaTR accessible cross the application
       private IMediator _mediator;

       protected IMediator Mediator => _mediator ??= HttpContext.RequestServices
          .GetService<IMediator>();
    }
}