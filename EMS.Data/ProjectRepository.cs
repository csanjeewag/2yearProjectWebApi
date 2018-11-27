using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMS.Data.Models;

namespace EMS.Data
{
  public  class ProjectRepository
    {
        private readonly EMSContext _context;
        public ProjectRepository(EMSContext context)
        {
            _context = context;
        }


        public Department GetDepartmentById(string id)
        {

            var corses = _context.Departments
                .Where(c => c.DprtId == id).FirstOrDefault();

            return corses;

        }
        


        public Boolean AddDepartment(Department dprt)
        {
            try
            {
                _context.Departments.Add(dprt);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public Boolean UpdateDepartment(Department dprt)
        {
            try
            {
                _context.Entry(dprt).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public IEnumerable<Department> GetDepartments()
        {
            var departments = _context.Departments
               .ToList();
            return departments;
        }


    }
}
