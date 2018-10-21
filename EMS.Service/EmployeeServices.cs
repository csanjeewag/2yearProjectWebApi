using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.Data.GetModels;
using EMS.Data.Models;
using EMS.Data.ViewModels;

//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;


namespace EMS.Service 
{
    // [Produces("application/json")]
  //  [Route("api/Employee")]
    public class EmployeeServices
    {
        private readonly EMS.Data.EmployeeRepository  _service; 

        private readonly EMSContext _context;
        public EmployeeServices(EMSContext context)
        {
            _context = context;
            _service = new EMS.Data.EmployeeRepository(_context); 
        }

       

        public IEnumerable<Employee> GetAll() 
        {

            return _service.GetAll();

        }

        public Employee GetEmployeeById(string id)
        {
            return _service.GetEmployeeById(id);

        }

        public Department GetDepartmentById(string id)
        {
            return _service.GetDepartmentById(id);

        }
        public Position GetPositionById(string id)
        {
            return _service.GetPositionById(id);

        }
        public Employee GetEmployeeByEmail(string email)
        {


            return _service.GetEmployeeByEmail(email);

        }

        public int AddEmployee(Employee emp)
        {
            return _service.AddEmployee(emp);
        }
        public Boolean AddDepartment(Department dprt)
        {
            return _service.AddDepartment(dprt);
        }

        public Boolean AddPosition(Position pos)
        {
            return _service.AddPosition(pos);
        }

        public Boolean UpdateEmployee(Employee emp)
        {
            emp.IsActive = true;
            return _service.UpdateEmployee(emp);
        }

        public Boolean UpdateDepartment(Department dprt)
        {
            return _service.UpdateDepartment(dprt);
        }

        public Boolean UpdatePosition(Position role)
        {
            return _service.UpdatePosition(role);
        }



        public Boolean LoginId(LoginId log)
        {
            return _service.LoginId(log);


        }
        public Boolean LoginEmail(LoginEmail log)
        {
            return _service.LoginEmail(log);


        }

        public IEnumerable<GetEmployeesDetails> GetEmployeesDetails()
        {
           

            return _service.GetEmployeesDetails();
        }

        public GetEmployeesDetails GetEmployeeDetails(string id)
        {


            return _service.GetEmployeeDetails(id);
        }

        public IEnumerable<Department> GetDepartments()
        {
            return _service.GetDepartments();
        }

        public IEnumerable<Position> GetRoles()
        {
            return _service.GetRoles();
        }

        public Boolean IsEmailUnique(GetEmail email)
        {
            return _service.IsEmailUnique(email);
        }

        public Boolean RemoveEmployee(string id)
        {
            return _service.RemoveEmployee(id);
        }

        public Boolean RegisterEmployee( RegisterActive reg)
        {
          return  _service.RegisterEmployee(reg);
        }

    }

}