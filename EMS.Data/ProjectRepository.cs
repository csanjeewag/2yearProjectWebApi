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

        /// <summary>
        /// add a new project
        /// </summary>
        /// <param name="project"></param>
        /// <returns> return true if success</returns>
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
        /// <summary>
        /// update project details
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
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
        /// <summary>
        /// get all projet from table
        /// </summary>
        /// <returns></returns>
        public List<Project> GetProject()
        {
            var projects = _context.Projects
               .ToList();
            return projects;
        }
        /// <summary>
        /// get project from project id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Project GetProject(string id)
        {
            var projects = _context.Projects.Where(c=> c.IsActive==true && c.ProjectId == id)
               .FirstOrDefault();
            return projects;
        }
        /// <summary>
        /// deactive project from project id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
        /// <summary>
        /// active project from project id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
