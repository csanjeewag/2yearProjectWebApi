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


        /// <summary>
        /// add position to table
        /// </summary>
        /// <param name="position"></param>
        /// <returns>boolean</returns>
        public Boolean AddPosition(Position position)
        {
            try
            {
                _context.Positions.Add(position);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        
        /// <summary>
        /// get all positions in table
        /// </summary>
        /// <returns></returns>
        public List<Position> GetPosition()
        {
            var positions = _context.Positions
               .ToList();
            return positions;
        }

        /// <summary>
        /// get position given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>position</returns>
        public Position GetPositionById(string id)
        {

            var corses = _context.Positions
                .Where(c => c.PositionId == id).FirstOrDefault();

            return corses;

        }

        /// <summary>
        /// update position in table
        /// </summary>
        /// <param name="role"></param>
        /// <returns> boolean</returns>
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
