using CRUD.Models;
using SchoolManagementSystem.Dto.Student;

namespace CRUD.Services
{
    public interface IStudentService
    {
        Task<Response> GetAllStudents();
        Task<Response> RegistrationStudent(StudentInfo student);
        Task<Response> DeleteStudent(string id);
        Task<Response> UpdateStudent(StudentInfo student);
    }
}

