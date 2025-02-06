namespace Exam_02
{
    // Base Exam Class
    public abstract class Exam
    {
        public DateTime ExamTime { get; set; }
        public int NumberOfQuestions { get; set; }
        public List<Question> Questions { get; set; }

        public Exam(DateTime examTime, int numberOfQuestions)
        {
            ExamTime = examTime;
            NumberOfQuestions = numberOfQuestions;
            Questions = new List<Question>();
        }

        public abstract void ShowExam();
        public abstract void TakeExam();
    }

    // Final Exam
    public class FinalExam : Exam
    {
        public FinalExam(DateTime examTime, int numberOfQuestions) : base(examTime, numberOfQuestions) { }

        public override void ShowExam()
        {
            Console.WriteLine("\n===== Final Exam =====");
            Console.WriteLine($"Exam Time: {ExamTime}");
            Console.WriteLine($"Number of Questions: {NumberOfQuestions}");
            Console.WriteLine("-----------------------------");

            foreach (var question in Questions)
            {
                question.DisplayQuestion();
            }
        }

        public override void TakeExam()
        {
            int score = 0;
            Console.WriteLine("\n===== Answer the Questions =====");

            foreach (var question in Questions)
            {
                question.DisplayQuestion();
                Console.Write("Your answer (enter the option number): ");
                string? input = Console.ReadLine();

                if (int.TryParse(input, out int userAnswer))
                {
                    if (userAnswer == question.CorrectAnswerId)
                    {
                        Console.WriteLine("Correct!");
                        score += question.Mark;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid option number.");
                }
            }

            Console.WriteLine("\n===== Exam Results =====");
            Console.WriteLine($"Your score: {score} out of {NumberOfQuestions * 10}");
        }
    }

    // Practical Exam
    public class PracticalExam : Exam
    {
        public PracticalExam(DateTime examTime, int numberOfQuestions) : base(examTime, numberOfQuestions) { }

        public override void ShowExam()
        {
            Console.WriteLine("\n===== Practical Exam =====");
            Console.WriteLine($"Exam Time: {ExamTime}");
            Console.WriteLine($"Number of Questions: {NumberOfQuestions}");
            Console.WriteLine("-----------------------------");

            foreach (var question in Questions)
            {
                question.DisplayQuestion();
            }
        }

        public override void TakeExam()
        {
            Console.WriteLine("\n===== Answer the Questions =====");

            foreach (var question in Questions)
            {
                question.DisplayQuestion();
                Console.Write("Your answer (enter the option number): ");
                string? input = Console.ReadLine();

                if (int.TryParse(input, out int userAnswer))
                {
                    if (userAnswer == question.CorrectAnswerId)
                    {
                        Console.WriteLine("Correct!");
                    }
                    else
                    {
                        Console.WriteLine("Incorrect!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid option number.");
                }
            }

            Console.WriteLine("\n===== Exam Results =====");
            Console.WriteLine("Right answers:");
            foreach (var question in Questions)
            {
                Console.WriteLine($"{question.Header}: Correct answer is option {question.CorrectAnswerId}");
            }
        }
    }
}
