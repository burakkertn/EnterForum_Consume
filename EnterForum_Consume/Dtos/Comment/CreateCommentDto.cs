namespace EnterForum_Consume.Dtos.Comment
{
    public class CreateCommentDto
    {
        public string commentUser { get; set; }

        public int topicID { get; set; }


        public string descripiton { get; set; }

        public DateTime commentDate { get; set; }

        public string commmentContent { get; set; }
        public bool commmentState { get; set; }

    }
}
