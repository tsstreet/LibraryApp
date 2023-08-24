//using AutoMapper;
//using LibraryApp.Data.Dto;
//using LibraryApp.Data.Model;
//using LibraryApp.Services.StudentService;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace LibraryApp.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class StudentController : ControllerBase
//    {
//        private readonly IStudentService _studentService;
//        private readonly IMapper _mapper;

//        public StudentController (IStudentService studentService, IMapper mapper) 
//        {
//            _studentService = studentService;
//            _mapper = mapper;
//        }

//        [HttpGet]
//        public async Task<IActionResult> GetStudent()
//        {
//            var student = await _studentService.GetStudents();

//            var studentDto = _mapper.Map<List<Student>>(student);

//            return Ok(studentDto);

//        }

//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetStudentById(int id)
//        {
//            var student = await _studentService.GetStudentById(id);

//            var studentDto = _mapper.Map<Student>(student);

//            return Ok(studentDto);

//        }

//        [HttpPost]
//        public async Task<IActionResult> AddStudent(StudentDto student, int classId)
//        {
//            var studentDto = _mapper.Map<Student>(student);
//            var addedStudent = await _studentService.AddStudent(studentDto, classId);
//            var addedStudentDto = _mapper.Map<StudentDto>(addedStudent);


//            return Ok(addedStudentDto);
//        }

//        [HttpPost("register")]
//        public async Task<IActionResult> Register(Register student)
//        {
//            var studentDto = _mapper.Map<Student>(student);
//            var addedStudent = await _studentService.RegisterStudent(studentDto);

//            return Ok(addedStudent);
//        }

//        [HttpPut("{id}")]
//        public async Task<IActionResult> UpdateStudent(int id, StudentDto student)
//        {
//            var studentEntity = _mapper.Map<Student>(student);
//            var studentUpdate = await _studentService.UpdateStudent(id, studentEntity);
            
//            return Ok(studentUpdate);
//        }

//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteStudent(int id)
//        {
//            var student = await _studentService.DeleteStudent(id);

//            return Ok(student);
//        }

//        [HttpGet("{id}/class")]
//        public async Task<IActionResult> GetClassByStudent(int id)
//        {
//            var getClass = await _studentService.GetClassesByStudent(id);
//            return Ok(getClass);
//        }

//        [HttpGet("{id}/schedule")]
//        public async Task<IActionResult> GetStudentSchedule(int id)
//        {
//            var schedule = await _studentService.GetStudentSchedule(id);
//            return Ok(schedule);
//        }

//        [HttpPost("class register")]
//        public async Task<IActionResult> RegisterStudentForClass(int studentId, int classId)
//        {
//            var studentAdd = await _studentService.RegisterStudentForClass(studentId, classId);
//            return Ok(studentAdd);
//        }

//        [HttpDelete("class unregister")]
//        public async Task<IActionResult> UnregisterStudentFromClass(int studentId, int classId)
//        {
//            var unregister = await _studentService.UnregisterStudentFromClass(studentId, classId);

//            return Ok(unregister);
//        }

//        [HttpGet("search")]
//        public async Task<IActionResult> Search(string searchString)
//        {
//            var students = await _studentService.Search(searchString);

//            return Ok(students);
//        }
//    }
//}

