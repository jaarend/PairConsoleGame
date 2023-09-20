using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaveTreasureHunt.Data.Entities
{
    public class ProjectItem
    {
        public ProjectItem(){}
        public ProjectItem(string name)
        {
            Name = name;
        }
        public int Id { get; set; } //assignment of this ID will happen in the repository not here in the data
        public string Name { get; set; } = string.Empty;
        
    }
}