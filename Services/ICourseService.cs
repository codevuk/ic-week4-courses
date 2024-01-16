using ServiceBasedApplication.Models;

namespace ServiceBasedApplication.Services
{
    public interface ICourseService
    {
        //note we don't need async in the interface
        Task<Models.Course> AddUpdateCourse(Models.Course course);

        Task<List<Course>> GetCourses();

        Task RemoveCourse(int CourseId);

    }
}
