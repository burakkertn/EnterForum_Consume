namespace EnterForum_Consume.Dtos.Comment
{
    public class ResultCommentDto
    {
        public int CommentID { get; set; }
        public int TopicID { get; set; }
        public int UserID { get; set; }
        public string Descripiton { get; set; }
        public DateTime CommentDate { get; set; }
    }
}
