using CRUD.DbConnection;
using CRUD.Repository;
using CRUD.Services;
namespace CRUD.Dependency
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection Services)
        {

            Services.AddTransient<DapperDbConnection>();
            Services.AddTransient<IStudentRepo,StudentRepo>();
            Services.AddTransient<IStudentService, StudenService>();
        }
    }
}
