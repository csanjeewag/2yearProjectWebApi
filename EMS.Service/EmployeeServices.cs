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

        
        public Employee GetEmployeeByEmail(string email)
        {


            return _service.GetEmployeeByEmail(email);

        }

        public int AddEmployee(Employee emp)
        {
            return _service.AddEmployee(emp);
        }
       
       

        public int UpdateEmployee(Employee emp)
        {
            
            emp.IsActive = true;

            return _service.UpdateEmployee(emp);
        }

       

        


        public Boolean UpdateEmployeeByPart(GetEmployee employee)
        {
            return _service.UpdateEmployeeByPart(employee);
        }


        public Boolean LoginId(LoginId log)
        {
            return _service.LoginId(log);


        }
        public Boolean LoginEmail(LoginEmail log)
        {
            return _service.LoginEmail(log);


        }

        public IEnumerable<ViewEmployee> GetEmployeesDetails()
        {
           

            return _service.GetEmployeesDetails();
        }

        public ViewEmployee GetEmployeeDetails(string id)
        {


            return _service.GetEmployeeDetails(id);
        }

        
      

        public ViewEmployee IsEmailUnique(GetEmail email)
        {
            return _service.IsEmailUnique(email);
        }

        public Boolean RemoveEmployee(string id,Boolean state)
        {
            return _service.RemoveEmployee(id, state);
        }

        public Boolean RegisterEmployee( RegisterActive reg)
        {
          return  _service.RegisterEmployee(reg);
        }

        public int ForgetPassword(string email)
        {
            return _service.ForgetPassword(email);
        }

        public Boolean SetEmailAndPassword(GetEmailPassword getEP)
        {
            return _service.SetEmailAndPassword(getEP);
        }

        public Boolean ChangePassword(ChangePassword changePassword)
        {
            return _service.ChangePassword(changePassword);
        }



    }

}