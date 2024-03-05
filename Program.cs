
using StudentsList;

namespace LinqFiltering
{
    internal class Program
    {
        static List<Student> students = new List<Student>();

        static List<Course> courses = new List<Course>();

        static void Initialize()
        {
            students.Add(new Student(101, "James", "Smith", 11));
            students.Add(new Student(102, "Robert", "Smith", 22));
            students.Add(new Student(103, "Maria", "Rodgriguez", 11));
            students.Add(new Student(104, "David", "Smith", 33));
            students.Add(new Student(105, "James", "Smith", 22));
            students.Add(new Student(106, "John", "SevenLast", 11));
            students.Add(new Student(107, "Maria", "Garcia", 33));
            students.Add(new Student(108, "Mary", "Smith", 33));

            courses.Add(new Course(11, "Marketing"));
            courses.Add(new Course(22, "Finance"));
            courses.Add(new Course(33, "Computer Science"));
        }

        static void Main(string[] args)
        {
            Initialize();

            //LinqOfType();

            //LinqOrderBy();

            // LinqOrderByDesc();

            //LinqThenByDesc();

            //LinqReverse();

            //LinqJoinOperation();

            LinqGroupJoin();

        }

        static void LinqGroupJoin()
        {
            {
                Console.WriteLine("Query Syntax");

                var query = from course in courses
                            join student in students
                            on course.CourseId equals student.CourseId
                            into CourseStudents
                            select new { course.CourseName, CourseStudents };

                foreach (var item in query)
                {
                    Console.WriteLine($"\n{item.CourseName}");

                    foreach (var student in item.CourseStudents)
                        Console.WriteLine($"{student.StudentId} {student.FirstName}");
                }

                Console.WriteLine("\nMethod Syntax");

                var methodQuery = courses.GroupJoin(students,
                    course => course.CourseId,
                    student => student.CourseId,
                    (c, CourseStudents) => new { c.CourseName, CourseStudents });

                foreach (var item in methodQuery)
                {
                    Console.WriteLine($"\n{item.CourseName}");

                    foreach (var student in item.CourseStudents)
                        Console.WriteLine($"{student.StudentId} {student.FirstName}");

                }
            }
        }

            static void LinqJoinOperation()
        {
            {
                Console.WriteLine("Query Syntax");

                var query = from student in students
                            join course in courses
                            on student.CourseId equals course.CourseId
                            select new { student.StudentId, student.FirstName, course.CourseName };

                foreach (var item in query)
                {
                    Console.WriteLine($"{item.StudentId}  {item.FirstName}  {item.CourseName}");
                }

                Console.WriteLine("\nMethod Syntax");

                var methodQuery = students.Join(courses, student => student.CourseId, course => course.CourseId,
                    (s, c) => new { s.StudentId, s.FirstName, c.CourseName });

                foreach (var item in methodQuery)
                {
                    Console.WriteLine($"{item.StudentId}  {item.FirstName}  {item.CourseName}");

                }
            }

            static void LinqReverse()
            {
                Console.WriteLine("Query LinqReverse Syntax");

                students.Reverse();

                foreach (Student item in students)
                {
                    Console.WriteLine($"{item.StudentId} {item.FirstName}  {item.LastName}");

                }
            }
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

        static void LinqReverse()
        {
            Console.WriteLine("Query LinqReverse Syntax");

             students.Reverse();

            foreach (Student item in students)
            {
                Console.WriteLine($"{item.StudentId} {item.FirstName}  {item.LastName}");

            }
        }

        static void LinqThenByDesc()
        {
            Console.WriteLine("Query Syntax");

            var query = from student in students
                        orderby student.FirstName, student.LastName descending
                        select student;

            foreach (var item in query)
            {
                Console.WriteLine($"{item.StudentId}  {item.FirstName}");
            }

            Console.WriteLine("\nMethod Syntax");

            IEnumerable<Student> methodQuery = students.OrderByDescending(students => students.LastName).ThenByDescending(students => students.FirstName).Select(student => student);

            foreach (Student item in methodQuery)
            {
                Console.WriteLine($"{item.FirstName}  {item.LastName}");

            }
        }
        static void LinqOrderByDesc()
        {
            Console.WriteLine("Query Syntax");

            var query = from student in students
                        orderby student.FirstName, student.LastName
                        select student;

            foreach (var item in query)
            {
                Console.WriteLine($"{item.StudentId}  {item.FirstName}");
            }

            Console.WriteLine("\nMethod Syntax");

            IEnumerable<Student> methodQuery = students.OrderByDescending(students => students.LastName).ThenBy(students => students.FirstName).Select(student => student);

            foreach (Student item in methodQuery)
            {
                Console.WriteLine($"{item.FirstName}  {item.LastName}");

            }
        }

        static void LinqOrderBy()
        {
            Console.WriteLine("Query Syntax");

            var query = from student in students
                        orderby student.FirstName
                        select student;

            foreach (var item in query)
            {
                Console.WriteLine($"{item.StudentId}  {item.FirstName}");
            }

            Console.WriteLine("\nMethod Syntax");

            IEnumerable<Student> methodQuery = students.OrderBy(students => students.LastName).Select(student => student);

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