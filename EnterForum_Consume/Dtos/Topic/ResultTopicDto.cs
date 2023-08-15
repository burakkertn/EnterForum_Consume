using EnterForum_Consume.Dtos.Comment;

namespace EnterForum_Consume.Dtos.Topic
{
    public class ResultTopicDto
    {
        public int TopicID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreateTime { get; set; }
        public int? UserID { get; set; }
        public int? TopicTitleID { get; set; }
     
  

    }
}
