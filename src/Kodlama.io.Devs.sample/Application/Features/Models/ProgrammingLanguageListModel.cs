using Application.Features.Dtos;
using corePackages.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models
{
    public class ProgrammingLanguageListModel:BasePageableModel
    {
        public IList<GetProgrammingLanguageListDto> Items { get; set; }
    }
}
