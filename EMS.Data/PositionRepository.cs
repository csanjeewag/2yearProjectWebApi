using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMS.Data.GetModels;
using EMS.Data.Models;

namespace EMS.Data
{
  public  class PositionRepository
    {
        private readonly EMSContext _context;
        public PositionRepository(EMSContext context)
        {
            _context = context;
        }

        //add position to table
        public Boolean AddPosition(Position pos)
        {
            try
            {
                _context.Positions.Add(pos);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<Position> GetPosition()
        {
            var positions = _context.Positions
               .ToList();
            return positions;
        }
        public Position GetPositionById(string id)
        {

            var corses = _context.Positions
                .Where(c => c.PositionId == id).FirstOrDefault();

            return corses;

        }

        //update position in table
        public Boolean UpdatePosition(Position role)
        {
            try
            {
                _context.Entry(role).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        

    }
}
