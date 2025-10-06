namespace Week2M
{
    public class Student
    {
        private string name;
        private double grade;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public double Grade
        {
            get { return grade; }
            set { grade = value; }
        }

        public Student(string name)
        {
            this.name = name;
            this.grade = 0.0;
        }

        public void Display()
        {
            Console.WriteLine($"{name,-20} Grade: {grade:F1}");
        }
    }
}