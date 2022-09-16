using Application.Features.ProgrammingLanguages.Dtos;
using corePackages.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Models
{
    public class ProgrammingLanguageListModel:BasePageableModel
    {
        public IList<GetProgrammingLanguageListDto> Items { get; set; }
    }
}
