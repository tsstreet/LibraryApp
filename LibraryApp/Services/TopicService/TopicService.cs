using LibraryApp.Data.Dto;
using LibraryApp.Data.Model;
using LibraryApp.Services.TopicService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Services.TopicService
{
    public class TopicService : ITopicService
    {

        private readonly DataContext _context;

        public TopicService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Topic>> GetTopics()
        {
            return await _context.Topics.ToListAsync();
        }

        public async Task<Topic> GetTopicById(int id)
        {
            var topic = await _context.Topics.FirstOrDefaultAsync(x=> x.TopicId == id);

            return topic;
        }

        public async Task<Topic> AddTopic(Topic topic)
        {

            var existTopic = await _context.Topics.FirstOrDefaultAsync(x => x.Name == topic.Name);

            if (existTopic != null)
            {
                throw new Exception("Topic already exist");
            }

            _context.Topics.Add(topic);
            await _context.SaveChangesAsync();
            return topic;
        }

        public async Task<ICollection<Lecture>> GetLectureByTopic(int id)
        {
            var lecture = await _context.Topics.Where(x => x.TopicId == id).Select(c => c.Lectures).FirstOrDefaultAsync();

            return lecture.ToList();
        }

            //public async Task<Topic> AddTopic(Topic topic)
            //{
            //    var existTopic = await _context.Topics.FirstOrDefaultAsync(x => x.Name == topic.Name);

            //    if (existTopic != null)
            //    {
            //        throw new Exception("Topic already exist");
            //    }

            //    var newTopic = new Topic
            //    {
            //        Name = topic.Name,
            //    };

            //    if (topic.Lectures != null)
            //    {
            //        newTopic.Lectures = topic.Lectures.Select(l => new Lecture
            //        {
            //        }).ToList();
            //    }

            //    _context.Topics.Add(topic);
            //    await _context.SaveChangesAsync();
            //    return topic;
            //}

            public async Task<Topic> UpdateTopic(int id, Topic topic)
        {
            var topicUpdate = await _context.Topics.FindAsync(id);

            topicUpdate.Name = topic.Name;
            topicUpdate.Description = topic.Description;

            await _context.SaveChangesAsync();

            return topicUpdate;
        }

        public async Task<Topic> DeleteTopic(int id)
        {

            var topic = await _context.Topics.FindAsync(id);

            _context.Topics.Remove(topic);

            await _context.SaveChangesAsync();

            return topic;
        }

        public async Task<List<Topic>> Search(string searchString)
        {
            var topic = from s in _context.Topics
                          select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                topic = topic.Where(s => s.Name.ToLower().Contains(searchString.ToLower()));
            }

            return await topic.ToListAsync();
        }
    }
}
