using LibraryApp.Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LibraryApp.Services.OffScheduleService
{
    public class OffScheduleService : IOffScheduleService
    {

        private readonly DataContext _context;

        public OffScheduleService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<OffSchedule>> GetOffSchedules()
        {
            return await _context.OffSchedules.ToListAsync();
        }

        public async Task<OffSchedule> GetOffScheduleById(int id)
        {
            var schedule = await _context.OffSchedules.FindAsync(id);

            return schedule;
        }

        public async Task<OffSchedule> AddOffSchedule(OffSchedule schedule)
        {
            var existSchedule = await _context.OffSchedules.Where(x => x.Name == schedule.Name).FirstOrDefaultAsync();

            if (existSchedule != null)
            {
                throw new Exception("Schedule already exist");
            }

            _context.OffSchedules.Add(schedule);
            await _context.SaveChangesAsync();
            return schedule;
        }

        public async Task<OffSchedule> UpdateOffSchedule(int id, OffSchedule schedule)
        {
            var scheduleUpdate = await _context.OffSchedules.FindAsync(id);

            scheduleUpdate.Name = schedule.Name;
            scheduleUpdate.StartDate = schedule.StartDate;
            scheduleUpdate.EndDate = schedule.EndDate;

            await _context.SaveChangesAsync();

            return scheduleUpdate;
        }

        public async Task<OffSchedule> DeleteOffSchedule(int id)
        {

            var scheduleDelete = await _context.OffSchedules.FindAsync(id);

            _context.OffSchedules.Remove(scheduleDelete);

            await _context.SaveChangesAsync();

            return scheduleDelete;
        }

        public async Task<List<OffSchedule>> Search(string searchString)
        {
            var schedule = from s in _context.OffSchedules
                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                schedule = schedule.Where(s => s.Name.ToLower().Contains(searchString.ToLower())
                                          );
            }

            return await schedule.ToListAsync();
        }
    }
}
