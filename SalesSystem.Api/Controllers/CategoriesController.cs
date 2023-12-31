﻿using Microsoft.AspNetCore.Authorization;
using SalesSystem.Modules.Categories.Domain.Dto;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using SalesSystem.Modules.Categories.Aplication.Create;
using SalesSystem.Modules.Categories.Aplication.Update;
using SalesSystem.Modules.Categories.Aplication.GetAll;
using SalesSystem.Modules.Categories.Aplication.Delete;
using SalesSystem.Modules.Categories.Aplication.GetById;

namespace SalesSystem.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CategoriesController : ApiController
    {
        private readonly ISender _mediator;

        public CategoriesController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            ErrorOr<IReadOnlyList<CategoryResponseDto>> categoryResult = await _mediator.Send(new GetAllCategoriesQuery());

            return categoryResult.Match
                (
                    categories => Ok(categories),
                    errors => Problem(errors)
                 );
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(Guid id)
        {
            ErrorOr<CategoryResponseDto> categoryResult = await _mediator.Send(new GetByIdCategoryQuery(id));

            return categoryResult.Match
                (
                    categories => Ok(categories),
                    errors => Problem(errors)
                 );
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] CreateCategoryCommand command)
        {
            ErrorOr<Unit> createResult = await _mediator.Send(command);

            return createResult.Match(categoryId => Ok(categoryId), errors => Problem(errors));
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCategoryCommand command)
        {
            if (id != command.Id)
            {
                List<Error> errors = new()
                {
                    Error.Validation("Category.UpdateInvalid", "The request Id does not match with the url Id")
                };

                return Problem(errors);
            }

            ErrorOr<Unit> updateResult = await _mediator.Send(command);

            return updateResult.Match(categoryId => NoContent(), errors => Problem(errors));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            ErrorOr<Unit> deleteResult = await _mediator.Send(new DeleteCategoryCommand(id));

            return deleteResult.Match(categoryId => NoContent(), errors => Problem(errors));
        }
    }
}
