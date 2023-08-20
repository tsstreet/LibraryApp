using LibraryApp.Data.Model;
using LibraryApp.Services.GradeTypeService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LibraryApp.Services.GradeTypeService
{
    public class GradeTypeService : IGradeTypeService
    {

        private readonly DataContext _context;

        public GradeTypeService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<GradeType>> GetGradeTypes()
        {
            return await _context.GradeTypes.ToListAsync();
        }

        public async Task<GradeType> GetGradeTypeById(int id)
        {
            var gradeType = await _context.GradeTypes.FindAsync(id);

            return gradeType;
        }

        public async Task<GradeType> AddGradeType (GradeType gradeType)
        {
            var existGradeType = await _context.GradeTypes.Where(x => x.Name == gradeType.Name).FirstOrDefaultAsync();

            if (existGradeType != null)
            {
                throw new Exception("Grade Type already exist");
            }

            _context.GradeTypes.Add(gradeType);
            await _context.SaveChangesAsync();
            return gradeType;
        }

        public async Task<GradeType> UpdateGradeType(int id, GradeType gradeType)
        {
            var update = await _context.GradeTypes.FindAsync(id);

            update.Name = gradeType.Name;
            update.Weight = gradeType.Weight;

            await _context.SaveChangesAsync();

            return update;
        }

        public async Task<GradeType> DeleteGradeType(int id)
        {

            var delete = await _context.GradeTypes.FindAsync(id);

            _context.GradeTypes.Remove(delete);

            await _context.SaveChangesAsync();

            return delete;
        }

        public async Task<List<GradeType>> Search(string searchString)
        {
            var search = from s in _context.GradeTypes
                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                search = search.Where(s => s.Name.ToLower().Contains(searchString.ToLower())
                                          );
            }

            return await search.ToListAsync();
        }
    }
}
