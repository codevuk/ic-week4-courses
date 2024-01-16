using ServiceBasedApplication.Services;
using ServiceBasedApplication.Models;
using System.ComponentModel;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ServiceBasedApplication.Services
{
    public class CourseService: ICourseService
    {
        private readonly SchoolsDbContext _context;

        public CourseService(SchoolsDbContext context)
        {
            _context = context;
        }

        public async Task<Course> AddUpdateCourse(Course course)
        {

            if(course.Id == 0)
            {
                _context.Add(course).State = EntityState.Modified;
            }
            else
            {
                _context.Add(course);
            }
            
            await _context.SaveChangesAsync();

            return course;

        }

        public async Task<List<Course>> GetCourses()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task RemoveCourse(int id)
        {

            var course = await _context.Courses.FindAsync(id);
            
            if (course != null)
            {
                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();
            }
        }
 
    }
}
