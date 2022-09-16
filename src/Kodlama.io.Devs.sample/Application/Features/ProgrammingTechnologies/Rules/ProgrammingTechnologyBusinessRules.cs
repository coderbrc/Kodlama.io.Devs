using Application.Features.Services.Repositories;
using Application.Services.Repositories;
using corePackacges.CrossCuttingConcerns.Exceptions;
using corePackages.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingTechnologies.Rules
{
    public class ProgrammingTechnologyBusinessRules
    {
        private readonly IProgrammingTechnologyRepository _repository;

        public ProgrammingTechnologyBusinessRules(IProgrammingTechnologyRepository repository)
        {
            _repository = repository;
        }
        public async Task TechnologyNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<ProgrammingTechnology> result = await _repository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException("Technology name exists.");
        }

        public void TechnologyShouldExistWhenRequested(Domain.Entities.ProgrammingTechnology programmingTechnology)
        {
            if (programmingTechnology == null) throw new BusinessException("Requested technology does not exist");
        }
    }
}
