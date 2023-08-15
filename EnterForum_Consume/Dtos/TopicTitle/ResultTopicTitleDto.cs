using EnterForum_Consume.Dtos.Topic;

namespace EnterForum_Consume.Dtos.TopicTitle
{
    public class ResultTopicTitleDto
    {
        public int TopicTitleID { get; set; }
        public string Name { get; set; }
        public int CategoryID { get; set; }
        public List<ResultTopicDto> Topic { get; set; }
    }
}
