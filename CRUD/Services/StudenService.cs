using CRUD.Models;
using CRUD.Repository;
using SchoolManagementSystem.Dto.Student;

namespace CRUD.Services
{
    public class StudenService : IStudentService
    {
        private readonly IStudentRepo _studentRepository;
        public StudenService(IStudentRepo studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<Response> GetAllStudents()
        {
            var response = new Response();
            try
            {
                var students = await _studentRepository.GetAllStudents();
                response.Data = students;
                response.Message = "Success";
                response.Status = 100;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = 500;
            }
            return response;
        }
        public async Task<Response> RegistrationStudent(StudentInfo student)
        {
            var response = new Response();
            try
            {
                var result = await _studentRepository.RegistrationStudent(student);
                if (result > 0)
                {
                    response.Message = "Success";
                    response.Status = 100;
                }
                else
                {
                    response.Message = "Insert not success";
                    response.Status = 100;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = 500;
            }
            return response;
        }   
        public async Task<Response> DeleteStudent (string id)
        {
            var response = new Response();
            try
            {
                var result = await _studentRepository.DeleteStudent(id);
                if (result > 0)
                {
                    response.Message = "Success";
                    response.Status = 100;
                }
                else
                {
                    response.Message = "Delete not success";
                    response.Status = 100;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = 500;
            }
            return response;
        }
        public async Task<Response> UpdateStudent(StudentInfo student)
        {
            var response = new Response();
            try
            {

                var result = await _studentRepository.UpdateStudent(student);
                if (result > 0)
                {
                    response.Message = "Success";
                    response.Status = 100;
                }
                else
                {
                    response.Message = "Update not success";
                    response.Status = 100;
                }
                
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = 500;
            }
            return response;
        }
        
    }
}
