using AutoMapper;
using Azure.Core;
using LibraryApp.Data.Dto;
using LibraryApp.Data.Model;
using LibraryApp.Services.LectureFileService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LectureFileController : ControllerBase
    {
        private readonly ILectureFileService _lectureFileService;
        private readonly IMapper _mapper;
        public LectureFileController(ILectureFileService lectureFileService, IMapper mapper) 
        {
            _lectureFileService = lectureFileService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetLectureFiles()
        {
            var getLectureFile = await _lectureFileService.GetLectureFiles();

            var getLectureFileDto = _mapper.Map<List<LectureFile>>(getLectureFile);

            return Ok(getLectureFileDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubjectById(int id)
        {       
            var getLectureFile = await _lectureFileService.GetLectureFileById(id);
            var getLectureFileDto = _mapper.Map<LectureFile>(getLectureFile);

            return Ok(getLectureFileDto);
        }

        //[HttpPost]
        //public async Task<IActionResult> CreateLecture([FromForm] LectureFileDto lectureFile)
        //{
        //    var lectureFileMap = _mapper.Map<LectureFile>(lectureFile);
        //    var lectureFileGet = await _lectureFileService.CreateLectureFile(lectureFileMap);
            
        //    return Ok(lectureFileGet);
        //}

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] LectureFileDto lectureFile)
        {
                var lectureFileMap = _mapper.Map<LectureFile>(lectureFile);
                var lectureFileGet = await _lectureFileService.CreateLectureFile(lectureFileMap);
                return Ok(lectureFileGet);
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateSubject(int id, SubjectDto subject)
        //{
        //    var subjectMap = _mapper.Map<Subject>(subject);
        //    var subjectUpdate = await _lectureFileService.UpdateSubject(id, subjectMap);

        //    return Ok(subjectMap);
        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLectureFile(int id)
        {
            var deleteLectureFile = await _lectureFileService.DeleteLectureFile(id);

            return Ok(deleteLectureFile);
        }

        [HttpGet("{id}/download")]
        public async Task<IActionResult> Download(int id)
        {
            var lectureFile = await _lectureFileService.DownloadFile(id);

            return File(lectureFile.FileBytes, "application/octet-stream", lectureFile.FileName);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(string searchString)
        {
            var search = await _lectureFileService.Search(searchString);

            return Ok(search);
        }
    }
}
