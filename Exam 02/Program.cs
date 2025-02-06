namespace Exam_02
{
    static class Program
    {
        static void Main()
        {
            // Create a subject
            var subject = new Subject(1, "C# Basics and OOP");

            // Prompt user to create an exam
            Console.WriteLine("Choose the type of exam:");
            Console.WriteLine("1. Final Exam");
            Console.WriteLine("2. Practical Exam");
            Console.Write("Enter your choice: ");

            if (!int.TryParse(Console.ReadLine(), out int examChoice) || (examChoice != 1 && examChoice != 2))
            {
                Console.WriteLine("Invalid choice. Exiting program.");
                return;
            }

            Exam exam = examChoice == 1 ? new FinalExam(DateTime.Now.AddDays(7), 0) : new PracticalExam(DateTime.Now.AddDays(7), 0);

            // Add questions
            Console.Write("Enter the number of questions: ");
            if (!int.TryParse(Console.ReadLine(), out int numberOfQuestions) || numberOfQuestions <= 0)
            {
                Console.WriteLine("Invalid number of questions. Exiting program.");
                return;
            }
            exam.NumberOfQuestions = numberOfQuestions;

            for (int i = 0; i < numberOfQuestions; i++)
            {
                Console.WriteLine($"\nAdding Question {i + 1}:");
                Console.Write("Enter the question header: ");
                string header = Console.ReadLine() ?? string.Empty;
                Console.Write("Enter the question body: ");
                string body = Console.ReadLine() ?? string.Empty;
                Console.Write("Enter the mark for this question: ");
                if (!int.TryParse(Console.ReadLine(), out int mark) || mark <= 0)
                {
                    Console.WriteLine("Invalid mark. Skipping this question.");
                    continue;
                }

                Console.WriteLine("Choose the question type:");
                Console.WriteLine("1. True/False");
                Console.WriteLine("2. MCQ");
                Console.Write("Enter your choice: ");

                if (!int.TryParse(Console.ReadLine(), out int questionType) || (questionType != 1 && questionType != 2))
                {
                    Console.WriteLine("Invalid choice. Skipping this question.");
                    continue;
                }

                Question question;
                if (questionType == 1)
                {
                    question = new TrueFalseQuestion(header, body, mark);
                    question.AnswerList.Add(new Answer(1, "True"));
                    question.AnswerList.Add(new Answer(2, "False"));
                }
                else
                {
                    question = new MCQQuestion(header, body, mark);
                    Console.Write("Enter the number of options: ");
                    if (!int.TryParse(Console.ReadLine(), out int numberOfOptions) || numberOfOptions < 2)
                    {
                        Console.WriteLine("Invalid number of options. Skipping this question.");
                        continue;
                    }
                    for (int j = 0; j < numberOfOptions; j++)
                    {
                        Console.Write($"Enter option {j + 1} text: ");
                        string optionText = Console.ReadLine() ?? string.Empty;
                        question.AnswerList.Add(new Answer(j + 1, optionText));
                    }
                }

                Console.Write("Enter the correct answer ID: ");
                if (!int.TryParse(Console.ReadLine(), out int correctAnswerId))
                {
                    Console.WriteLine("Invalid answer ID. Skipping this question.");
                    continue;
                }
                question.CorrectAnswerId = correctAnswerId;

                exam.Questions.Add(question);
                Console.WriteLine("=====================");
            }

            // Assign the exam to the subject
            subject.CreateExam(exam);

            // Display subject and exam details
            Console.WriteLine("\n===== Subject Details =====");
            Console.WriteLine(subject);
            Console.WriteLine("\n===== Exam Details =====");
            subject.Exam?.ShowExam();

            // Take the exam
            subject.Exam?.TakeExam();
        }
    }
}
