using corePackages.Persistence.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Services.Repositories
{
    public interface IUserGithubRepository:IAsyncRepository<UserGithub>,IRepository<UserGithub>
    {
    }
}
