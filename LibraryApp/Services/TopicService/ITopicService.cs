using LibraryApp.Data.Model;
using NuGet.Protocol.Plugins;

namespace LibraryApp.Services.TopicService
{
    public interface ITopicService
    {
        Task<List<Topic>> GetTopics();

        Task<Topic> GetTopicById(int id);

        Task<Topic> AddTopic(Topic topic);

        Task<Topic> UpdateTopic(int id, Topic topic);

        Task<Topic> DeleteTopic(int id);
        Task<List<Topic>> Search(string searchString);

        Task<ICollection<Lecture>> GetLectureByTopic(int id);


    }
}
