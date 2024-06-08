using CRUD.DbConnection;
using CRUD.Repository;
using Dapper;
using SchoolManagementSystem.Dto.Student;
namespace CRUD.Repository
{

    public class StudentRepo : IStudentRepo
    {
        private readonly DapperDbConnection _connection;
        
        public StudentRepo(DapperDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<List<StudentInfo>> GetAllStudents()
        {
            try
            {

                List<StudentInfo> students = new List<StudentInfo>();
                using (var conn = _connection.CreateConnection())
                {
                    string query = @"SELECT * FROM Student";
                  /**/  conn.Open();

                    var studentsLst = await conn.QueryAsync<StudentInfo>(query);
                    students = studentsLst.ToList();

                }
                return students;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> RegistrationStudent(StudentInfo student)
        {
            try
            {
                int isSuccess = 0;
                using (var conn = _connection.CreateConnection())
                {
                    student.Creation_on = DateTime.Now;
                    student.Registration_id = Guid.NewGuid().ToString();

                    string query = @"INSERT INTO student ( Creation_on, Registration_id, Id, Name, Gender, Class, Email, Hobbie, Address, Activity_log, Is_running, Is_deleted)
                                    VALUES (@Creation_on, @Registration_id, @Id, @Name, @Gender, @Class, @Email, @Hobbie, @Address, @Activity_log, @Is_running, @Is_deleted);";
                   

                    isSuccess =  await conn.ExecuteAsync(query, student);
                    
                }
                return isSuccess;
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> DeleteStudent (string id)
        {
            try
            {
                int isSuccess = 0;
                using (var conn = _connection.CreateConnection())
                {
                    string query = @"DELETE FROM student
                                     WHERE (id = @id AND is_deleted=false)";
                    isSuccess = await conn.ExecuteAsync(query, new { id = id });

                }
                return isSuccess;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }

        public async Task<int> UpdateStudent(StudentInfo student)
        {
            try
            {
                int isSuccess = 0;
                using (var conn = _connection.CreateConnection())
                {
                    string query = @"UPDATE student
                                    SET Id = @Id,
                                        
                                        Name = @Name,
                                        Gender = @Gender,
                                        Class = @Class,
                                        Email = @Email,
                                        Hobbie = @Hobbie,
                                        Address = @Address,
                                        Activity_log = @Activity_log,
                                        Is_running = @Is_running
                                      
                                    WHERE Registration_id = @Registration_id AND Is_deleted=false";
                     isSuccess = await conn.ExecuteAsync(query, student);
                }
                return isSuccess;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
