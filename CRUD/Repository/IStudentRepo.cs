using SchoolManagementSystem.Dto.Student;

namespace CRUD.Repository
{
    public interface IStudentRepo
    {
        Task<List<StudentInfo>> GetAllStudents();
        Task<int> RegistrationStudent(StudentInfo student);
        Task<int> DeleteStudent(string id);
        Task<int> UpdateStudent(StudentInfo student);
    }
}
