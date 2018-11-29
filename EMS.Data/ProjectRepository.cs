using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMS.Data.Models;

namespace EMS.Data
{
  public  class ProjectRepository
    {
        private readonly EMSContext _context;
        public ProjectRepository(EMSContext context)
        {
            _context = context;
        }

        public Boolean AddProject(Project project)
        {
            try
            {
                project.IsActive = true;
                _context.Projects.Add(project);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public Boolean UpdateProject(Project project)
        {
            try
            {
                project.IsActive = true;
                _context.Entry(project).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Project> GetProject()
        {
            var projects = _context.Projects
               .ToList();
            return projects;
        }

        public Project GetProject(string id)
        {
            var projects = _context.Projects.Where(c=> c.IsActive==true && c.ProjectId == id)
               .FirstOrDefault();
            return projects;
        }

        public Boolean DeActive (string id)
        {
           
            try {
                var project = _context.Projects.Where(c => c.IsActive == true && c.ProjectId == id)
                .FirstOrDefault();
                project.IsActive = false;
                _context.Entry(project).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public Boolean Active(string id)
        {

            try
            {
                var project = _context.Projects.Where(c => c.IsActive == false && c.ProjectId == id)
                .FirstOrDefault();
                project.IsActive = true;
                _context.Entry(project).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch { return false; }
        }


    }
}
