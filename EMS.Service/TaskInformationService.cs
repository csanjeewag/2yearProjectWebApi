using EMS.Data.Models;
using EMS.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Service
{
    public class TaskInformationService
    {
        private readonly EMS.Data.TaskInformationRepository _service;

        private readonly EMSContext _context;
        public TaskInformationService(EMSContext context)
        {
            _context = context;
            _service = new EMS.Data.TaskInformationRepository(_context);
        }

        public IEnumerable<TaskInformation> GetInformation()
        {

            return _service.GetInformation();

        }
        public Boolean AddTaskInformation(TaskInformation ti)
        {
            return _service.AddTaskInformation(ti);
        }

        /*public IEnumerable<TaskInformation> GetInfoByType(int id)
        {

            return _service.GetInfoByType(id);

        }*/

    }
}
