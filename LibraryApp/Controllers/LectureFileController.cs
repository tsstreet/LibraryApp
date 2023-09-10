using AutoMapper;
using Azure.Core;
using LibraryApp.Data.Dto;
using LibraryApp.Data.Model;
using LibraryApp.Services.LectureFileService;
using Microsoft.AspNetCore.Hosting;
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
        public async Task<IActionResult> GetLectureFileById(int id)
        {       
            var getLectureFile = await _lectureFileService.GetLectureFileById(id);
            var getLectureFileDto = _mapper.Map<LectureFile>(getLectureFile);

            return Ok(getLectureFileDto);
        }

        [HttpPost]
        public async Task<IActionResult> Upload([FromForm] LectureFileDto lectureFile)
        {
                var lectureFileMap = _mapper.Map<LectureFile>(lectureFile);
                var lectureFileGet = await _lectureFileService.UploadLectureFile(lectureFileMap);
                return Ok(lectureFileGet);
        }

        [HttpPut("{id}/rename")]
        public async Task<IActionResult> RenameFile(int id, string reName)
        {
            var fileGet = await _lectureFileService.RenameLectureFile(id, reName);

            return Ok(fileGet);
        }


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
