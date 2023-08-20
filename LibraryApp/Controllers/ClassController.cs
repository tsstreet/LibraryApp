//using AutoMapper;
//using Azure.Core;
//using LibraryApp.Data.Dto;
//using LibraryApp.Data.Model;
//using LibraryApp.Services.ClassService;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace LibraryApp.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ClassController : ControllerBase
//    {
//        private readonly IClassService _classService;
//        private readonly IMapper _mapper;
//        public ClassController(IClassService classService, IMapper mapper) 
//        {
//            _classService = classService;
//            _mapper = mapper;
//        }

//        [HttpGet]
//        public async Task<IActionResult>GetClasses()
//        {
//            var getClass = await _classService.GetClasses();

//            var getClassDto = _mapper.Map<List<Class>>(getClass);

//            return Ok(getClassDto);
//        }

//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetClassById(int id)
//        {       
//            var getClass = await _classService.GetClassById(id);
//            var getClassDto = _mapper.Map<Class>(getClass);

//            return Ok(getClassDto);
//        }

//        [HttpPost]
//        public async Task<IActionResult> AddClass(ClassDto request)
//        {
//            //var classAdd = await _classService.AddClass(classDto);

//            var classEntity = _mapper.Map<Class>(request);
//            var classMap = await _classService.AddClass(classEntity);
            
//            return Ok(classMap);
//        }

//        [HttpPut("{id}")]
//        public async Task<IActionResult> UpdateClass(int id, ClassDto request)
//        {
//            var classEntity = _mapper.Map<Class>(request);
//            var classUpdate = await _classService.UpdateClass(id, classEntity);

//            return Ok(classUpdate);
//        }

//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteClass(int id)
//        {
//            var deleteClass = await _classService.DeleteClass(id);

//            return Ok(deleteClass);
//        }

//        [HttpGet("{id}/subject")]
//        public async Task<IActionResult> GetSubjectByClass(int id)
//        {
//            var subject = await _classService.GetSubjectByClass(id);

//            return Ok(subject);
//        }

//        [HttpGet("{id}/student")]
//        public async Task<IActionResult> GetStudentByClass(int id)
//        {
//            var student = await _classService.GetStudentByClass(id);
//            return Ok(student);
//        }

//        [HttpGet("{id}/schedule")]
//        public async Task<IActionResult> GetScheduleByClass(int id)
//        {
//            var schedule = await _classService.GetScheduleByClass(id);
//            return Ok(schedule);
//        }

//        [HttpDelete("remove subject from class")]
//        public async Task<IActionResult> RemoveSubjectFromClass(int subjectId, int classId)
//        {
//            var remove = await _classService.RemoveSubjectFromClass(subjectId, classId);

//            return Ok(remove);
//        }

//    }
//}
