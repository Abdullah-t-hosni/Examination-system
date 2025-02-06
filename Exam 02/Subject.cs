namespace Exam_02
{
    public class Subject(int subjectId, string subjectName)
    {
        public int SubjectId { get; set; } = subjectId;
        public string SubjectName { get; set; } = subjectName;
        public Exam? Exam { get; set; }

        public void CreateExam(Exam exam)
        {
            Exam = exam;
        }

        public override string ToString()
        {
            return $"Subject ID: {SubjectId}, Subject Name: {SubjectName}";
        }
    }
}
