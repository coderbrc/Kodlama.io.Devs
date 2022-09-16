using Application.Services.Repositories;
using corePackacges.CrossCuttingConcerns.Exceptions;
using corePackages.Persistence.Paging;
using corePackages.Security.Entities;
using corePackages.Security.Hashing;

namespace Application.Features.Users.Rules
{
    public class UserBusinessRules
    {
        private readonly IUserRepository _repository;

        public UserBusinessRules(IUserRepository repository)
        {
            _repository = repository;
        }

        public void UserShouldExist(User user)
        {
            if (user == null) throw new BusinessException("Kullanıcı yok");
        }

        public void UserCredentialsShouldMatch(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            var result = HashingHelper.VerifyPasswordHash(password, passwordHash, passwordSalt);
            if (!result) throw new BusinessException("Yanlış kimlik bilgileri");
        }

        public async Task EmailCanNotBeDuplicatedWhenInserted(string email)
        {
            var result = await _repository.GetAsync(u => u.Email.ToLower().Equals(email.ToLower()));
            if (result != null) throw new BusinessException("Bu e-posta adresi zaten kayıtlı");
        }
    }
}
