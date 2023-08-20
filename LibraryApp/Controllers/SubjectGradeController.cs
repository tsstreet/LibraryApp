//using AutoMapper;
//using Azure.Core;
//using LibraryApp.Data.Dto;
//using LibraryApp.Data.Model;
//using LibraryApp.Services.SubjectGradeService;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

//namespace LibraryApp.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class SubjectGradeController : ControllerBase
//    {
//        private readonly ISubjectGradeService _subjectGradeService;
//        private readonly IMapper _mapper;
//        public SubjectGradeController(ISubjectGradeService subjectGradeService, IMapper mapper) 
//        {
//            _subjectGradeService = subjectGradeService;
//            _mapper = mapper;
//        }

//        [HttpGet]
//        public async Task<IActionResult> GetSubjectGrades()
//        {
//            var getSubjectGrade = await _subjectGradeService.GetSubjectGrades();
//            var getSubjectGradeDto = _mapper.Map<List<SubjectGrade>>(getSubjectGrade);
//            return Ok(getSubjectGradeDto);
//        }

//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetSubjectGradeById(int id)
//        {       
//            var getSubjectGrade =  await _subjectGradeService.GetSubjectGradeById(id);
//            var getSubjectGradeDto = _mapper.Map<SubjectGrade>(getSubjectGrade);
//            return Ok(getSubjectGradeDto);
//        }

//        [HttpPost]
//        public async Task<IActionResult> AddGradeType(SubjectGradeDto subjectGrade)
//        {
//            var subjectGradeMap = _mapper.Map<SubjectGrade>(subjectGrade);
//            var subjectGradeAdd = await _subjectGradeService.AddSubjectGrade(subjectGradeMap);
            
//            return Ok(subjectGradeMap);
//        }

//        [HttpPut("{id}")]
//        public async Task<IActionResult> UpdateGradeType(int id, SubjectGradeDto subjectGrade)
//        {
//            var subjectGradeMap = _mapper.Map<SubjectGrade>(subjectGrade);
//            var subjectGradeUpdate = await _subjectGradeService.UpdateSubjectGrade(id, subjectGradeMap);

//            return Ok(subjectGradeUpdate);
//        }

//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteGradeType(int id)
//        {
//            var deleteSubjectGrade = await _subjectGradeService.DeleteSubjectGrade(id);

//            return Ok(deleteSubjectGrade);
//        }

//        [HttpGet("search")]
//        public async Task<IActionResult> Search(string searchString)
//        {
//            var subjectGrade = await _subjectGradeService.Search(searchString);

//            return Ok(subjectGrade);
//        }

//    }
//}
