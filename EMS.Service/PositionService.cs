using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMS.Data.GetModels;
using EMS.Data.Models;

namespace EMS.Service
{
  public  class PositionService
    {
        private readonly EMS.Data.PositionRepository _service;

        private readonly EMSContext _context;
        public PositionService(EMSContext context)
        {
            _context = context;
            _service = new EMS.Data.PositionRepository(_context);
        }

        public Position GetPositonById(string id)
        {
            return _service.GetPositionById(id);

        }

        public List<Position> GetRoles()
        {

            return _service.GetPosition();

        }


        public Boolean AddPosition(Position pos)
        {
            return _service.AddPosition(pos);
        }

        public Boolean UpdatePosition(Position role)
        {
            return _service.UpdatePosition(role);
        }

       
       

    }
}
