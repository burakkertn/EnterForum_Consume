namespace EnterForum_Consume.Dtos.Comment
{
    public class ResultCommentDto
    {
        public int CommentID { get; set; }

        public string CommentUser { get; set; }
        public int TopicID { get; set; }

        public string? Descripiton { get; set; }
        public DateTime CommentDate { get; set; }
        public string CommmentContent { get; set; }
        public bool CommmentState { get; set; }
  
    }
}
