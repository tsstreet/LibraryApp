using AutoMapper;
using LibraryApp.Data.Dto;
using LibraryApp.Data.Model;
using LibraryApp.Services.TeacherService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;
        private readonly IMapper _mapper;
        public TeacherController (ITeacherService teacherService, IMapper mapper) 
        {
            _teacherService = teacherService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetTeacher()
        {
            var teacher = await _teacherService.GetTeachers();

            var teacherDto = _mapper.Map<List<Teacher>>(teacher);
            
            return Ok(teacherDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeacherById(int id)
        {
            var teacher = await _teacherService.GetTeacherById(id);

            var teacherDto = _mapper.Map<Teacher>(teacher);

            return Ok(teacherDto);
            
        }

        [HttpPost]
        public async Task<IActionResult> AddTeacher(TeacherDto teacher)
        {
            var teacherEntity = _mapper.Map<Teacher>(teacher);
            var teacherAdd = await _teacherService.AddTeacher(teacherEntity);
        
            return Ok(teacherAdd);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeacher(int id, TeacherDto teacher)
        {
            var teacherEntity = _mapper.Map<Teacher>(teacher);
            var teacherUpdate = await _teacherService.UpdateTeacher(id, teacherEntity);
            return Ok(teacherUpdate);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            var teacher = await _teacherService.DeleteTeacher(id);

            return Ok(teacher);
        }

        [HttpGet("{id}/schedule")]
        public async Task<IActionResult> GetScheduleByTeacher(int id)
        {
            var schedule = await _teacherService.GetScheduleByTeacher(id);

            return Ok(schedule);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(string searchString)
        {
            var teachers = await _teacherService.Search(searchString);

            return Ok(teachers);
        }
    }
}
