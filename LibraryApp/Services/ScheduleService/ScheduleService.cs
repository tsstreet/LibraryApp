using LibraryApp.Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LibraryApp.Services.ScheduleService
{
    public class ScheduleService : IScheduleService
    {

        private readonly DataContext _context;

        public ScheduleService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Schedule>> GetSchedules()
        {
            return await _context.Schedules.ToListAsync();
        }

        public async Task<Schedule> GetScheduleById(int id)
        {
            var schedule = await _context.Schedules.FindAsync(id);

            return schedule;
        }

        public async Task<Schedule> AddSchedule(Schedule schedule)
        {
            var existSchedule = await _context.Schedules.Where(x => x.Room == schedule.Room).Where
            (x => x.TimeStart < schedule.TimeStart && x.TimeEnd > schedule.TimeStart
            || x.TimeEnd > schedule.TimeEnd && x.TimeStart < schedule.TimeEnd
            || x.TimeStart > schedule.TimeStart && x.TimeStart < schedule.TimeEnd
                                     || x.TimeEnd < schedule.TimeEnd && x.TimeEnd > schedule.TimeStart).FirstOrDefaultAsync();

            if (existSchedule != null)
            {
                throw new Exception("Schedule already exist");
            }

            _context.Schedules.Add(schedule);
            await _context.SaveChangesAsync();
            return schedule;
        }

        public async Task<Schedule> UpdateSchedule(int id, Schedule schedule)
        {
            var scheduleUpdate = await _context.Schedules.FindAsync(id);

            scheduleUpdate.Room = schedule.Room;
            scheduleUpdate.StartDate = schedule.StartDate;
            scheduleUpdate.EndDate = schedule.EndDate;
            scheduleUpdate.TimeStart = schedule.TimeStart;
            scheduleUpdate.TimeEnd = schedule.TimeEnd;

            await _context.SaveChangesAsync();

            return scheduleUpdate;
        }

        public async Task<Schedule> DeleteSchedule(int id)
        {

            var scheduleDelete = await _context.Schedules.FindAsync(id);

            _context.Schedules.Remove(scheduleDelete);

            await _context.SaveChangesAsync();

            return scheduleDelete;
        }

        public async Task<List<Schedule>> Search(string searchString)
        {
            var schedule = from s in _context.Schedules
                           join t in _context.Teachers on s.TeacherId equals t.TeacherId
                           join sj in _context.Subjects on s.SubjectId equals sj.SubjectId
                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                schedule = schedule.Where(s => s.Teacher.FullName.ToLower().Contains(searchString.ToLower())
                                           || s.Subject.Name.ToLower().Contains(searchString.ToLower()));
            }

            return await schedule.ToListAsync();
        }
    }
}
