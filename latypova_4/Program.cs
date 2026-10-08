using latypova_4.Structs;
using latypova_4.Enums;
using System;
using System.Threading;

namespace latypova_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task1();
            Task2();
            if (Task3())
            {
                Task4();
            }
        }

        #region Задание 1

        public static void Task1()
        {
            Console.WriteLine("Задание 1 - Вывести 20 случайных чисел в массиве, поменять два введенных числа местами и снова вывести массив");

            int[] array = RandomArray(20);
            Console.Write("Изначальный массив: ");
            PrintArray(array);

            Console.WriteLine("Введите два числа из изначального массива: ");
            var isNum1 = int.TryParse(Console.ReadLine(), out var num1);
            var isNum2 = int.TryParse(Console.ReadLine(), out var num2);

            if (!isNum1 || !isNum2)
            {
                Console.WriteLine("Ошибка: неверный ввод");
                return;
            }

            var firstIndex = Index(array, num1);
            var secondIndex = Index(array, num2);

            if (firstIndex == -1 || secondIndex == -1)
            {
                Console.WriteLine("Ошибка: введенного вами числа (чисел) нет в исходном массиве");
                return;
            }

            (array[firstIndex], array[secondIndex]) = (array[secondIndex], array[firstIndex]); //Запишем так замену, т.к. это быстрый способ замены через кортеж

            Console.Write("Массив после перестановки: ");
            PrintArray(array);
            Console.ReadKey();
        }

        /// <summary>Метод для создания массива с рандомными числами, параметрами которого можно управлять самим</summary>
        /// <param name="size">Параметр для выбора размера массива</param>
        /// <returns>Массив случайных чисел определенной длины</returns>
        public static int[] RandomArray(int size)
        {
            Random random = new Random();
            int[] array = new int[size];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(1, 101); 
            }

            return array;
        }
        
        /// <summary>Метод для нахождения индекса элемента, имея его значение</summary>
        /// <param name="array">Массив целых чисел</param>
        /// <param name="value">Значение из массива, индекс которого мы ищем</param>
        /// <returns>Индекс элемента из массива</returns>
        public static int Index(int[] array, int value)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == value)
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>Удобный метод для вывода значений массива посредством соединения элементов с помощью любого знака</summary>
        /// <param name="array">Массив целых чисел</param>
        public static void PrintArray(int[] array)
        {
            Console.WriteLine(string.Join(", ", array)); //Пишем так, потому что Join соединяет элементы с помощью знака (пробел + запятая)
        }

        #endregion

        #region Задание 2

        public static void Task2()
        {
            Console.WriteLine("Задание 2 - Суммировать, умножить, найти среднее арифметическое элементов массива");

            int[] array = RandomArray(10);
            Console.Write("Массив: ");
            PrintArray(array);

            long product = 0; //Инициализируем, т.к. ref
            double average; //Не инициализируем, т.к. out

            long sum = ArrayOperations(ref product, out average, array);

            Console.WriteLine($"Сумма элементов массива: {sum}");
            Console.WriteLine($"Произведение элементов массива: {product}");
            Console.WriteLine($"Среднее арифметическое элементов массива: {average:F2}");
            Console.ReadKey();
        }

        /// <summary>Выполняет комплексные операции над массивом чисел: сложение, произведение, поиск среднего арифметического</summary>
        /// <param name="product">Выходное значение произведения всех элементов</param>
        /// <param name="average">Выходной параметр для сохранения среднего арифметического чисел</param>
        /// <param name="array">Массив целых чисел</param>
        /// <returns>Возвращает сумму всех элементов массива</returns>
        public static long ArrayOperations(ref long product, out double average, params int[] array)
        {
            product = ProductArray(array);
            average = AverageArray(array);

            return SumArray(array);
        }

        /// <summary>Вычисляет сумму всех элементов массива</summary>
        /// <param name="array">Массив целых чисел</param>
        /// <returns>Возвращает сумму элементов массива</returns>
        public static long SumArray(params int[] array)
        {
            long sum = 0;

            foreach (int num in array)
            {
                sum += num;
            }

            return sum;
        }
        
        /// <summary>Вычисляет произведение всех элементов массива</summary>
        /// <param name="array">Массив целых чисел</param>
        /// <returns>Возвращает произведение элементов массива</returns>
        public static long ProductArray(params int[] array)
        {
            long result = 1;

            foreach (int num in array)
            {
                result *= num;
            }

            return result;
        }

        /// <summary>Вычисляет среднее арифметическое элементов массива</summary>
        /// <param name="array"></param>
        /// <returns>Возвращает среднее арифметическое элементов массива</returns>
        public static double AverageArray(params int[] array)
        {
            if (array.Length == 0)
            {
                return 0;
            }

            return (double)SumArray(array) / array.Length;
        }

        #endregion

        #region Задание 3

        public static bool Task3()
        {
            Console.WriteLine("Задание 3 - Обработать введенное число и нарисовать его с помощью #, либо же выдать ошибки");
            Console.WriteLine("Введите цифру: ");

            if (!int.TryParse(Console.ReadLine(), out int number))
            {
                throw new FormatException("Ошибка: введено не число");
            }

            if (number < 0 || number > 9)
            {
                Error();
            }
            else
            {
                DrawDigit(number);
            }

            Console.WriteLine("Введите: exit или закрыть, если хотите завершить работу программы");
            
            var input = Console.ReadLine().ToLower();

            if (input == "exit" || input == "закрыть")
            {
                return false;
            }

            return true;
        }
        
        /// <summary>Отрисовывает введенную цифру в консоли</summary>
        /// <param name="digit">Цифра от 0 до 9, которую необходимо нарисовать в консоли</param>
        public static void DrawDigit(int digit)
        {
            switch (digit)
            {
                case 0:
                    Console.WriteLine(" ### \n#   #\n#   #\n#   #\n ### ");
                    break;
                case 1:
                    Console.WriteLine("  #  \n ##  \n  #  \n  #  \n ### ");
                    break;
                case 2:
                    Console.WriteLine(" ### \n#   #\n  ## \n #   \n#####");
                    break;
                case 3:
                    Console.WriteLine("#####\n    #\n ### \n    #\n#####");
                    break;
                case 4:
                    Console.WriteLine("#   #\n#   #\n#####\n    #\n    #");
                    break;
                case 5:
                    Console.WriteLine("#####\n#    \n#### \n    #\n#### ");
                    break;
                case 6:
                    Console.WriteLine(" ### \n#    \n#### \n#   #\n ### ");
                    break;
                case 7:
                    Console.WriteLine("#####\n    #\n   # \n  #  \n #   ");
                    break;
                case 8:
                    Console.WriteLine(" ### \n#   #\n ### \n#   #\n ### ");
                    break;
                case 9:
                    Console.WriteLine(" ### \n#   #\n ####\n    #\n ### ");
                    break;
            }
        }

        /// <summary>Метод, который срабатывает в случае ввода неправильного числа. Меняется цвет консоли на 3 секунды и выводится ошибка</summary>
        public static void Error()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Ошибка: вы ввели число НЕ от 0 до 9");

            Thread.Sleep(3000);

            Console.ResetColor();
        }

        #endregion

        #region Задание 4

        public static void Task4()
        {
            Console.WriteLine("Задание 4 - Посчитать количество фингалов от бабки у пятерых дедов за плохие слова");

            Grandpa[] grandpas =
            {
                new Grandpa("Евгений", Grumpiness.Low, new string[] {"Идиоты", "Проказники"}),
                new Grandpa("Михаил", Grumpiness.Extra, new string[] {"Тунеядцы", "На том свете отдохну", "В наше время такой ерунды не было", "Бесстыдники", "Лоботрясы"}),
                new Grandpa("Никита", Grumpiness.High, new string[] {"Ишь, моду взяли", "М-да, потерянное поколение", "Проститутки", "Тьфу, срамота"}),
                new Grandpa("Дмитрий", Grumpiness.Medium, new string[] {"Ух, ремня на вас нет", "Бесстыдники", "Паршивец"}),
                new Grandpa("Владимир", Grumpiness.Impossible, new string[] {"Идиоты", "Выродки", "Паскуда", "Пшел вон", "Дармоеды", "Уму палата, а толку ноль"}),
            };

            string[] badPhrases = { "Тунеядцы", "Проститутки", "Идиоты", "Бесстыдники", "М-да, потерянное поколение" };

            for (int i = 0; i < grandpas.Length; i++)
            {
                Grandpa.GrandmaBlows(ref grandpas[i], badPhrases);

                PrintGrandpa(grandpas[i]);
            }

            Console.ReadKey();
        }

        /// <summary>Выводит в консоль информацию о деде, а именно его имя и количество фингалов от бабки</summary>
        /// <param name="grandpa">Объект дедушки, информацию о котором нужно напечатать или же вывести</param>
        public static void PrintGrandpa(Grandpa grandpa)
        {
            Console.WriteLine($"Имя деда: {grandpa.Name}, количество фингалов от бабки: {grandpa.StrikeCount}");
        }

        #endregion
    }
}