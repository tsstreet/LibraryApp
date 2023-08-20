//using AutoMapper;
//using Azure.Core;
//using LibraryApp.Data.Dto;
//using LibraryApp.Data.Model;
//using LibraryApp.Services.ScheduleService;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

//namespace LibraryApp.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ScheduleController : ControllerBase
//    {
//        private readonly IScheduleService _scheduleService;
//        private readonly IMapper _mapper;
//        public ScheduleController(IScheduleService scheduleService, IMapper mapper) 
//        {
//            _scheduleService = scheduleService;
//            _mapper = mapper;
//        }

//        [HttpGet]
//        public async Task<IActionResult>GetSchedules()
//        {
//            var getSchedule = await _scheduleService.GetSchedules();

//            var getScheduleDto = _mapper.Map<List<Schedule>>(getSchedule);

//            return Ok(getScheduleDto);
//        }

//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetScheduleById(int id)
//        {       
//            var getSchedule =  await _scheduleService.GetScheduleById(id);
//            var getScheduleDto = _mapper.Map<Schedule>(getSchedule);

//            return Ok(getScheduleDto);
//        }

//        [HttpPost]
//        public async Task<IActionResult> AddSchedule(ScheduleDto schedule)
//        {
//            var scheduleDto = _mapper.Map<Schedule>(schedule);
//            var scheduleMap = await _scheduleService.AddSchedule(scheduleDto);
            
//            return Ok(scheduleMap);
//        }

//        [HttpPut("{id}")]
//        public async Task<IActionResult> UpdateSchedule(int id, ScheduleDto schedule)
//        {
//            var scheduleEntity = _mapper.Map<Schedule>(schedule);
//            var scheduleUpdate = await _scheduleService.UpdateSchedule(id, scheduleEntity);

//            return Ok(scheduleUpdate);
//        }

//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteSchedule(int id)
//        {
//            var deleteSchedule = await _scheduleService.DeleteSchedule(id);

//            return Ok(deleteSchedule);
//        }

//        [HttpGet("search")]
//        public async Task<IActionResult> Search(string searchString)
//        {
//            var schedule = await _scheduleService.Search(searchString);

//            return Ok(schedule);
//        }

//    }
//}
