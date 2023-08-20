using LibraryApp.Data.Model;
using NuGet.Protocol.Plugins;

namespace LibraryApp.Services.DepartmentService
{
    public interface IDepartmentService
    {
        Task<List<Department>> GetDepartments();

        Task<Department> GetDepartmentById(int id);

        Task<Department> AddDepartment(Department department);

        Task<Department> UpdateDepartment(int id, Department department);

        Task<Department> DeleteDepartment(int id);

        Task<ICollection<Subject>> GetSubjectByDepartment(int id);


    }
}
