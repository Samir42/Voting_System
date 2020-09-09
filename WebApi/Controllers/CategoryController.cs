using Application.Dtos.Category;
using Application.Features.CategoryFeatures.Commands;
using Application.Features.CategoryFeatures.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Controllers.Base;

using static Application.Dtos.Category.CategoryDto;
using static CommonInfrastructure.Utility.ValidationConstants;
namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryForCreationDto categoryForCreationDto)
        {
            var validationErrors = categoryForCreationDto.Validate();

            if (validationErrors.Any())
            {
                return ValidationProblem(validationErrors.First());
            }

            var categoriesFromQueryHandler = await Mediator.Send(new GetAllCategoriesQuery());

            var categoryFromMemory = categoriesFromQueryHandler.FirstOrDefault(x => x.Name == categoryForCreationDto.Name) ?? EmptyCategory;

            if (categoryFromMemory != EmptyCategory)
            {
                return ValidationProblem(CONFLICT_WITH_EXISTING_CATEGORY);
            }


            var categoryToReturn = await Mediator.Send(new CreateCategoryCommand(categoryForCreationDto));


            return CreatedAtRoute(new { categoryId = categoryToReturn.Id },
                                 categoryToReturn);
        }
    }
}
