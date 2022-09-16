using corePackages.Persistence.Repositories;
using corePackages.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Repositories
{
    public interface IUserOperationClaimRepository:IRepository<UserOperationClaim>,IAsyncRepository<UserOperationClaim>
    {
    }
}
