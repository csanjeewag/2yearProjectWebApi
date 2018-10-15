using System;
using System.Collections.Generic;
using System.Linq;
using EMS.Data.GetModels;
using EMS.Data.Models;

namespace EMS.Data
{
    public class TaskRepository 
    {
        private readonly EMSContext _context;
        public TaskRepository(EMSContext context)  
        {
            _context = context;
        }

        public IEnumerable<Employee> GetAll()
        {

            var corses = _context.Employees
                //.Where(c => c.Name.Contains("s"))
                //.OrderByDescending(c => c.Name)
                //.ThenBy(c => c.BlogId)
                .ToList();
            //var employees = _context.Blogs.ToList();

            return corses;

        }

        public Employee GetEmp(string id)
        {

            var corses = _context.Employees
                .Where(c => c.EmpId == id).FirstOrDefault();
            //.OrderByDescending(c => c.Name)
            //.ThenBy(c => c.BlogId)

            //var employees = _context.Blogs.ToList();

            return corses;

        }

        public Boolean AddEmployee(Employee emp)
        {
            try
            {
                _context.Employees.Add(emp);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }


        public Boolean UpdateEmployee(Employee emp)
        {
            try
            {
                _context.Entry(emp).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Boolean Login(LoginId log)
        {
            var data = _context.Employees
                  .Where(c => c.EmpId == log.EmpId && c.EmpPassword == log.EmpPassword)
                  .Select(c => c.EmpId)
                  .FirstOrDefault();
            if (string.IsNullOrEmpty(data))
            {
                return false;
            }
            else
            {
                return true;
            }

        }
    }
}
