
using StudentsList;

namespace LinqFiltering
{
    internal class Program
    {
        static List<Student> students = new List<Student>();

        static void Initialize()
        {
            students.Add(new Student(101, "James", "Smith"));
            students.Add(new Student(102, "Robert", "Smith"));
            students.Add(new Student(103, "Maria", "Rodgriguez"));
            students.Add(new Student(104, "David", "Smith"));
            students.Add(new Student(105, "James", "Smith"));
            students.Add(new Student(106, "John", "SevenLast"));
            students.Add(new Student(107, "Maria", "Garcia"));
            students.Add(new Student(108, "Mary", "Smith"));
        }

        static void Main(string[] args)
        {
            Initialize();
            IEnumerable<Student> query = from student in students
                                         where student.LastName.Equals("Smith")
                                         select student;

            foreach (Student item in query)
            {
                Console.WriteLine($"{item.FirstName}  {item.LastName}");
            }
            Console.ReadKey();
        }
    }
}