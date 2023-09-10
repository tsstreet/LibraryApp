using AutoMapper;
using Azure.Core;
using LibraryApp.Data.Dto;
using LibraryApp.Data.Model;
using LibraryApp.Services.PrivateFileService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrivateFileController : ControllerBase
    {
        private readonly IPrivateFileService _privateFileService;
        private readonly IMapper _mapper;
        public PrivateFileController(IPrivateFileService privateFileService, IMapper mapper) 
        {
            _privateFileService = privateFileService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPrivateFiles()
        {
            var getPrivateFile = await _privateFileService.GetPrivateFiles();

            var getPrivateFileDto = _mapper.Map<List<PrivateFile>>(getPrivateFile);

            return Ok(getPrivateFileDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPrivateFileById(int id)
        {       
            var getPrivateFile = await _privateFileService.GetPrivateFileById(id);
            var getPrivateFileDto = _mapper.Map<PrivateFile>(getPrivateFile);

            return Ok(getPrivateFileDto);
        }


        [HttpPost]
        public async Task<IActionResult> Upload([FromForm] PrivateFile privateFile)
        {
                var privateFileMap = _mapper.Map<PrivateFile>(privateFile);
                var privateFileGet = await _privateFileService.UploadPrivateFile(privateFileMap);
                return Ok(privateFileGet);
        }

        [HttpPut("{id}/rename")]
        public async Task<IActionResult> RenameFile(int id, string reName)
        {
            var fileGet = await _privateFileService.RenamePrivateFile(id, reName);

            return Ok(fileGet);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLectureFile(int id)
        {
            var deletePrivateFile = await _privateFileService.DeletePrivateFile(id);

            return Ok(deletePrivateFile);
        }

        [HttpGet("{id}/download")]
        public async Task<IActionResult> Download(int id)
        {
            var privateFile = await _privateFileService.DownloadFile(id);

            return File(privateFile.FileBytes, "application/octet-stream", privateFile.FileName);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(string searchString)
        {
            var search = await _privateFileService.Search(searchString);

            return Ok(search);
        }
    }
}
