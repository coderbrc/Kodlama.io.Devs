using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingTechnologies.Dtos;
using corePackages.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingTechnologies.Models
{
    public class ProgrammingTechnologyListModel : BasePageableModel
    {
        public IList<GetProgrammingTechnologyListDto> Items { get; set; }
    }
}
