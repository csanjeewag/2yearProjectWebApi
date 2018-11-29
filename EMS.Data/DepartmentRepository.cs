using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMS.Data.Models;

namespace EMS.Data
{
 public class DepartmentRepository
    {

        private readonly EMSContext _context;
        public DepartmentRepository(EMSContext context)
        {
            _context = context;
        }

        /// <summary>
        /// get department from id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Department GetDepartmentById(string id)
        {

            var corses = _context.Departments
                .Where(c => c.DprtId == id).FirstOrDefault();

            return corses;

        }


        /// <summary>
        /// add a new department
        /// </summary>
        /// <param name="dprt"></param>
        /// <returns></returns>
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

        /// <summary>
        /// update department
        /// </summary>
        /// <param name="dprt"></param>
        /// <returns></returns>
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

        /// <summary>
        /// get all department
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Department> GetDepartments()
        {
            var departments = _context.Departments
               .ToList();
            return departments;
        }
    }
}
