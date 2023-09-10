using AutoMapper;
using Azure.Core;
using LibraryApp.Data.Dto;
using LibraryApp.Data.Model;
using LibraryApp.Services.ExamService;
using LibraryApp.Services.SubjectService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IExamService _examService;
        private readonly IMapper _mapper;
        public ExamController(IExamService examService, IMapper mapper)
        {
            _examService = examService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetExams()
        {
            var getExam = await _examService.GetExams();

            var getExamDto = _mapper.Map<List<Exam>>(getExam);

            return Ok(getExamDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExamById(int id)
        {
            var getExam = await _examService.GetExamById(id);
            var getExamDto = _mapper.Map<Exam>(getExam);

            return Ok(getExamDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddExam(ExamDto exam)
        {
            var examMap = _mapper.Map<Exam>(exam);
            var examGet = await _examService.CreateExam(examMap);

            return Ok(examGet);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExam(int id, ExamDto exam)
        {
            var examMap = _mapper.Map<Exam>(exam);
            var examGet = await _examService.UpdateExam(id, examMap);

            return Ok(examGet);
        }

        [HttpPut("{id}/approve")]
        public async Task<IActionResult> Approve(int id)
        {
            var examGet = await _examService.Approve(id);

            return Ok(examGet);
        }

        [HttpPut("{id}/unapprove")]
        public async Task<IActionResult> UnApprove(int id)
        {
            var examGet = await _examService.UnApprove(id);

            return Ok(examGet);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            var deleteExam = await _examService.DeleteExam(id);

            return Ok(deleteExam);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(string searchString)
        {
            var search = await _examService.Search(searchString);

            return Ok(search);
        }
    }
}
