using Application.Features.Services.Repositories;
using corePackages.Persistence.Repositories;
using Domain.Entities;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class ProgrammingTechnologyRepository : EfRepositoryBase<ProgrammingTechnology, BaseDbContext>, IProgrammingTechnologyRepository
    {
        public ProgrammingTechnologyRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
