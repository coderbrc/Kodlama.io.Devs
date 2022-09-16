using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserGithubs.Dtos
{
    public class CreateUserGithubDto
    {
        public int Id { get; set; }
        public string GithubAddress { get; set; }
    }
}
