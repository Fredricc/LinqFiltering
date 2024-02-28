
using StudentsList;

namespace LinqFiltering
{
    internal class Program
    {
        static List<Student> students = new List<Student>();

        static void Initialize()
        {
            students.Add(new EngineeringStudent(101, "James", "Smith"));
            students.Add(new MedicalStudent(102, "Robert", "Smith"));
            students.Add(new EngineeringStudent(103, "Maria", "Rodgriguez"));
            students.Add(new MedicalStudent(104, "David", "Smith"));
            students.Add(new MedicalStudent(105, "James", "Smith"));
            students.Add(new EngineeringStudent(106, "John", "SevenLast"));
            students.Add(new MedicalStudent(107, "Maria", "Garcia"));
            students.Add(new MedicalStudent(108, "Mary", "Smith"));
        }

        static void Main(string[] args)
        {
            Initialize();

            LinqOfType();
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