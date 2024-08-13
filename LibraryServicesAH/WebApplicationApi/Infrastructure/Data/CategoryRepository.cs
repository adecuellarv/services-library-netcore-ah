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

        public Task AddCategory(Category category) => throw new Exception("WIP");
        public Task UpdateCategory(Category category) => throw new Exception("WIP");
        public Task DeleteCategory(int id) => throw new Exception("WIP");
    }
}
