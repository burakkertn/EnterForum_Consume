namespace EnterForum_Consume.Dtos.Topic
{
    public class CreateTopicDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreateTime { get; set; }
        public int TopicTitleID { get; set; }
        public int UserID { get; set; } //hata vermemesi için
    }
}
