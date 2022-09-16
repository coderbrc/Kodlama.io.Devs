using Application.Features.Services.Repositories;
using corePackacges.CrossCuttingConcerns.Exceptions;
using corePackages.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserGithubs.Rules
{
    public class UserGithubBusinessRules
    {

        private readonly IUserGithubRepository _repository;

        public UserGithubBusinessRules(IUserGithubRepository repository)
        {
            _repository = repository;
        }
        public async Task TechnologyNameCanNotBeDuplicatedWhenInserted(string githubAdress)
        {
            IPaginate<UserGithub> result = await _repository.GetListAsync(b => b.GithubAdress == githubAdress);
            if (result.Items.Any()) throw new BusinessException("Github Adress already exists.");
        }

    }
}
