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

        public IEnumerable<Department> GetDepartments()
        {
            return _service.GetDepartments();
        }

        public Boolean UpdateDepartment(Department dprt)
        {
            return _service.UpdateDepartment(dprt);
        }

        public Boolean AddDepartment(Department dprt)
        {
            return _service.AddDepartment(dprt);
        }

        public Department GetDepartmentById(string id)
        {
            return _service.GetDepartmentById(id);

        }
       
    }
}
