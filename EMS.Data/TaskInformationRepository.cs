using System;
using System.Collections.Generic;
using System.Linq;
using EMS.Data.GetModels;
using EMS.Data.Models;
using EMS.Data.ViewModels;


namespace EMS.Data
{
   public  class TaskInformationRepository
    {
        private readonly EMSContext _context;
        public TaskInformationRepository(EMSContext context)
        {
            _context = context;
        }

        public Boolean AddTaskInformation(TaskInformation tinfo)
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
        /// <summary>
        /// get all information
        /// </summary>
        /// <returns></returns>

        public IEnumerable<TaskInformation> GetInformation()
        {
            var test = _context.TaskInformations

              .ToList();
            return test;

        }


        /*public IEnumerable<TaskInformation> GetInfoByType(int id)
        {
            var test = _context.Contacts
                .Where(et => et.ContactId == id)
                .Select(et => et.)
                .ToList();
            return test;

        }*/
    }
}
