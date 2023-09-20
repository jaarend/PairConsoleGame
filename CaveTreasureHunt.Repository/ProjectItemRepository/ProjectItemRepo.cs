using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaveTreasureHunt.Data.Entities;

namespace CaveTreasureHunt.Repository.ProjectItemRepository
{
    public class ProjectItemRepo
    {
        //Fake database
        List<ProjectItem> projectItemDb = new List<ProjectItem>();

        int _counter = 0;
        public bool AddProjectItem(ProjectItem item)
        {
            if(item == null)
            {
                return false;
            }
            else
            {
                _counter++;
                item.Id = _counter;
                projectItemDb.Add(item);
                return true;
            }
        }
    }
}