using MediatR;
using WebApplicationApi.Domain.Entities;
using WebApplicationApi.Infrastructure.Data.Queries.cs;

namespace WebApplicationApi.Infrastructure.Data
{
    public class CategoryRepository
    {
        private readonly IMediator _mediator;

        public CategoryRepository(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _mediator.Send(new GetAllCategories.Categories());
        }
        public async Task AddCategory(Category category)
        {
            var command = new AddCategory.ExecuteCategory
            {
                CategoryName = category.CategoryName
            };
            await _mediator.Send(command);
        }
        public async Task UpdateCategory(Category category, int id)
        {
            await _mediator.Send(new UpdateCategory.ExecuteCategory { CategoryName = category.CategoryName, CategoryId = id });
        }
        public async Task DeleteCategory(int id)
        {
           await _mediator.Send(new DeleteCategory.ExecuteCategory {  CategoryId = id });
        }
    }
}
