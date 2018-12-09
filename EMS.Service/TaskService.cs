using EMS.Data.Models;
using EMS.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Service
{
  public  class TaskService
    {
        private readonly EMS.Data.TaskRepository _service;


        private readonly EMSContext _context;
        public TaskService(EMSContext context)
        {
            _context = context;
            _service = new EMS.Data.TaskRepository(_context);
        }
       
         public IEnumerable<Task> GetTaskForEmployee(int id)
        {

            return _service.GetTaskForEmployee(id);

        }

        public Boolean AddTask(Task t)
        {
            return _service.AddTask(t);
        }




        /// <summary>
        /// get task by Id service
        /// </summary>
        /// <param name="id"></param>
        /// <returns>return to Task Repository</returns>
        public Task GetTaskById(int id)
        {
            return _service.GetTaskById(id);

        }

        public Boolean UpdateTask(Task t)
        {
            return _service.UpdateTask(t);
        }
       
         public Boolean AddInformation(TaskInformation tinfo)
         {
             return _service.AddInformation(tinfo);
         }

        public IEnumerable<Task> GetTaskDetails()
        {

            return _service.GetTaskDetails();

        }
        public IEnumerable<Employee> GetEmployeesForTask(int id) {
            return _service.GetEmployeesForTask(id);
        }
    }
}
