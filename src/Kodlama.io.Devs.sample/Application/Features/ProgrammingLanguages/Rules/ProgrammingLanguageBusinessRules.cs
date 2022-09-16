using Application.Services.Repositories;
using corePackacges.CrossCuttingConcerns.Exceptions;
using corePackages.Persistence.Paging;
namespace Application.Features.ProgrammingLanguages.Rules
{
    public class ProgrammingLanguageBusinessRules
    {
        private readonly IProgrammingLanguageRepository _repository;

        public ProgrammingLanguageBusinessRules(IProgrammingLanguageRepository repository)
        {
            _repository = repository;
        }
        public async Task LanguageNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<Domain.Entities.ProgrammingLanguage> result = await _repository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException("Language name exists.");
        }

        public void LanguageShouldExistWhenRequested(Domain.Entities.ProgrammingLanguage programmingLanguage)
        {
            if (programmingLanguage == null) throw new BusinessException("Requested language does not exist");
        }
    }
}
