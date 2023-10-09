using AutoMapper;
using Azure.Core;
using LibraryApp.Data.Dto;
using LibraryApp.Data.Model;
using LibraryApp.Services.TopicService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly ITopicService _topicService;
        private readonly IMapper _mapper;
        public TopicController(ITopicService topicService, IMapper mapper)
        {
            _topicService = topicService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetTopics()
        {
            var getTopic = await _topicService.GetTopics();

            var getTopicDto = _mapper.Map<List<Topic>>(getTopic);

            return Ok(getTopicDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExamById(int id)
        {
            var getTopic = await _topicService.GetTopicById(id);
            var getTopicDto = _mapper.Map<Topic>(getTopic);

            return Ok(getTopicDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddExam(TopicDto topic)
        {
            var topicMap = _mapper.Map<Topic>(topic);
            var topicGet = await _topicService.AddTopic(topicMap);

            return Ok(topicGet);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExam(int id, TopicDto topic)
        {
            var topicMap = _mapper.Map<Topic>(topic);
            var topicGet = await _topicService.UpdateTopic(id, topicMap);

            return Ok(topicGet);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTopic(int id)
        {
            var deleteTopic = await _topicService.DeleteTopic(id);

            return Ok(deleteTopic);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(string searchString)
        {
            var search = await _topicService.Search(searchString);

            return Ok(search);
        }

        [HttpGet("{id}/lecture")]
        public async Task<IActionResult> GetLectureByTopic(int id)
        {
            var lecture = await _topicService.GetLectureByTopic(id);

            return Ok(lecture);
        }
    }
}
