using Financa.Backend.BuildingBlocks.Data.Repositories.Write;
using Financa.Backend.Domain.Categories;
using Financa.Backend.Infra.Contexts;

namespace Financa.Backend.Infra.Repositories.Categories;

public class CategoryWriteRepository(FinAppDbContext context) : WriteRepository<Category, Guid, FinAppDbContext>(context)
{

}