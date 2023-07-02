using MediatR;
using Microsoft.AspNetCore.Mvc;
using SalesSystem.Categories.Aplication.Dto;
using SalesSystem.Categories.Aplication.Create;
using SalesSystem.Categories.Aplication.GetAll;

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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            ErrorOr.ErrorOr<IReadOnlyList<CategoryResponseDto>> categoryResult = await _mediator.Send(new GetAllCategoriesQuery());

            return categoryResult.Match
                (
                    categories => Ok(categories),
                    errors => Problem(errors)
                 );
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryCommand command)
        {
            ErrorOr.ErrorOr<Unit> createResult = await _mediator.Send(command);

            return createResult.Match(categoryId => Ok(categoryId), errors => Problem(errors));
        }
    }
}
