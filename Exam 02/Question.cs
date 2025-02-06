namespace Exam_02
{
    // Base Question Class
    public abstract class Question : ICloneable, IComparable<Question>
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public int Mark { get; set; }
        public List<Answer> AnswerList { get; set; }
        public int CorrectAnswerId { get; set; }

        protected Question(string header, string body, int mark)
        {
            Header = header;
            Body = body;
            Mark = mark;
            AnswerList = new List<Answer>();
        }

        public abstract void DisplayQuestion();

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public int CompareTo(Question? other)
        {
            if (other == null) return 1;
            return Mark.CompareTo(other.Mark);
        }

        public override string ToString()
        {
            return $"Header: {Header}, Body: {Body}, Mark: {Mark}";
        }
    }

    // True or False Question
    public class TrueFalseQuestion : Question
    {
        public TrueFalseQuestion(string header, string body, int mark) : base(header, body, mark) { }

        public override void DisplayQuestion()
        {
            Console.WriteLine($"\n[True/False] {Header}: {Body}");
            Console.WriteLine("Options:");
            Console.WriteLine("1. True");
            Console.WriteLine("2. False");
        }
    }

    // MCQ Question
    public class MCQQuestion : Question
    {
        public MCQQuestion(string header, string body, int mark) : base(header, body, mark) { }

        public override void DisplayQuestion()
        {
            Console.WriteLine($"\n[MCQ] {Header}: {Body}");
            Console.WriteLine("Options:");
            foreach (var answer in AnswerList)
            {
                Console.WriteLine($"{answer.AnswerId}. {answer.AnswerText}");
            }
        }
    }
}
