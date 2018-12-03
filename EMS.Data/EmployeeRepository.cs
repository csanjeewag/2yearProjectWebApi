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

        /// <summary>
        /// return all employees in employee table.
        /// </summary>
        /// <returns>Empoyee list</returns>
        public IEnumerable<Employee> GetAll()
        {

            var employees = _context.Employees
                .Where(c=> c.IsActive==true)
                .ToList();
                  return employees;

        }

        /// <summary>
        /// return one employee acroding to employee id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Employee</returns>
        public Employee GetEmployeeById(string id)
        {

            var employees = _context.Employees
                .Where(c => c.IsActive == true)
                .Where(c => c.EmpId == id)
                .OrderByDescending(c => c.Id)
                .FirstOrDefault();

            return employees;

        }

        /// <summary>
        /// add a employee to employee table
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>return register code</returns>
        public int AddEmployee(Employee employee)
        {
            GetEmail checkemail = new GetEmail();
            checkemail.Email = employee.EmpEmail;

            try
            {
                if (this.IsEmail(checkemail) == false)
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

        /// <summary>
        /// return boolean value after update employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>boolean</returns>
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
            var employee = _context.Employees
                .Where(c => c.IsActive == true)
               .Join(_context.Departments,
               // join department table
               e => e.DepartmentDprtId, d => d.DprtId, (e, d) =>
                  new { e, d })
               .Join(_context.Positions,
                   // join position table
                   e2 => e2.e.PositionPId, p => p.PositionId, (e2, p)
                        => new ViewEmployee { EmpId = e2.e.EmpId, EmpName = e2.e.EmpName, EmpContact = e2.e.EmpContact, EmpAddress1 = e2.e.EmpAddress1, EmpAddress2 = e2.e.EmpAddress2, EmpGender = e2.e.EmpGender, EmpPosition = p.PositionName, EmpDepartment = e2.d.DprtName, EmpEmail = e2.e.EmpEmail, EmpStartDate = e2.e.StartDate, EmpProfilePicture = e2.e.EmpProfilePicture })
                        .ToList();

            var employees = (from em in _context.Employees
                            join de in _context.Departments on em.DepartmentDprtId equals de.DprtId
                            join po in _context.Positions on em.PositionPId equals po.PositionId
                            join pr in _context.Projects on em.ProjectPrId equals pr.PrId
                            where em.IsActive == true
                            select new ViewEmployee
                            {
                                EmpId = em.EmpId,
                                EmpName = em.EmpName,
                                EmpContact = em.EmpContact,
                                EmpAddress1 = em.EmpAddress1,
                                EmpAddress2 = em.EmpAddress2,
                                EmpGender = em.EmpGender,
                                EmpPosition = po.PositionName,
                                EmpDepartment = de.DprtName,
                                EmpEmail = em.EmpEmail,
                                EmpStartDate = em.StartDate,
                                EmpProfilePicture = em.EmpProfilePicture,
                                ProjectName = pr.ProjectName

                            }).ToList();



            return employees;
        }

        /// <summary>
        /// return employee details for id without such as password 
        /// </summary>
        /// <param name="id"></param>
        /// <returns> View Employee modal</returns>
        public ViewEmployee GetEmployeeDetails(string id)
        {
            var employees = _context.Employees
                .Where(c => c.IsActive == true)
                .Where(c => c.EmpId == id)
               .Join(_context.Departments,
               e => e.DepartmentDprtId, d => d.DprtId, (e, d) =>
                  new { e, d })
               .Join(_context.Positions,
                   e2 => e2.e.PositionPId, p => p.PositionId, (e2, p)
                        => new ViewEmployee { EmpId = e2.e.EmpId, EmpName = e2.e.EmpName, EmpContact = e2.e.EmpContact, EmpAddress1 = e2.e.EmpAddress1, EmpAddress2 = e2.e.EmpAddress2, EmpGender = e2.e.EmpGender, EmpPosition = p.PositionName, EmpDepartment = e2.d.DprtName, EmpEmail = e2.e.EmpEmail, EmpStartDate = e2.e.StartDate, EmpProfilePicture = e2.e.EmpProfilePicture })
                        .FirstOrDefault();

            var employee = (from em in _context.Employees
                       join de in _context.Departments on em.DepartmentDprtId equals de.DprtId
                       join po in _context.Positions on em.PositionPId equals po.PositionId
                       join pr in _context.Projects on em.ProjectPrId equals pr.PrId
                       where(em.IsActive == true && em.EmpId== id)
                       select new ViewEmployee
                       {
                           EmpId = em.EmpId,
                           EmpName = em.EmpName,
                           EmpContact = em.EmpContact,
                           EmpAddress1 = em.EmpAddress1,
                           EmpAddress2 = em.EmpAddress2,
                           EmpGender = em.EmpGender,
                           EmpPosition = po.PositionName,
                           EmpDepartment = de.DprtName,
                           EmpEmail = em.EmpEmail,
                           EmpStartDate = em.StartDate,
                           EmpProfilePicture = em.EmpProfilePicture,
                           ProjectName = pr.ProjectName

                       }).FirstOrDefault();
    



            return employee;
        }


        /// <summary>
        /// deactive employee 
        /// </summary>
        /// <param name="id"></param>
        /// <returns> boolean</returns>
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

        /// <summary>
        /// return employee by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns> Employee</returns>
        public Employee GetEmployeeByEmail(string email)
        {

            var corses = _context.Employees
                .Where(c => c.EmpEmail == email).FirstOrDefault();
            return corses;

        }
        /// <summary>
        /// update position of employee
        /// </summary>
        /// <param name="position"></param>
        /// <returns>boolean</returns>
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

        /// <summary>
        ///check whether employee can login or not
        /// </summary>
        /// <param name="log"></param>
        /// <returns> true if login sucsess</returns>
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

        /// <summary>
        /// check the email in the database
        /// </summary>
        /// <param name="email"></param>
        /// <returns> true if email in table</returns>
        public ViewEmployee IsEmailUnique(GetEmail email)
        {
            var data = _context.Employees
                  .Where(c => c.EmpEmail == email.Email)
                  .Select(c => c.IsActive)
                  .FirstOrDefault();
            var employee = _context.Employees.Where(c => c.EmpEmail == email.Email).Select(c => new ViewEmployee { EmpEmail = c.EmpEmail, EmpName = c.EmpName, EmpProfilePicture = c.EmpProfilePicture }).FirstOrDefault();

            if (data)
            {
                return employee;
            }
            else
            {
                return employee;
            }

        }

        public Boolean IsEmail(GetEmail email)
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


        /// <summary>
        ///  login by email
        /// </summary>
        /// <param name="log"></param>
        /// <returns>if login success return true</returns>
        public Boolean LoginEmail(LoginEmail log)
        {
            GetEmail getEmail = new GetEmail();
            getEmail.Email = log.EmpEmail;

            if (this.IsEmail(getEmail))
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

        /// <summary>
        /// if forgot password genarate new register code
        /// </summary>
        /// <param name="email"></param>
        /// <returns> register code</returns>
        public int ForgetPassword(string email)
        {
            try
            {
                GetEmail getEmail = new GetEmail();
                getEmail.Email = email;
                if (this.IsEmail(getEmail) == true)
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

        /// <summary>
        /// after forgot password update employee new password
        /// </summary>
        /// <param name="getEP"></param>
        /// <returns> if success return true</returns>
        public Boolean SetEmailAndPassword(GetEmailPassword getEP)
        {
            GetEmail getEmail = new GetEmail();
            getEmail.Email = getEP.EmpEmail;

            if (this.IsEmail(getEmail) == true)
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

        /// <summary>
        /// register employee using regiter code
        /// </summary>
        /// <param name="reg"></param>
        /// <returns> if success return true</returns>
        public Boolean RegisterEmployee(RegisterActive reg)
        {
            try
            {
                GetEmail getEmail = new GetEmail();
                getEmail.Email = reg.RegisterEmpEmail;

                if (this.IsEmail(getEmail) == false)
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
