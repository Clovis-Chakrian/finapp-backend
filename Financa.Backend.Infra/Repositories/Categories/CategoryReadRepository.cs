using Financa.Backend.BuildingBlocks.Data.Repositories.Read;
using Financa.Backend.Domain.Categories;
using Financa.Backend.Infra.Contexts;

namespace Financa.Backend.Infra.Repositories.Categories;

public class CategoryReadRepository(FinAppDbContext context) : ReadRepository<Category, Guid, FinAppDbContext>(context)
{
  
}