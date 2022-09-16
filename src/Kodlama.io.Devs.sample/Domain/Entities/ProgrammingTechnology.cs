using corePackages.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProgrammingTechnology : Entity
    {
        public string Name { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public virtual ProgrammingLanguage ProgrammLanguage { get; set; }        

        public ProgrammingTechnology()
        {
        }
        public ProgrammingTechnology(int id,int programmingLanguageId,string name) : this()
        {
            Id = id;
            ProgrammingLanguageId = programmingLanguageId;
            Name = name;
        }
    }
}
