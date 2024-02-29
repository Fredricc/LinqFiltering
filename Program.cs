
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

            //LinqOfType();

            LinqOrderBy();
        }

        static void LinqWhere()
        {
            Console.WriteLine("Query Syntax");

            IEnumerable<Student> query = from student in students
                                         where student.LastName.Equals("Smith")
                                         select student;

            foreach (Student item in query)
            {
                Console.WriteLine($"{item.FirstName}  {item.LastName}");
            }

            Console.WriteLine("\nMethod Syntax");

            IEnumerable<Student> methodQuery = students.Where(student => student.LastName.Equals("Smith")).Select(student => student);

            foreach (Student item in methodQuery)
            {
                Console.WriteLine($"{item.FirstName}  {item.LastName}");

            }
        }

        static void LinqOrderBy()
        {
            Console.WriteLine("Query Syntax");

            var query = from student in students
                        select (student.StudentId, student.FirstName);

            foreach (var item in query)
            {
                Console.WriteLine($"{item.StudentId}  {item.FirstName}");
            }

            Console.WriteLine("\nMethod Syntax");

            IEnumerable<Student> methodQuery = students.Select(student => student);

            foreach (Student item in methodQuery)
            {
                Console.WriteLine($"{item.FirstName}  {item.LastName}");

            }
        }

        static void LinqOfType()
        {
            IEnumerable<MedicalStudent> methodOfType = students.OfType<MedicalStudent>();

            Console.WriteLine("Medical Student");


            foreach (MedicalStudent item in methodOfType)
            {
                Console.WriteLine($"{item.FirstName}  {item.LastName}");

            }

        }
    
    }
}