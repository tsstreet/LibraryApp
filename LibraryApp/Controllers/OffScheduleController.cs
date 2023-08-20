//using AutoMapper;
//using Azure.Core;
//using LibraryApp.Data.Dto;
//using LibraryApp.Data.Model;
//using LibraryApp.Services.OffScheduleService;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

//namespace LibraryApp.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class OffScheduleController : ControllerBase
//    {
//        private readonly IOffScheduleService _offScheduleService;
//        private readonly IMapper _mapper;
//        public OffScheduleController(IOffScheduleService offScheduleService, IMapper mapper) 
//        {
//            _offScheduleService = offScheduleService;
//            _mapper = mapper;
//        }

//        [HttpGet]
//        public async Task<IActionResult>GetOffSchedules()
//        {
//            var getSchedule = await _offScheduleService.GetOffSchedules();

//            return Ok(getSchedule);
//        }

//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetOffScheduleById(int id)
//        {       
//            var getSchedule =  await _offScheduleService.GetOffScheduleById(id);

//            return Ok(getSchedule);
//        }

//        [HttpPost]
//        public async Task<IActionResult> AddOffSchedule(OffSchedule schedule)
//        {
//            var scheduleAdd = await _offScheduleService.AddOffSchedule(schedule);
            
//            return Ok(scheduleAdd);
//        }

//        [HttpPut("{id}")]
//        public async Task<IActionResult> UpdateOffSchedule(int id, OffSchedule schedule)
//        { 
//            var scheduleUpdate = await _offScheduleService.UpdateOffSchedule(id, schedule);

//            return Ok(scheduleUpdate);
//        }

//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteOffSchedule(int id)
//        {
//            var deleteSchedule = await _offScheduleService.DeleteOffSchedule(id);

//            return Ok(deleteSchedule);
//        }

//        [HttpGet("search")]
//        public async Task<IActionResult> Search(string searchString)
//        {
//            var schedule = await _offScheduleService.Search(searchString);

//            return Ok(schedule);
//        }

//    }
//}
