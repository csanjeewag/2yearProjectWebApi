using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EMS.API.Ulities;
using EMS.Data.GetModels;
using EMS.Data.Models;
using EMS.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace EMS.API.Controllers
{

    [Produces("application/json")]
    [Route("api/Employee")]
    public class EmployeeController : Controller
    {

        private readonly EMSContext _context;
        private readonly EmployeeServices _service;
        public EmployeeController(EMSContext context)
        {
            _context = context;
            _service = new EmployeeServices(_context);
        }


        /// <summary>
        /// upload employee details
        /// </summary>
        /// <param name="f"></param>
        /// <returns> return 200 if upload success else return 404</returns>
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("upload")]
        public async Task<IActionResult> Upload(FileUpload f)
        {
            try
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(),
                 "wwwroot/Image", f.Image.FileName);
                var stream = new FileStream(path, FileMode.Create);
                f.Image.CopyToAsync(stream);
                return Ok(new { lenght = f.Image.Length, name = f.Image });
            }
            catch
            {
                return BadRequest();
            }
        }

        
        /// <summary>
        /// get employee details 
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet("")]
        //  [Authorize(Roles = "Administrator")]
        public IEnumerable<Employee> FindAll()
        {
            return _service.GetAll();

        }

        /// <summary>
        /// get all employee details
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [Produces("application/json")]
        [HttpGet("getall")]
        public IActionResult GetEmployeesDetails()
        {


            var result = _service.GetEmployeesDetails();
            return Ok(result);


        }

        /// <summary>
        /// get employee from id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet("getall/{id}")]
        public IActionResult GetEmployeeDetails(string id)
        {


            var result = _service.GetEmployeeDetails(id);
            return Ok(result);


        }

        /// <summary>
        /// get employee from id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet("{id}")]

        public Employee GetEmployeeById(string id)
        {
            return _service.GetEmployeeById(id);

        }

        /// <summary>
        /// get employee from email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet("email/{id}")]

        public Employee GetEmployeeByEmail(string email)
        {
            return _service.GetEmployeeByEmail(email);

        }

      /// <summary>
      /// add new employee 
      /// </summary>
      /// <param name="emp"></param>
      /// <returns></returns>
        [HttpPost("create")]
        public IActionResult Create([FromForm]GetEmployee emp)
        {
            try
            {
                string res = "";
                if (emp.EmpProfilePicture != null)
                {
                    // add profile picture 
                    res = AddFiles.AddImage(emp.EmpProfilePicture, emp.EmpId);

                }

                Employee employee = new Employee();
                employee.EmpId = emp.EmpId;
                employee.EmpEmail = emp.EmpEmail;
                employee.EmpPassword = emp.EmpPassword;
                employee.EmpName = emp.EmpName;
                employee.EmpContact = emp.EmpContact;
                employee.EmpAddress1 = emp.EmpAddress1;
                employee.EmpAddress2 = emp.EmpAddress2;
                employee.EmpGender = emp.EmpGender;
                employee.PositionPId = emp.PositionPId;
                employee.DepartmentDprtId = emp.DepartmentDprtId;
                employee.EmpProfilePicture = res;

                int regitercode = _service.AddEmployee(employee);


                if (regitercode > 0)
                {

                    // if there register code send it bt email
                    Boolean SendCode = SendMail.SendloginCode(regitercode.ToString(), emp.EmpEmail, emp.EmpName);

                    return Ok(emp);
                }
                else
                {
                    return BadRequest("there error");
                }
            }
            catch
            {
                return BadRequest();
            }
        }

      


        /// <summary>
        /// update employee details
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        [HttpPost("updateemployee")]
        public IActionResult UpdateEmployee([FromForm]GetEmployee emp)
        {
            string res = "";
            if (emp.EmpProfilePicture != null)
            {
                // if there profile picture change it
                res = AddFiles.AddImage(emp.EmpProfilePicture, emp.EmpId);

            }

            Employee employee = new Employee();
            employee.EmpId = emp.EmpId;
            employee.EmpEmail = emp.EmpEmail;
            employee.EmpPassword = emp.EmpPassword;
            employee.EmpName = emp.EmpName;
            employee.EmpContact = emp.EmpContact;
            employee.EmpAddress1 = emp.EmpAddress1;
            employee.EmpAddress2 = emp.EmpAddress2;
            employee.EmpGender = emp.EmpGender;
            employee.PositionPId = emp.PositionPId;
            employee.DepartmentDprtId = emp.DepartmentDprtId;
            employee.EmpProfilePicture = res;
            employee.IsActive = emp.IsActive;
            employee.StartDate = emp.StartDate;

            if (_service.UpdateEmployee(employee))
            {

                return Ok(emp);
            }
            else
            {
                return BadRequest("there error");
            }
        }


        /// <summary>
        /// update employee position using email
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [HttpPost("updaterole")]
        public IActionResult UpdatePosition([FromForm]GetUpdatePosition position)
        {

            if (_service.UpdatePosition(position))
            {

                return Ok(position);
            }
            else
            {
                return BadRequest("there error");
            }
        }

     
      /// <summary>
      /// login employee
      /// </summary>
      /// <param name="logins"></param>
      /// <returns> if logged return 200 else 404</returns>
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("login")]
        public IActionResult loginId([FromBody]LoginId logins)
        {


            if (_service.LoginId(logins))
            {
                var data = _service.GetEmployeeById(logins.EmpId);
                var Emprole = data.PositionPId;
                var Empid = data.EmpId;
                var EmpName = data.EmpName;
                

                GetTokenModel token = GetToken.getToken(Emprole, Empid, EmpName );

                return Ok(new
                {
                    token = token.Token,
                    expiration = token.Expiretion
                });

            }
            else
            {
                return BadRequest("there error");
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("loginEmail")]
        public IActionResult loginEmail([FromBody]LoginEmail logins)
        {
            

            if (_service.LoginEmail(logins))
            {
                var data = _service.GetEmployeeByEmail(logins.EmpEmail);
                var Emprole = data.PositionPId;
                var EmpName = data.EmpName;
                var Empid = data.EmpId;
                

                
                GetTokenModel token = GetToken.getToken(Emprole, Empid, EmpName);

                return Ok(new
                {
                    token = token.Token,
                    expiration = token.Expiretion
                });

            }
            else
            {
                return BadRequest("there error");
            }


        }

        
     

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("isuniqueemail")]
        public Boolean IsEmailUnique([FromBody]GetEmail email)
        {
            try
            {
                return _service.IsEmailUnique(email);
            }
            catch
            {
                return false;
            }
        }

        [Produces("application/json")]
        [HttpGet("deleteEmployee/{id}")]
        public Boolean RemoveEmployee(string id)
        {
            return _service.RemoveEmployee(id);
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("registeremployee")]
        public IActionResult RegisterEmployee([FromBody]RegisterActive reg)
        {

            if (_service.RegisterEmployee(reg)) { return Ok();

            }
            else { return BadRequest(); }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpGet("forgetpassword/{id}")]
        public IActionResult ForgetPassword(string id)
        {
            var code = _service.ForgetPassword(id);
            if ( code> 0)
            {
               if( SendMail.SendForgetPasswordCode(code.ToString(), id, " buddy")) 
                return Ok();
            }
            return BadRequest();
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("setpassword")]
        public IActionResult SetEmailAndPassword([FromBody]GetEmailPassword getEP)
        {
            if(_service.SetEmailAndPassword(getEP))
            {
                return Ok();
            }
          return  BadRequest();
        }
    }
}
