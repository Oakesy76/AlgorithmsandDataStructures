namespace Week2M
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Counter exercises
            Counter myCounter = new Counter(49);
            myCounter.Display();

            myCounter.Amount = 6;
            for (int i = 0; i < 4; i++) myCounter.Increment();
            myCounter.Display();

            for (int i = 0; i < 3; i++) myCounter.Decrement();
            myCounter.Display();

            myCounter.ResetToTop();
            myCounter.DisplayBoth();

            myCounter.ShowInstanceMessage();
            myCounter.Display();

            // Student exercises
            string[] lecturerNames = { "Dr. Han", "Prof. Mitchel", "Dr. Jim", "Prof. John", "Dr. Yash", "Prof. Emily" };
            Student[] students = new Student[6];
            var rand = new Random();

            for (int i = 0; i < students.Length; i++)
            {
                students[i] = new Student(lecturerNames[i]);
            }

            for (int i = 0; i < students.Length; i++)
            {
                students[i].Grade = rand.NextDouble() * (85.0 - 25.0) + 25.0;
            }

            Console.WriteLine("\nStudent Grades:");
            foreach (var student in students)
            {
                student.Display();
            }
        }
    }
}