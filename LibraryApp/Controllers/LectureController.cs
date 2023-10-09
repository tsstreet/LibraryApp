using AutoMapper;
using Azure.Core;
using LibraryApp.Data.Dto;
using LibraryApp.Data.Model;
using LibraryApp.Services.LectureService;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LectureController : ControllerBase
    {
        private readonly ILectureService _lectureService;
        private readonly IMapper _mapper;
        public LectureController(ILectureService lectureService, IMapper mapper) 
        {
            _lectureService = lectureService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetLectureFiles()
        {
            var getLectureFile = await _lectureService.GetLectures();

            var getLectureFileDto = _mapper.Map<List<Lecture>>(getLectureFile);

            return Ok(getLectureFileDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLectureFileById(int id)
        {       
            var getLectureFile = await _lectureService.GetLectureById(id);
            var getLectureFileDto = _mapper.Map<Lecture>(getLectureFile);

            return Ok(getLectureFileDto);
        }

        [HttpPost]
        public async Task<IActionResult> Upload([FromForm] LectureDto lectureFile)
        {
                var lectureFileMap = _mapper.Map<Lecture>(lectureFile);
                var lectureFileGet = await _lectureService.UploadLecture(lectureFileMap);
                return Ok(lectureFileGet);
        }

        [HttpPut("{id}/rename")]
        public async Task<IActionResult> RenameFile(int id, string reName)
        {
            var fileGet = await _lectureService.RenameLectureFile(id, reName);

            return Ok(fileGet);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLectureFile(int id)
        {
            var deleteLectureFile = await _lectureService.DeleteLecture(id);

            return Ok(deleteLectureFile);
        }

        [HttpGet("{id}/download")]
        public async Task<IActionResult> Download(int id)
        {
            var lectureFile = await _lectureService.DownloadFile(id);

            return File(lectureFile.FileBytes, "application/octet-stream", lectureFile.FileName);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(string searchString)
        {
            var search = await _lectureService.Search(searchString);

            return Ok(search);
        }

    }
}
