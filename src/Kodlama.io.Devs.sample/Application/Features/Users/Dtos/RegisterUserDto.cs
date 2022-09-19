using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core.Tokenizer;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Dtos
{
    public class RegisterUserDto
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
