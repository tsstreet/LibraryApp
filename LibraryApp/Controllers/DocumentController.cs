using AutoMapper;
using Azure.Core;
using LibraryApp.Data.Dto;
using LibraryApp.Data.Model;
using LibraryApp.Services.DocumentService;
using LibraryApp.Services.SubjectService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _documentService;
        private readonly IMapper _mapper;
        public DocumentController(IDocumentService documentService, IMapper mapper)
        {
            _documentService = documentService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetDocuments()
        {
            var getSubject = await _documentService.GetDocuments();

            var getSubjectDto = _mapper.Map<List<Document>>(getSubject);

            return Ok(getSubjectDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDocumentById(int id)
        {
            var getSubject = await _documentService.GetDocumentById(id);
            var getSubjectDto = _mapper.Map<Document>(getSubject);

            return Ok(getSubjectDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddDocument(DocumentDto subject)
        {
            var subjectMap = _mapper.Map<Document>(subject);
            var subjectGet = await _documentService.AddDocument(subjectMap);

            return Ok(subjectGet);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDocument(int id, DocumentDto document)
        {
            var documentMap = _mapper.Map<Document>(document);
            var documentGet = await _documentService.UpdateDocument(id, documentMap);

            return Ok(documentGet);
        }

        [HttpPut("approve/{id}")]
        public async Task<IActionResult> Approve(int id)
        {
            var documentGet = await _documentService.Approve(id);

            return Ok(documentGet);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            var deleteSubject = await _documentService.DeleteDocument(id);

            return Ok(deleteSubject);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(string searchString)
        {
            var search = await _documentService.Search(searchString);

            return Ok(search);
        }
    }
}
