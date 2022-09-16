using corePackages.Persistence.Repositories;
using Domain.Entities;

namespace Application.Features.Services.Repositories
{
    public interface IProgrammingTechnologyRepository: IRepository<ProgrammingTechnology>,IAsyncRepository<ProgrammingTechnology>
    {
    }
}
