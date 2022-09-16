using corePackages.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserGithub : Entity
    {
        public int UserofCreateId { get; set; }
        public string GithubAdress { get; set; }
        public virtual UserofCreate UserofCreate { get; set; }
        public UserGithub()
        {
        }
        public UserGithub(int userofCreateId, string githubAdress) : this()
      => (UserofCreateId, GithubAdress) = (userofCreateId, githubAdress);
    }
}
