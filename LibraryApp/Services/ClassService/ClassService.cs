using LibraryApp.Data.Model;
using LibraryApp.Services.ClassService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Services.ClassService
{
    public class ClassService : IClassService
    {

        private readonly DataContext _context;

        public ClassService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Class>> GetClasses()
        {
            return await _context.Classes.ToListAsync();
        }

        public async Task<Class> GetClassById(int id)
        {
            var classGet = await _context.Classes.FindAsync(id);

            return classGet;
        }

        public async Task<Class> AddClass(Class request)
        {
            //var academicYear = await _context.AcademicYears.Where(x => x.AcademicYearId == AcademicYearId).FirstOrDefaultAsync();
            //var department = await _context.Departments.Where(x => x.DepartmentId == DepartmentId).FirstOrDefaultAsync();

            var existClass = await _context.Classes.FirstOrDefaultAsync(x => x.ClassName == request.ClassName);

            if (existClass != null)
            {
                throw new Exception("Class already exist");
            }

            //var newClass = new Class
            //{
            //    ClassName = classDto.ClassName,
            //    AcademicYearId = classDto.AcademicYearId,
            //    DepartmentId = classDto.DepartmentId,
            //    Tuition = classDto.Tuition,
            //    NumOfStd = classDto.NumOfStd,
            //    Description = classDto.Description,
            //    ImageUrl = classDto.ImageUrl,
            //    Active = classDto.Active,
            //};

            _context.Classes.Add(request);
            await _context.SaveChangesAsync();
            return request;
        }

        public async Task<Class> UpdateClass(int id, Class request)
        {
            var classUpdate = await _context.Classes.FindAsync(id);

            classUpdate.ClassName = request.ClassName;
            classUpdate.NumOfStd = request.NumOfStd;
            classUpdate.AcademicYearId = request.AcademicYearId;
            classUpdate.DepartmentId = request.DepartmentId;
            classUpdate.Active = request.Active;
            classUpdate.Description = request.Description;
            classUpdate.Tuition = request.Tuition;

            await _context.SaveChangesAsync();

            return classUpdate;
        }

        public async Task<Class> DeleteClass(int id)
        {

            var classDelete = await _context.Classes.FindAsync(id);

            _context.Classes.Remove(classDelete);

            await _context.SaveChangesAsync();

            return classDelete;
        }

        public async Task<ICollection<Student>> GetStudentByClass(int classId)
        {
            var students = await _context.ClassStudents.Where(x => x.ClassId == classId).Select(c => c.Student).ToListAsync();

            return students;
        }

        public async Task<ICollection<Subject>> GetSubjectByClass(int id)
        {
            var subjects = await _context.Classes
                        .Where(c => c.ClassId == id)
                        .SelectMany(c => c.Schedules)
                        .Select(s => s.Subject)
        .               Distinct()
                        .ToListAsync();

            return subjects;
        }

        public async Task<ICollection<Schedule>> GetScheduleByClass(int id)
        {
            var schedule = await _context.Schedules
                                    .Where(c => c.ClassId == id)
                                    .ToListAsync();
            return schedule;
        }

        public async Task<List<Class>> Search(string searchString)
        {
            var search = from s in _context.Classes
                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                search = search.Where(s => s.ClassCode.ToLower().Contains(searchString.ToLower())
                                           || s.ClassName.ToLower().Contains(searchString.ToLower()));
            }

            return await search.ToListAsync();
        }

        public async Task<bool> RemoveSubjectFromClass(int classId, int subjectId)
        {
            var cls = await _context.Classes.FindAsync(classId);
            var subject = await _context.Subjects.FindAsync(subjectId);

            if (cls != null && subject != null)
            {
                var schedule = await _context.Schedules
                    .SingleOrDefaultAsync(s => s.ClassId == classId && s.SubjectId == subjectId);

                if (schedule != null)
                {
                    _context.Schedules.Remove(schedule);
                    await _context.SaveChangesAsync();
                }
            }

            return true;
        }
    }
}
