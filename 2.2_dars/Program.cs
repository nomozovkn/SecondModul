using _2._2_dars.Models;
using _2._2_dars.Services;

namespace _2._2_dars;

public class Program
{
    private static string studentUserName = "student";
    private static string studentPassword = "student";

    private static string teacherUserName = "teacher";
    private static string teacherPassword = "teacher";

    private static string directorUserName = "director";
    private static string directorPassword = "director";
    static void Main(string[] args)
    {
        StatrtFrontend();

    }
    public static void StatrtFrontend()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("0. stop");
            Console.WriteLine("1. Login");
            Console.Write("Enter:");
            var option = Console.ReadLine();
            if (option == "0")
            {
                Console.WriteLine("thanks");
                return;
            }
            else if (option == "1")
            {
                LoginPage();
            }

        }
    }
    public static void LoginPage()
    {
        while (true)
        {
            Console.Clear();
            Console.Write("Enter user name:");
            var userName = Console.ReadLine();
            Console.Write("Enter pasword:");
            var password = Console.ReadLine();


            if (userName == studentUserName && password == studentPassword)
            {
                RunStudent();
            }
            else if (userName == teacherUserName && password == teacherPassword)
            {
                RunTeacher();
            }
            else if (userName == directorUserName && password == directorPassword)
            {
                RunDirector();
            }
        }
    }
    public static void RunTeacher()
    {
        var studentservice = new StudentService();
        var testService = new TestService();
        while (true)
        {
            Console.Clear();
            Console.WriteLine("0. Quit");
            Console.WriteLine("1. Add test");
            Console.WriteLine("2. Delete test");
            Console.WriteLine("3. Read test");
            Console.WriteLine("4. GetById");
            Console.WriteLine("5. Update");
            Console.Write("Enter:");
            var option = Console.ReadLine();
            if (option == "0")
            {
                return;
            }
            else if (option == "1")
            {
                var test = new Test();
                Console.Write("Question text:");
                test.QuestionText = Console.ReadLine();

                Console.Write("A Variant ");
                test.AVariant = Console.ReadLine();

                Console.Write("B Varint");
                test.BVariant = Console.ReadLine();

                Console.Write("C Variant");
                test.CVariant = Console.ReadLine();

                Console.Write("Answer A/B/C");
                test.Answer = Console.ReadLine();

                testService.AddTest(test);
            }
            else if (option == "2")
            {
                Console.Write("Enter Id");
                var id = Guid.Parse(Console.ReadLine());
                testService.DeletedTest(id);
            }
            else if (option == "3")
            {
                var tests = testService.GetAllTests();
                foreach (var test in tests)
                {
                    Console.WriteLine($"Id {test.Id}");
                    Console.WriteLine($"Question text {test.QuestionText}");
                    Console.WriteLine($"A Variant {test.AVariant}");
                    Console.WriteLine($"B Variant {test.BVariant}");
                    Console.WriteLine($"C Variant {test.CVariant}");
                    Console.WriteLine($"Answer {test.Answer}");

                }
            }
            else if (option == "4")
            {
                Console.Write("Enter Id");
                var id = Guid.Parse(Console.ReadLine());
                var test = testService.GetById(id);
                Console.WriteLine($"Id {test.Id}");
                Console.WriteLine($"Question text {test.QuestionText}");
                Console.WriteLine($"A Variant {test.AVariant}");
                Console.WriteLine($"B Variant {test.BVariant}");
                Console.WriteLine($"C Variant {test.CVariant}");
                Console.WriteLine($"Answer {test.Answer}");

            }
            else if (option == "5")
            {
                var test = new Test();
                Console.Write("Enter Id:");
                var id = Guid.Parse(Console.ReadLine());

                Console.Write("Question text:");
                test.QuestionText = Console.ReadLine();

                Console.Write("A Variant");
                test.AVariant = Console.ReadLine();

                Console.Write("B Variant");
                test.BVariant = Console.ReadLine();

                Console.Write("C Variant");
                test.CVariant = Console.ReadLine();

                Console.Write("Answer");
                test.Answer = Console.ReadLine();

                testService.UpdatedTest(test);

            }
            Console.ReadKey();

        }
    }
    public static void RunDirector()
    {
        var teacherService = new TeacherService();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("0. Quit");
            Console.WriteLine("1. AddTeacher");
            Console.WriteLine("2. DeleteTeacher");
            Console.WriteLine("3. ReadTeacher");
            Console.WriteLine("4. GetById");
            Console.WriteLine("5. UpdateTeacher");
            Console.Write("Enter :");
            var option = Console.ReadLine();
            if (option == "0")
            {
                Console.WriteLine("Thank you");
                return;
            }
            else if (option == "1")
            {
                var teacher = new Teacher();
                Console.Write("FirstName:");
                teacher.FirstName = Console.ReadLine();
                Console.Write("LastName:");
                teacher.LastName = Console.ReadLine();
                Console.Write("Age:");
                teacher.Age = Int32.Parse(Console.ReadLine());
                Console.Write("Subject:");
                teacher.Subject = Console.ReadLine();
                Console.Write("Gender:");
                teacher.Gender = Console.ReadLine();
                Console.Write("Results:");
                teacherService.AddTeacher(teacher);
            }
            else if (option == "2")
            {
                Console.Write("Enter Id:");
                var id = Guid.Parse(Console.ReadLine());
                teacherService.DeletedTeacher(id);
            }
            else if (option == "3")
            {
                var teachers = teacherService.GetAllTeacher();
                foreach (var teacher in teachers)
                {
                    Console.Write($"Id: {teacher.Id}");
                    Console.Write($"FirstName: {teacher.FirstName}");
                    Console.Write($"LastName: {teacher.LastName}");
                    Console.Write($"Age: {teacher.Age}");
                    Console.Write($"Subject: {teacher.Subject}");
                    Console.Write($"Gender: {teacher.Gender}");
                    Console.Write($"Resultas: {teacher.Results}");

                }

            }
            else if (option == "4")
            {
                Console.Write("Enter id:");
                var id = Guid.Parse(Console.ReadLine());
                var teacher = teacherService.GetById(id);
                Console.WriteLine($"Id: {teacher.Id}");
                Console.WriteLine($"FirstName: {teacher.FirstName}");
                Console.WriteLine($"LastName: {teacher.LastName}");
                Console.WriteLine($"Age: {teacher.Age}");
                Console.WriteLine($"Subject: {teacher.Subject}");
                Console.WriteLine($"Gender: {teacher.Gender}");
                Console.WriteLine($"Resultas: {teacher.Results}");
            }
            else if (option == "5")
            {
                var teacher = new Teacher();
                Console.Write("Enter Id:");
                var id = Guid.Parse(Console.ReadLine());
                Console.WriteLine("FirstName:");
                teacher.FirstName = Console.ReadLine();
                Console.WriteLine("LastName:");
                teacher.LastName = Console.ReadLine();
                Console.WriteLine("Age:");
                teacher.Age = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Subject:");
                teacher.Subject = Console.ReadLine();
                Console.WriteLine("Gender:");
                teacher.Gender = Console.ReadLine();
                Console.WriteLine("Results:");
                teacherService.UpdatedTeacher(teacher);
            }

            Console.ReadKey();
        }

    }
    public static void RunStudent()
    {
        var studentService = new StudentService();
        var testService = new TestService();
        var teacherService = new TeacherService();
        Console.Write("Enter Id:");
        Guid id;
        Guid.TryParse(Console.ReadLine(), out id);
        var student = studentService.GetById(id);

        while (true)
        {
            Console.Clear();
            Console.WriteLine("0. Quit");
            Console.WriteLine("1. Start Test");
            Console.WriteLine("2. Like Teacher");
            Console.WriteLine("3. DiseLike Teacher");
            Console.Write("Enter:");
            var option = Console.ReadLine();
            if (option == "0")
            {
                Console.WriteLine("Thank you Student");
            }
            else if (option == "1")
            {
                var count = int.Parse(Console.ReadLine());
                var tests = testService.GetRandomTests(count);
                var correctAnswer = 0;
                foreach (var test in tests)
                {
                    Console.WriteLine(test.QuestionText);
                    Console.WriteLine($"A) {test.AVariant}");
                    Console.WriteLine($"B) {test.BVariant}");
                    Console.WriteLine($"C) {test.CVariant}");

                    Console.WriteLine("Enter Answer A/B/C");
                    var answer = Console.ReadLine();
                    if (answer == test.Answer)
                    {
                        Console.WriteLine("Correct");
                        correctAnswer++;
                    }
                    else
                    {
                        Console.WriteLine($"InCorrect, correct answer is {test.Answer}");
                    }
                }
                var res = correctAnswer * 100d / tests.Count;
                student.Results.Add((int)res);
                studentService.UpdatedStudent(student);
                Console.WriteLine($"Final: {res}%");
                Console.ReadKey();
            }
        }
    }
}
