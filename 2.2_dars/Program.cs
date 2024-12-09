using _2._2_dars.Models;
using _2._2_dars.Services;

namespace _2._2_dars;

public class Program        
{
    private static string studentUserName = "student1";
    private static string studentPassword = "student1";
    private static string student2UserName = "student2";
    private static string student2Password = "student2";
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
            if(option =="0")
            {
                Console.WriteLine("thanks");
                return;
            }
            else if(option =="1")
            {
             LoginPage();
            }

        }
    }
    public static void LoginPage()
    {
        while(true)
        {
            Console.Clear();
            Console.Write("Enter user name:");
            var userName= Console.ReadLine();
            Console.Write("Enter pasword:");
            var password= Console.ReadLine();
           
            
            if(userName ==studentUserName && password==studentPassword)
            {

            }
            else if (userName ==student2UserName &&password==student2Password)
            {

            }
            else if (userName==teacherUserName && password==teacherPassword)
            {
                RunTeacher();
            }
            else if(userName==directorUserName && password==directorPassword)
            {

            }
        }
    }
    public static void RunTeacher()
    {
        var studentservice=new StudentService();
        var testService =new TestService();
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
            if(option =="0")
            {
                return;
            }
            else if (option =="1")
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
            else if(option =="2")
            {
                Console.Write("Enter Id");
                var id = Guid.Parse(Console.ReadLine());
                testService.DeletedTest(id);
            }
            else if (option=="3")
            {
               var tests= testService.GetAllTests();
                foreach(var test in tests)
                {
                    Console.WriteLine($"Id {test.Id}");
                    Console.WriteLine($"Question text {test.QuestionText}");
                    Console.WriteLine($"A Variant {test.AVariant}");
                    Console.WriteLine($"B Variant {test.BVariant}");
                    Console.WriteLine($"C Variant {test.CVariant}");
                    Console.WriteLine($"Answer {test.Answer}");
                   
                }
            }
            else if (option =="4")
            {
                Console.Write("Enter Id");
                var id = Guid.Parse(Console.ReadLine());
                var test=testService.GetById(id);
                Console.WriteLine($"Id {test.Id}");
                Console.WriteLine($"Question text {test.QuestionText}");
                Console.WriteLine($"A Variant {test.AVariant}");
                Console.WriteLine($"B Variant {test.BVariant}");
                Console.WriteLine($"C Variant {test.CVariant}");
                Console.WriteLine($"Answer {test.Answer}");

            }
            else if (option =="5")
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
}
