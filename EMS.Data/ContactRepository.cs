using System;
using System.Collections.Generic;
using System.Linq;
using EMS.Data.GetModels;
using EMS.Data.Models;
using EMS.Data.ViewModels;

namespace EMS.Data
{
    public class ContactRepository
    {
        private readonly EMSContext _context;
        public ContactRepository(EMSContext context)
        {
            _context = context;
        }

        public IEnumerable<Contact> GetContactTypes()
        {
            var test = _context.Contacts

              .ToList();
            return test;

        }

        public Boolean AddContactType(Contact c)
        {
            try
            {
                _context.Contacts.Add(c);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }


        public int AddContactDetail(ContactDetails c)
        {
            try
            {
                _context.ContactDetails.Add(c);
                _context.SaveChanges();
                int result = _context.ContactDetails.Max(p => p.ContactDetailId);
                return result;
            }
            catch
            {
                return 0;
            }
        }




        /*public IEnumerable<TaskInformation> GetAllForType(int id) {
            var test = _context.TaskInformations
                .Where(e => e.ContactId.ContactId == id)
              // .Select(et => et.TaskInformation)
                .ToList();
            return test;

        }*/

    }
}
