using System;
using System.Collections.Generic;
using System.Linq;
using EMS.Data.GetModels;
using EMS.Data.Models;
using EMS.Data.ViewModels;


namespace EMS.Data
{
    public class TaskRepository
    {
        private readonly EMSContext _context;
        public TaskRepository(EMSContext context)
        {
            _context = context;
        }


        /// <summary>
        /// get task by emp id
        /// </summary>
        /// <returns>List of tasks assigned to empid=id employee</returns>        
        public IEnumerable<Task> GetTaskForEmployee(int id)
        {

           
            var test = _context.EmployeeTasks
                .Where(et => et.Id == id)
                .Select(et => et.Task)
                .ToList();
            return test;
        }
        


        /// <summary>
        /// Insert a new task
        /// </summary>
        /// <param name="task"></param>
        /// <returns>State of adding a task</returns>
        public Boolean AddTask(Task task)
        {
            try
            {
                _context.Tasks.Add(task);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

      /// <summary>
      /// Return task by Task ID
      /// </summary>
      /// <param name="id"></param>
      /// <returns>Task with the id TaskId=id</returns>
     public Task GetTaskById(int id)
        {

            /* var test = _context.Tasks
                 .Where( c => c.TaskId==id)
                 .Join(_context.Employees,
                 t => t.EmployeeEmpId, e => e.EmpId, (t, e) =>

                    new Task { TaskId = t.TaskId, TaskName = t.TaskName, StartDate = t.StartDate, EndDate = t.EndDate, BudgetedCost = t.BudgetedCost, Description = t.Description, Admin = t.Admin, EventName = t.EventName, EmployeeEmpId = e.EmpName, Status = t.Status })
                  .FirstOrDefault();
             return test;*/

            var test = _context.EmployeeTasks
                .Where(et => et.TaskId == id)
                .Select(et => et.Task)
                .FirstOrDefault();
            return test;
          
        }

        /// <summary>
        /// Task Update
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        public Boolean UpdateTask(Task task)
        {
            try
            {

                _context.Entry(task).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Boolean AddInformation(TaskInformation tinfo)
         {
             try
             {
                 _context.TaskInformations.Add(tinfo);
                 _context.SaveChanges();

                 return true;
             }
             catch
             {
                 return false;
             }
         }


        public IEnumerable<Task> GetTaskDetails()
        {
            var test = _context.Tasks
             
              .ToList();
            return test;

        }
        public IEnumerable<Employee> GetEmployeesForTask(int id) {
            var test = _context.EmployeeTasks
                .Where(et => et.TaskId == id)
                .Select(et => et.Employee)
                .ToList();
            return test;

        }
    }
}
