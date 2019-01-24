using EMS.Data.Models;
using EMS.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Service
{
    public class ContactService
    {
        private readonly EMS.Data.ContactRepository _service;


        private readonly EMSContext _context;
        public ContactService(EMSContext context)
        {
            _context = context;
            _service = new EMS.Data.ContactRepository(_context);
        }

        public IEnumerable<Contact> GetContactTypes()
        {

            return _service.GetContactTypes();

        }

        public Boolean AddContactType(Contact c)
        {
            return _service.AddContactType(c);
        }

        public int AddContactDetail(ContactDetails c)
        {
            return _service.AddContactDetail(c);
        }


        /*public IEnumerable<TaskInformation> GetAllForType(int id)
        {

            return _service.GetAllForType(id);

        }*/


    }
}
