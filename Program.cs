
using StudentsList;

namespace LinqFiltering
{
    internal class Program
    {
        static List<Student> students = new List<Student>();

        static List<Course> courses = new List<Course>();

        static void Initialize()
        {
            students.Add(new Student(101, "James", "Smith", 1));
            students.Add(new Student(102, "Robert", "Smith", 2));
            students.Add(new Student(103, "Maria", "Rodgriguez", 11));
            students.Add(new Student(104, "David", "Smith", 3));
            students.Add(new Student(105, "Jameson", "Smith", 2));
            students.Add(new Student(106, "Johnson", "SevenLast", 1));
            students.Add(new Student(107, "Maria", "Garcia", 3));
            students.Add(new Student(108, "Mary", "Smith", 3));

            courses.Add(new Course(1, "Digital Marketing"));
            courses.Add(new Course(2, "Finance"));
            courses.Add(new Course(3, "Computer Science"));
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

            //LinqGroupJoin();

            //LinqGroupBy();

            LinqToLookup();

        }

        static void LinqToLookup()
        {
            {
                Console.WriteLine("\nMethod Syntax");

                var methodQuery = students.ToLookup(
                    student => student.CourseId);

                for (int i = 1; i < 4; i++)
                {
                    Console.WriteLine($"\n{i}");

                    foreach (Student s in methodQuery[i])
                        Console.WriteLine($"{s.FirstName} {s.LastName}");
                }

            }
        }

        static void LinqGroupBy()
        {
            {
                Console.WriteLine("Query Syntax");

                var query = from student in students
                            group student by student.CourseId;

                foreach (var item in query)
                {
                    Console.WriteLine($"\n{item.Key}");

                    foreach (Student s in item)
                        Console.WriteLine($"{s.FirstName} {s.LastName}");
                }

                Console.WriteLine("\nMethod Syntax");

                var methodQuery = students.GroupBy(
                    student => student.CourseId);

                foreach (var item in methodQuery)
                {
                    Console.WriteLine($"\n{item.Key}");

                    foreach (Student s in item)
                        Console.WriteLine($"{s.FirstName} {s.LastName}");

                }
            }
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