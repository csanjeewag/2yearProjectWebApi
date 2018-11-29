using System;
using System.Collections.Generic;
using System.Text;
using EMS.Data.Models;

namespace EMS.Service
{
  public  class ProjectService
    {
        private readonly EMS.Data.ProjectRepository _service;

        private readonly EMSContext _context;
        public ProjectService(EMSContext context)
        {
            _context = context;
            _service = new EMS.Data.ProjectRepository(_context);
        }

        public List<Project> GetProject()
        {
            return _service.GetProject();
        }

        public Boolean UpdateProject(Project project)
        {
            return _service.UpdateProject(project);
        }

        public Boolean AddProject(Project project)
        {
            return _service.AddProject(project);
        }

        public Project GetProject(string id)
        {
            return _service.GetProject(id);
        }

        public Boolean DeActive(string id)
        {
            return _service.DeActive(id);
        }

        public Boolean Active(string id)
        {
            return _service.Active(id);
        }

    }
}
