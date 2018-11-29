using System;
using System.Collections.Generic;
using System.Text;
using EMS.Data.Models;

namespace EMS.Service
{
  public class DepartmentService
    {
        private readonly EMS.Data.DepartmentRepository _service;

        private readonly EMSContext _context;
        public DepartmentService(EMSContext context)
        {
            _context = context;
            _service = new EMS.Data.DepartmentRepository(_context);
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
