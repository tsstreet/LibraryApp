using LibraryApp.Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Services.DepartmentService
{
    public class DepartmentService: IDepartmentService
    {

        private readonly DataContext _context;

        public DepartmentService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> GetDepartments()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<Department> GetDepartmentById(int id)
        {
            var department = await _context.Departments.FindAsync(id);

            return department;
        }

        public async Task<Department> AddDepartment(Department department)
        {
            var existDepartment = await _context.Departments.FirstOrDefaultAsync(x => x.Name == department.Name);

            if (existDepartment != null)
            {
                throw new Exception("Department already exist");
            }


            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
            return department;
        }

        public async Task<Department> UpdateDepartment(int id, Department department)
        {
            var departmentUpdate = await _context.Departments.FindAsync(id);

            departmentUpdate.Name = department.Name;
            await _context.SaveChangesAsync();

            return departmentUpdate;
        }

        public async Task<Department> DeleteDepartment(int id)
        {

            var department = await _context.Departments.FindAsync(id);

            _context.Departments.Remove(department);

            await _context.SaveChangesAsync();

            return department;
        }

        public async Task<ICollection<Subject>> GetSubjectByDepartment(int id)
        {
            var subject = await _context.Subjects
                .Where(s => s.DepartmentId == id)
                .ToListAsync();

            return subject;
        }
    }
}
