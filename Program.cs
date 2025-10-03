namespace week1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            loop1to10();
            sumlooper();
            gbptousd();
            celsiustofahrenheit();
            cubecalculator();
            studentmarks();
            sumarrays();
            arrayofthrees();
            arrayofcars();
            sum2DArrays();
        }

        static void loop1to10()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }
        }

        static void sumlooper()
        {
            while (true)
            {
                Console.WriteLine("Enter the first number (or 'exit' to quit):");
                string input1 = Console.ReadLine();
                if (input1.ToLower() == "exit")
                    break;

                Console.WriteLine("Enter the second number (or 'exit' to quit):");
                string input2 = Console.ReadLine();
                if (input2.ToLower() == "exit")
                    break;

                if (int.TryParse(input1, out int num1) && int.TryParse(input2, out int num2))
                {
                    int sum = num1 + num2;
                    Console.WriteLine($"Sum: {sum}");
                    if (sum > 100)
                    {
                        Console.WriteLine("Sum exceeds 100. Exiting.");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter valid numbers.");
                }
            }
        }

        static void gbptousd()
        {
            const decimal exchangeRate = 1.25m; // Example exchange rate
            Console.WriteLine("Enter amount in GBP:");
            string input = Console.ReadLine();
            if (decimal.TryParse(input, out decimal gbpAmount))
            {
                decimal usdAmount = gbpAmount * exchangeRate;
                Console.WriteLine($"Equivalent amount in USD: {usdAmount}");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }

        static void celsiustofahrenheit()
        {
            Console.WriteLine("Enter temperature in Celsius:");
            string input = Console.ReadLine();
            if (double.TryParse(input, out double celsius))
            {
                double fahrenheit = (celsius * 9 / 5) + 32;
                Console.WriteLine($"Temperature in Fahrenheit: {fahrenheit}");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }

        static void cubecalculator()
        {
            Console.WriteLine("Enter a number to calculate its cube:");
            string input = Console.ReadLine();
            if (double.TryParse(input, out double number))
            {
                double cube = Math.Pow(number, 3);
                Console.WriteLine($"Cube of {number} is {cube}");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }

        struct StudentMark
        {
            public string Name { get; set; }
            public float Mark { get; set; }

            public StudentMark(string name, float mark)
            {
                Name = name;
                Mark = mark;
            }
        }

        static void studentmarks()
        {
            var students = new List<StudentMark>
            {
                new StudentMark("John", 67f)
            };

            Console.WriteLine("Current students:");
            foreach (var student in students)
            {
                Console.WriteLine($"{student.Name}: {student.Mark}");
            }

            Console.WriteLine("Add a new student.");
            Console.Write("Enter name: ");
            string name = Console.ReadLine();

            Console.Write("Enter mark: ");
            string markInput = Console.ReadLine();
            if (float.TryParse(markInput, out float mark))
            {
                students.Add(new StudentMark(name, mark));
                Console.WriteLine("Student added.");
            }
            else
            {
                Console.WriteLine("Invalid mark. Student not added.");
            }

            Console.WriteLine("Updated students:");
            foreach (var student in students)
            {
                Console.WriteLine($"{student.Name}: {student.Mark}");
            }
        }
        static void sumarrays()
        {
            int[] array1 = { 1, 2, 3 };
            int[] array2 = { 4, 5, 6 };
            if (array1.Length != array2.Length)
            {
                Console.WriteLine("Arrays must be of the same length.");
                return;
            }
            int[] sumArray = new int[array1.Length];
            for (int i = 0; i < array1.Length; i++)
            {
                sumArray[i] = array1[i] + array2[i];
            }
            Console.WriteLine("Sum of arrays:");
            foreach (var item in sumArray)
            {
                Console.WriteLine(item);
            }
        }
        static void arrayofthrees()
        {
            int[] array = new int[10];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = (i + 1) * 3;
            }
            Console.WriteLine("Array of first ten multiples of three:");
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
        }
        struct Car
        {
            public string colour;
            public string make;
            public double mileage;
            public int doors;
        }

        static void arrayofcars()
        {
            Car[] cars = new Car[4];
            cars[0] = new Car { colour = "Red", make = "Toyota", mileage = 15000, doors = 4 };
            cars[1] = new Car { colour = "Blue", make = "Honda", mileage = 20000, doors = 4 };
            cars[2] = new Car { colour = "Black", make = "Ford", mileage = 25000, doors = 2 };
            cars[3] = new Car { colour = "White", make = "Chevrolet", mileage = 30000, doors = 4 };
            Console.WriteLine("Car details:");
            foreach (var car in cars)
            {
                Console.WriteLine($"Make: {car.make}, Colour: {car.colour}, Mileage: {car.mileage}, Doors: {car.doors}");
            }
        }

        static void sum2DArrays()
        {
            int[,] array1 = { { 1, 2, 3 }, { 4, 5, 6 } };
            int[,] array2 = { { 4, 5, 6 }, { 7, 8, 9 } };
            int rows = array1.GetLength(0);
            int cols = array1.GetLength(1);

            int[,] sumArray = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    sumArray[i, j] = array1[i, j] + array2[i, j];
                }
            }

            Console.WriteLine("Sum of corresponding elements:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(sumArray[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

    }
}

