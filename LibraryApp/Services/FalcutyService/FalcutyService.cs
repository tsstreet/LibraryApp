using LibraryApp.Data.Model;
using LibraryApp.Services.FalcutyService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Services.FalcutyService
{
    public class FalcutyService: IFalcutyService
    {

        private readonly DataContext _context;

        public FalcutyService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Falcuty>> GetFalcuties()
        {
            return await _context.Falcuties.ToListAsync();
        }

        public async Task<Falcuty> GetFalcutyById(int id)
        {
            var falcuty = await _context.Falcuties.FindAsync(id);

            return falcuty;
        }

        public async Task<Falcuty> AddFalcuty(Falcuty falcuty)
        {
            var existFalcuty = await _context.Falcuties.FirstOrDefaultAsync(x => x.Name == falcuty.Name );

            if (existFalcuty != null)
            {
                throw new Exception("Falcuty already exist");
            }


            _context.Falcuties.Add(falcuty);
            await _context.SaveChangesAsync();
            return falcuty;
        }

        public async Task<Falcuty> UpdateFalcuty(int id, Falcuty falcuty)
        {
            var falcutyUpdate = await _context.Falcuties.FindAsync(id);

            falcutyUpdate.Name = falcuty.Name;
            await _context.SaveChangesAsync();

            return falcutyUpdate;
        }

        public async Task<Falcuty> DeleteFalcuty(int id)
        {

            var falcuty = await _context.Falcuties.FindAsync(id);

            _context.Falcuties.Remove(falcuty);

            await _context.SaveChangesAsync();

            return falcuty;
        }

        public async Task<List<Falcuty>> Search(string searchString)
        {
            var falcuty = from s in _context.Falcuties
                       select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                falcuty = falcuty.Where(s => s.Name.ToLower().Contains(searchString.ToLower()));
            }

            return await falcuty.ToListAsync();
        }

        public async Task<ICollection<Subject>> GetSubjectByFalcuty(int id)
        {
            var subject = await _context.Subjects
                .Where(s => s.FalcutyId == id)
                .ToListAsync();

            return subject;
        }

    }
}
