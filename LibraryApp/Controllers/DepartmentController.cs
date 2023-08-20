//using AutoMapper;
//using LibraryApp.Data.Dto;
//using LibraryApp.Data.Model;
//using LibraryApp.Services.DepartmentService;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace LibraryApp.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class DepartmentController : ControllerBase
//    {
//        private readonly IDepartmentService _departmentService;
//        private readonly IMapper _mapper;

//        public DepartmentController(IDepartmentService departmentService, IMapper mapper) 
//        {
//            _departmentService = departmentService;
//            _mapper = mapper;
//        }

//        [HttpGet]
//        public async Task<IActionResult> GetDepartments()
//        {
//            var department = await _departmentService.GetDepartments();

//            var departmentDto = _mapper.Map<List<Department>>(department);

//            return Ok(departmentDto);
//        }

//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetDepartmentById(int id)
//        {
//            var department = await _departmentService.GetDepartmentById(id);

//            var departmentDto = _mapper.Map<Department>(department);

//            return Ok(departmentDto);
//        }

//        [HttpPost]
//        public async Task<IActionResult> AddDepartment(DepartmentDto department)
//        {

//            var departmentAdd = _mapper.Map<Department>(department);

//            var departmentMap = await _departmentService.AddDepartment(departmentAdd);

//            return Ok(departmentMap);

//        }

//        [HttpPut("{id}")]
//        public async Task<IActionResult> UpdateDepartment(int id, DepartmentDto department)
//        {
//            var departmentUpdate = _mapper.Map<Department>(department);

//            var departmentMap = await _departmentService.AddDepartment(departmentUpdate);

//            return Ok(departmentMap);
//        }

//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteDepartment(int id)
//        {
//            var department = await _departmentService.DeleteDepartment(id);

//            return Ok(department);
//        }


//        [HttpGet("{id}/subject")]
//        public async Task<IActionResult> GetSubjectByDepartment(int id)
//        {
//            var getSubject = await _departmentService.GetSubjectByDepartment(id);


//            return Ok(getSubject);
//        }
//    }
//}
