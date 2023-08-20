//using AutoMapper;
//using Azure.Core;
//using LibraryApp.Data.Dto;
//using LibraryApp.Data.Model;
//using LibraryApp.Services.AcademicYearService;
//using LibraryApp.Services.FalcutyService;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace LibraryApp.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class AcademicYearController : ControllerBase
//    {
//        private readonly IAcademicYearService _academicYearService;
//        private readonly IMapper _mapper;
//        public AcademicYearController(IAcademicYearService academicYearService, IMapper mapper) 
//        {

//            _academicYearService = academicYearService;
//            _mapper = mapper;
//        }

//        [HttpGet]
//        public async Task<IActionResult> GetAcademicYear()
//        {
//            var academicYear = await _academicYearService.GetAcademicYears();

//            var academicYearDto = _mapper.Map<List<AcademicYear>>(academicYear);

//            return Ok(academicYearDto);
//        }

//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetAcademicYearById(int id)
//        {
            
//            var academicYear = await _academicYearService.GetAcademicYearById(id);

//            var academicYearDto = _mapper.Map<AcademicYear>(academicYear);

//            return Ok(academicYearDto);
//        }

//        [HttpPost]
//        public async Task<IActionResult> AddAcademicYear(AcademicYearDto academicYear)
//        {         
//            var academicYearAdd = _mapper.Map<AcademicYear>(academicYear);
//            var academicYearMap = await _academicYearService.AddAcademicYear(academicYearAdd);

//            return Ok(academicYearMap);
//        }

//        [HttpPut("{id}")]
//        public async Task<IActionResult> UpdateAcademicYear(int id, AcademicYearDto academicYear)
//        {
//            var academicYearUpdate = _mapper.Map<AcademicYear>(academicYear);
//            var academicYearMap = await _academicYearService.UpdateAcademicYear(id, academicYearUpdate);

//            return Ok(academicYearMap);
//        }

//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteAcademicYear(int id)
//        {
//            var academicYear = await _academicYearService.DeleteAcademicYear(id);

//            return Ok(academicYear);
//        }

//        [HttpGet("{id}/class")]
//        public async Task<IActionResult> GetClassByAcademicYear(int id)
//        {
//            var getClass = await _academicYearService.GetClassByAcademicYear(id);

//            //var getClassDto = _mapper.Map<List<Class>>(getClass);

//            return Ok(getClass);
//        }

//        [HttpGet("search")]
//        public async Task<IActionResult> Search(string searchString)
//        {
//            var search = await _academicYearService.Search(searchString);

//            return Ok(search);
//        }
//    }
//}
