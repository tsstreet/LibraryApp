using LibraryApp.Data.Model;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;

namespace LibraryApp.Services.ScheduleService
{
    public interface IScheduleService
    {
        Task<List<Schedule>> GetSchedules();

        Task<Schedule> GetScheduleById(int id);

        Task<Schedule> AddSchedule(Schedule schedule);

        Task<Schedule> UpdateSchedule(int id, Schedule schedule);

        Task<Schedule> DeleteSchedule(int id);

        Task<List<Schedule>> Search(string searchString);
    }
}
