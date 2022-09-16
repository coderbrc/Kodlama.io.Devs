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
    public class UserGithubRepository : EfRepositoryBase<UserGithub, BaseDbContext>, IUserGithubRepository
    {
        public UserGithubRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
