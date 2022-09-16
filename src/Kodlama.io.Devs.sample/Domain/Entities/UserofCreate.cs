using corePackages.Security.Entities;
using corePackages.Security.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserofCreate:User
    {
        public virtual ICollection<UserGithub> UserGithubs { get; set; }
        public UserofCreate()
        {
        }
        public UserofCreate(int id, string firstName, string lastName, string email, byte[] passwordSalt, byte[] passwordHash, bool status, AuthenticatorType authenticatorType, int socialsId) : base(id, firstName, lastName, email, passwordSalt, passwordHash, status, authenticatorType)
        {

        }
    }
}
