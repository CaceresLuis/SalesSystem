using MediatR;
using Microsoft.AspNetCore.Mvc;
using SalesSystem.Categories.Aplication.Create;

namespace SalesSystem.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : ApiController
    {
        private readonly ISender _mediator;

        public CategoriesController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryCommand command)
        {
            ErrorOr.ErrorOr<Unit> createResult = await _mediator.Send(command);

            return createResult.Match(categoryId => Ok(categoryId), errors => Problem(errors));
        }
    }
}
