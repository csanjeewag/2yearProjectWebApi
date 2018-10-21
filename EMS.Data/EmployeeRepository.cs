using System;
using System.Collections.Generic;
using System.Linq;
using EMS.Data.GetModels;
using EMS.Data.Models;
using EMS.Data.ViewModels;

namespace EMS.Data
{
    public class EmployeeRepository
    {
        private readonly EMSContext _context;
        public EmployeeRepository(EMSContext context)   
        {
            _context = context;
        }

        
        public IEnumerable<Employee> GetAll()
        {

            var employees = _context.Employees
                .Where(c=> c.IsActive==true)
                //.Where(c => c.Name.Contains("s"))
                //.OrderByDescending(c => c.Name)
                //.ThenBy(c => c.BlogId)
                .ToList();
            //var employees = _context.Blogs.ToList();

            return employees;

        }

        public Employee GetEmployeeById(string id)
        {

            var corses = _context.Employees
                .Where(c => c.IsActive == true)
                .Where(c => c.EmpId == id).FirstOrDefault();
            //.OrderByDescending(c => c.Name)
            //.ThenBy(c => c.BlogId)

            //var employees = _context.Blogs.ToList();

            return corses;

        }
        public Department GetDepartmentById(string id)
        {

            var corses = _context.Departments
                .Where(c => c.DprtId == id).FirstOrDefault();
         
            return corses;

        }
        public Position GetPositionById(string id)
        {

            var corses = _context.Positions
                .Where(c => c.PositionId == id).FirstOrDefault();

            return corses;

        }
        public Employee GetEmployeeByEmail(string email)
        {

            var corses = _context.Employees
                .Where(c => c.EmpEmail == email).FirstOrDefault();
            //.OrderByDescending(c => c.Name)
            //.ThenBy(c => c.BlogId)

            //var employees = _context.Blogs.ToList();

            return corses;

        }

        public int AddEmployee(Employee emp)
        {
            GetEmail checkemail = new GetEmail();
            checkemail.Email = emp.EmpEmail;

            try
            {
                if (this.IsEmailUnique(checkemail)==false)
                {
                    Random rand = new Random((int)DateTime.Now.Ticks);
                    int numIterations = rand.Next(10000, 99999);

                    DateTime today = DateTime.Today;
                    emp.StartDate = today;
                    emp.RegisterCode = numIterations.ToString();
                    emp.PositionPId = "RC";
                    _context.Employees.Add(emp);
                    _context.SaveChanges();

                    return numIterations;
                }
                return 0;
            }
            catch
            {
                return 0;
            }
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
        public Boolean AddPosition ( Position pos)
        {
            try
            {
                _context.Positions.Add(pos);
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
        public Boolean UpdatePosition(Position role)
        {
            try
            {
                _context.Entry(role).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Boolean LoginId(LoginId log)
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

        public Boolean LoginEmail(LoginEmail log)
        {
            GetEmail getEmail = new GetEmail();
            getEmail.Email = log.EmpEmail;

            if (this.IsEmailUnique(getEmail))
            {
                var data = _context.Employees
            .Where(c => c.EmpEmail == log.EmpEmail && c.EmpPassword == log.EmpPassword)
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
            return false;
          

        }

        public IEnumerable<GetEmployeesDetails> GetEmployeesDetails() 
        {
            var test = _context.Employees
                .Where(c => c.IsActive == true)
               .Join(_context.Departments,

               e => e.DepartmentDprtId, d => d.DprtId, (e, d) =>
                  new { e, d })
               .Join(_context.Positions,
                   e2 => e2.e.PositionPId, p => p.PositionId, (e2, p)
                        => new GetEmployeesDetails { EmpId=e2.e.EmpId,EmpName=e2.e.EmpName, EmpContact=e2.e.EmpContact, EmpAddress1=e2.e.EmpAddress1, EmpAddress2=e2.e.EmpAddress2, EmpGender=e2.e.EmpGender, EmpPosition=p.PositionName, EmpDepartment=e2.d.DprtName, EmpEmail=e2.e.EmpEmail,EmpStartDate=e2.e.StartDate})
                        .ToList()
             
                  ;

            return test ;
        }

        public GetEmployeesDetails GetEmployeeDetails(string id)
        {
            var test = _context.Employees
                .Where(c => c.IsActive == true)
                .Where(c => c.EmpId == id)
               .Join(_context.Departments,
               e => e.DepartmentDprtId, d => d.DprtId, (e, d) =>
                  new { e, d })
               .Join(_context.Positions,
                   e2 => e2.e.PositionPId, p => p.PositionId, (e2, p)
                        => new GetEmployeesDetails { EmpId = e2.e.EmpId, EmpName = e2.e.EmpName, EmpContact = e2.e.EmpContact, EmpAddress1 = e2.e.EmpAddress1, EmpAddress2 = e2.e.EmpAddress2, EmpGender = e2.e.EmpGender, EmpPosition = p.PositionName, EmpDepartment = e2.d.DprtName, EmpEmail = e2.e.EmpEmail, EmpStartDate=e2.e.StartDate})
                        .FirstOrDefault()

                  ;

            return test;
        }

        public IEnumerable<Department> GetDepartments()
        {
            var departments = _context.Departments
               .ToList();
            return departments;
        }

        public IEnumerable<Position> GetRoles()
        {
            var positions = _context.Positions
               .ToList();
            return positions;
        }

        public Boolean IsEmailUnique(GetEmail email)
        {
            var data = _context.Employees
                  .Where(c => c.EmpEmail == email.Email)
                  .Select(c => c.IsActive)
                  .FirstOrDefault();
            
             if (data)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public Boolean RemoveEmployee(string id)
        {
            try {
                Employee employee = new Employee();
                employee = this.GetEmployeeById(id);
                employee.IsActive = false;
                this.UpdateEmployee(employee);
                return true;
            } catch
            {
                return false;
            }
                        
        }

        public Boolean RegisterEmployee(RegisterActive reg)
        {
            try
            {
                GetEmail getEmail = new GetEmail();
                getEmail.Email = reg.RegisterEmpEmail;

                if (this.IsEmailUnique(getEmail) == false)
                {
                    var data = _context.Employees
                .Where(c => c.EmpEmail == reg.RegisterEmpEmail && c.RegisterCode == reg.RegisterCode)
                .Select(c => c.EmpEmail)
                .FirstOrDefault();

                    if (string.IsNullOrEmpty(data))
                    {
                        return false;
                    }
                    else
                    {
                        var employee = _context.Employees.Where(c => c.EmpEmail == reg.RegisterEmpEmail && c.RegisterCode == reg.RegisterCode).FirstOrDefault();
                        employee.IsActive = true;
                        _context.Entry(employee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        _context.SaveChanges();
                        return true;
                    }
                }
                return false;
            } catch { return false; }
               
        }
    }
}
