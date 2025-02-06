namespace Exam_02
{
    public class Answer(int answerId, string answerText)
    {
        public int AnswerId { get; set; } = answerId;
        public string AnswerText { get; set; } = answerText;
    }
}
