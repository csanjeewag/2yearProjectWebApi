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

        //return all employees in employee table.
        public IEnumerable<Employee> GetAll()
        {

            var employees = _context.Employees
                .Where(c=> c.IsActive==true)
                .ToList();
                  return employees;

        }

        //return one employee acroding to employee id
        public Employee GetEmployeeById(string id)
        {

            var employees = _context.Employees
                .Where(c => c.IsActive == true)
                .Where(c => c.EmpId == id)
                .OrderByDescending(c => c.Id)
                .FirstOrDefault();

            return employees;

        }

        //add a employee to employee table
        public int AddEmployee(Employee employee)
        {
            GetEmail checkemail = new GetEmail();
            checkemail.Email = employee.EmpEmail;

            try
            {
                if (this.IsEmailUnique(checkemail) == false)
                {
                    //create a random number for register employee
                    Random rand = new Random((int)DateTime.Now.Ticks);
                    int regitercode = rand.Next(10000, 99999);

                    //generate today date
                    DateTime today = DateTime.Today;
                    employee.StartDate = today;
                    employee.LastUpdate = today;
                    employee.RegisterCode = regitercode.ToString();
                    employee.PositionPId = "RC";
                    _context.Employees.Add(employee);
                    _context.SaveChanges();
                    //return register code after signup
                    return regitercode; 
                }
                //if did not unique email return 0
                return 0;
            }
            catch
            {
                return 0;
            }
        }

        //return boolean value after update employee
        public Boolean UpdateEmployee(Employee employee)
        {

            try
            {   //get employees' positionid and profile pic name
                var employeedetail = _context.Employees.Where(c => c.EmpEmail == employee.EmpEmail).Select(c => new { c.EmpProfilePicture, c.PositionPId, c.RegisterCode }).FirstOrDefault();
                
                if (employee.PositionPId == null || employee.PositionPId == "")
                { employee.PositionPId = employeedetail.PositionPId; }

                employee.RegisterCode = employeedetail.RegisterCode;
                //if there is not new employee picture leave the previous profile pic name
                if (employee.EmpProfilePicture == null || employee.EmpProfilePicture == "")
                { employee.EmpProfilePicture = employeedetail.EmpProfilePicture; }

                _context.Entry(employee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //return all employees detils acroding to viewemployee interface
        public IEnumerable<ViewEmployee> GetEmployeesDetails()
        {
            var employees = _context.Employees
                .Where(c => c.IsActive == true)
               .Join(_context.Departments,
               // join department table
               e => e.DepartmentDprtId, d => d.DprtId, (e, d) =>
                  new { e, d })
               .Join(_context.Positions,
                   // join position table
                   e2 => e2.e.PositionPId, p => p.PositionId, (e2, p)
                        => new ViewEmployee { EmpId = e2.e.EmpId, EmpName = e2.e.EmpName, EmpContact = e2.e.EmpContact, EmpAddress1 = e2.e.EmpAddress1, EmpAddress2 = e2.e.EmpAddress2, EmpGender = e2.e.EmpGender, EmpPosition = p.PositionName, EmpDepartment = e2.d.DprtName, EmpEmail = e2.e.EmpEmail, EmpStartDate = e2.e.StartDate })
                        .ToList();

                  

            return employees;
        }

        //return employee details for id without such as password 
        public ViewEmployee GetEmployeeDetails(string id)
        {
            var employee = _context.Employees
                .Where(c => c.IsActive == true)
                .Where(c => c.EmpId == id)
               .Join(_context.Departments,
               e => e.DepartmentDprtId, d => d.DprtId, (e, d) =>
                  new { e, d })
               .Join(_context.Positions,
                   e2 => e2.e.PositionPId, p => p.PositionId, (e2, p)
                        => new ViewEmployee { EmpId = e2.e.EmpId, EmpName = e2.e.EmpName, EmpContact = e2.e.EmpContact, EmpAddress1 = e2.e.EmpAddress1, EmpAddress2 = e2.e.EmpAddress2, EmpGender = e2.e.EmpGender, EmpPosition = p.PositionName, EmpDepartment = e2.d.DprtName, EmpEmail = e2.e.EmpEmail, EmpStartDate = e2.e.StartDate, EmpProfilePicture = e2.e.EmpProfilePicture })
                        .FirstOrDefault();

                  

            return employee;
        }

    
        //deactive employee 
        public Boolean RemoveEmployee(string id)
        {
            try
            {
                Employee employee = new Employee();
                Random rand = new Random((int)DateTime.Now.Ticks);
                int numIterations = rand.Next(10000, 99999);

                employee = this.GetEmployeeById(id);
                employee.IsActive = false;

                employee.RegisterCode = numIterations.ToString();
                this.UpdateEmployee(employee);
                return true;
            }
            catch
            {
                return false;
            }

        }

        //return employee by email
        public Employee GetEmployeeByEmail(string email)
        {

            var corses = _context.Employees
                .Where(c => c.EmpEmail == email).FirstOrDefault();
            return corses;

        }
        //update position of employee
        public Boolean UpdatePosition(GetUpdatePosition position)
        {

            try
            {
                // assign employee details
                var employee = _context.Employees.Where(c => c.EmpEmail == position.Email).FirstOrDefault();
                //change position
                employee.PositionPId = position.PositionId;
                _context.Entry(employee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //check whether employee can login or not
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

        //check the email in the database
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

        // login by email
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

        //if forgot password genarate new register code
        public int ForgetPassword(string email)
        {
            try
            {
                GetEmail getEmail = new GetEmail();
                getEmail.Email = email;
                if (this.IsEmailUnique(getEmail) == true)
                {
                    Random rand = new Random((int)DateTime.Now.Ticks);
                    int regitercode = rand.Next(10000, 99999);

                    Employee employee = new Employee();
                    employee = GetEmployeeByEmail(email);
                    employee.RegisterCode = regitercode.ToString();
                    UpdateEmployee(employee);
                    return regitercode;


                }
                return 0;
            }
            catch
            {
                return 0;
            }


        }

        //after forgot password update employee new password
        public Boolean SetEmailAndPassword(GetEmailPassword getEP)
        {
            GetEmail getEmail = new GetEmail();
            getEmail.Email = getEP.EmpEmail;

            if (this.IsEmailUnique(getEmail) == true)
            {
                Random rand = new Random((int)DateTime.Now.Ticks);
                int numIterations = rand.Next(10000, 99999);
                Employee employee = new Employee();
                employee = GetEmployeeByEmail(getEP.EmpEmail);
                if (employee.RegisterCode == getEP.Code)
                {
                    employee.EmpPassword = getEP.EmpPassword;
                    employee.RegisterCode = numIterations.ToString();
                    UpdateEmployee(employee);
                    return true;
                }
                return false;
            }
            return false;
        }

        // register employee using regiter code
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
                        //create new  random number for register code
                        Random rand = new Random((int)DateTime.Now.Ticks);
                        int regitercode = rand.Next(10000, 99999);

                        var employee = _context.Employees.Where(c => c.EmpEmail == reg.RegisterEmpEmail && c.RegisterCode == reg.RegisterCode).FirstOrDefault();
                        employee.IsActive = true;
                        employee.RegisterCode = regitercode.ToString();
                        _context.Entry(employee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        _context.SaveChanges();
                        return true;
                    }
                }
                return false;
            }
            catch { return false; }

        }

      
    }
}
