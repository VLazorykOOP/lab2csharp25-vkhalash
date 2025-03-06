namespace Lab2CSharp
{
    public class Program
    {
        private static void Main()
        {
            Console.Write("Enter option 1-4: ");
            bool isValid = int.TryParse(Console.ReadLine(), out int option) && option >= 1 && option <= 4;

            while (!isValid)
            {
                Console.Write("Please enter a valid option. Enter option 1-4: ");
                isValid = int.TryParse(Console.ReadLine(), out option) && option >= 1 && option <= 4;
            }

            switch (option)
            {
                case 1: Task1(); break;
                case 2: Task2(); break;
                case 3: Task3(); break;
                case 4: Task4(); break;
            }
        }

        private static void Task1()
        {
            Console.Write("Enter array dimension (1 for 1D, 2 for 2D): ");
            bool isValid = int.TryParse(Console.ReadLine(), out int option) && option >= 1 && option <= 2;

            while (!isValid)
            {
                Console.Write("Invalid input. Enter 1 or 2: ");
                isValid = int.TryParse(Console.ReadLine(), out option) && option >= 1 && option <= 2;
            }

            switch (option)
            {
                case 1:
                    Console.Write("Enter array size: ");
                    isValid = int.TryParse(Console.ReadLine(), out int size) && size >= 1;

                    while (!isValid)
                    {
                        Console.Write("Invalid size. Enter a positive number: ");
                        isValid = int.TryParse(Console.ReadLine(), out size) && size >= 1;
                    }

                    float[] numbers = new float[size];
                    float product = 1;

                    for (int i = 0; i < numbers.Length; i++)
                    {
                        numbers[i] = GetValidElement($"Enter element number {i + 1}: ");
                        product *= numbers[i];
                    }

                    Console.WriteLine($"Product of elements: {product}");
                    Console.WriteLine(product is >= 100 and < 1000
                        ? "Product is a three-digit number."
                        : "Product is not a three-digit number.");

                    break;
                case 2:
                    Console.Write("Enter number of rows: ");
                    isValid = int.TryParse(Console.ReadLine(), out int rows) && rows >= 1;

                    while (!isValid)
                    {
                        Console.Write("Invalid input. Enter a positive number: ");
                        isValid = int.TryParse(Console.ReadLine(), out rows) && rows >= 1;
                    }

                    Console.Write("Enter number of columns: ");
                    isValid = int.TryParse(Console.ReadLine(), out int cols) && cols >= 1;

                    while (!isValid)
                    {
                        Console.Write("Invalid input. Enter a positive number: ");
                        isValid = int.TryParse(Console.ReadLine(), out cols) && cols >= 1;
                    }

                    float[,] matrix = new float[rows, cols];
                    float matrixProduct = 1;

                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < cols; j++)
                        {
                            matrix[i, j] = GetValidElement($"Enter element [{i},{j}]: ");
                            matrixProduct *= matrix[i, j];
                        }
                    }

                    Console.WriteLine($"Product of elements: {matrixProduct}");
                    Console.WriteLine(matrixProduct is >= 100 and < 1000
                        ? "Product is a three-digit number."
                        : "Product is not a three-digit number.");

                    break;
            }
        }

        private static void Task2()
        {
            Console.Write("Enter array size: ");
            bool isValid = int.TryParse(Console.ReadLine(), out int size) && size >= 1;

            while (!isValid)
            {
                Console.Write("Invalid size. Enter a positive number: ");
                isValid = int.TryParse(Console.ReadLine(), out size) && size >= 1;
            }

            float[] numbers = new float[size];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = GetValidElement($"Enter element number {i + 1}: ");
            }

            int greaterCount = 0;

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (numbers[i + 1] > numbers[i])
                {
                    greaterCount++;
                }
            }

            Console.WriteLine($"Found {greaterCount} elements greater than the previous element.");
        }

        private static void Task3()
        {
            Console.Write("Enter square matrix size: ");
            bool isValid = int.TryParse(Console.ReadLine(), out int size) && size >= 1;

            while (!isValid)
            {
                Console.Write("Invalid size. Enter a positive number: ");
                isValid = int.TryParse(Console.ReadLine(), out size) && size >= 1;
            }

            float[,] matrix = new float[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = GetValidElement($"Enter element [{i},{j}]: ");
                }
            }

            float diagonalSum = 0;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if ((i + j) == (size - 1))
                        diagonalSum += matrix[i, j];
                }
            }

            Console.WriteLine($"Sum of main diagonal elements: {diagonalSum}");

        }

        private static void Task4()
        {
            Console.Write("Enter number of stepped array rows: ");
            bool isValid = int.TryParse(Console.ReadLine(), out int rows) && rows >= 1;

            while (!isValid)
            {
                Console.Write("Invalid input. Enter a positive number: ");
                isValid = int.TryParse(Console.ReadLine(), out rows) && rows >= 1;
            }

            float[][] jaggedArray = new float[rows][];
            int size = 0;

            for (int i = 0; i < rows; i++)
            {
                jaggedArray[i] = new float[i + 1];
            }

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    jaggedArray[i][j] = GetValidElement($"Enter element [{i},{j}]: ");
                }
            }

            foreach (var row in jaggedArray)
            {
                foreach (var value in row)
                {
                    if (value > 0)
                    {
                        size += 1;
                    }
                }
            }

            float[] array = new float[size];

            if (size > 0)
            {
                int index = 0;

                foreach (var row in jaggedArray)
                {
                    foreach (var value in row)
                    {
                        if (value > 0)
                        {
                            array[index++] = value;
                        }
                    }
                }
            }

            Console.WriteLine(array.Length > 0
                ? $"Positive elements found: {string.Join(",", array)}"
                : "No positive elements found.");
        }

        static float GetValidElement(string prompt)
        {
            Console.Write(prompt);
            bool isValid = float.TryParse(Console.ReadLine(), out float value);
            while (!isValid)
            {
                Console.Write($"Invalid input. {prompt}");
                isValid = float.TryParse(Console.ReadLine(), out value);
            }
            return value;
        }
    }
}
