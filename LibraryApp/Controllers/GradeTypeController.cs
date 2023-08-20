//using AutoMapper;
//using Azure.Core;
//using LibraryApp.Data.Dto;
//using LibraryApp.Data.Model;
//using LibraryApp.Services.GradeTypeService;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

//namespace LibraryApp.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class GradeTypeController : ControllerBase
//    {
//        private readonly IGradeTypeService _gradeTypeService;
//        private readonly IMapper _mapper;
//        public GradeTypeController(IGradeTypeService gradeTypeService, IMapper mapper) 
//        {
//            _gradeTypeService = gradeTypeService;
//            _mapper = mapper;
//        }

//        [HttpGet]
//        public async Task<IActionResult>GetGradeTypes()
//        {
//            var getGradeType = await _gradeTypeService.GetGradeTypes();

//            return Ok(getGradeType);
//        }

//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetOffScheduleById(int id)
//        {       
//            var getGradeType =  await _gradeTypeService.GetGradeTypeById(id);

//            return Ok(getGradeType);
//        }

//        [HttpPost]
//        public async Task<IActionResult> AddGradeType(GradeType gradeType)
//        {
//            var gradeTypeAdd = await _gradeTypeService.AddGradeType(gradeType);
            
//            return Ok(gradeTypeAdd);
//        }

//        [HttpPut("{id}")]
//        public async Task<IActionResult> UpdateGradeType(int id, GradeType gradeType)
//        { 
//            var gradeTypeUpdate = await _gradeTypeService.UpdateGradeType(id, gradeType);

//            return Ok(gradeTypeUpdate);
//        }

//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteGradeType(int id)
//        {
//            var deleteGradeType = await _gradeTypeService.DeleteGradeType(id);

//            return Ok(deleteGradeType);
//        }

//        //[HttpGet("search")]
//        //public async Task<IActionResult> Search(string searchString)
//        //{
//        //    var gradeType = await _gradeTypeService.Search(searchString);

//        //    return Ok(gradeType);
//        //}

//    }
//}
